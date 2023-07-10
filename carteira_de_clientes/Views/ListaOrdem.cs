using System;
using System.Drawing;
using System.Windows.Forms;
using Carteira_De_Clientes;

namespace View
{
    public class ListaOrdem : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView ordemGridView = new DataGridView();
        private Button adicionarOrdemButton = new Button();
        private Button atualizarOrdemButton = new Button();
        private Button deletarOrdemButton = new Button();
        private Button voltarButton = new Button();
        PictureBox pictureBox = new PictureBox();

        public ListaOrdem()
        {
            this.Text = "Listagem de Ordem de Serviço";
            this.Load += new EventHandler(listaOrdem_Load);
        }

        private void listaOrdem_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void ordemGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.ordemGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        private void SetupLayout()
        {
            adicionarOrdemButton.Text = "Novo";
            adicionarOrdemButton.Location = new Point(270, 10);
            adicionarOrdemButton.BackColor = Color.Snow;
            adicionarOrdemButton.Click += new EventHandler(adicionarOrdemButton_Click);

            atualizarOrdemButton.Text = "Editar";
            atualizarOrdemButton.Location = new Point(350, 10);
            atualizarOrdemButton.BackColor = Color.Snow;
            atualizarOrdemButton.Click += new EventHandler(atualizarOrdemButton_Click);

            deletarOrdemButton.Text = "Excluir";
            deletarOrdemButton.Location = new Point(430, 10);
            deletarOrdemButton.BackColor = Color.Snow;
            deletarOrdemButton.Click += new EventHandler(deletarOrdemButton_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(510, 10);
            voltarButton.BackColor = Color.Snow;
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(adicionarOrdemButton);
            buttonPanel.Controls.Add(atualizarOrdemButton);
            buttonPanel.Controls.Add(deletarOrdemButton);
            buttonPanel.Controls.Add(voltarButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Size = new Size(600, 400);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(ordemGridView);

            ordemGridView.ColumnCount = 8;

            ordemGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            ordemGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ordemGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(ordemGridView.Font, FontStyle.Bold);

            ordemGridView.Name = "ordemGridView";
            ordemGridView.Location = new Point(8, 8);
            ordemGridView.Size = new Size(650, 400);
            ordemGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ordemGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ordemGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            ordemGridView.GridColor = Color.Black;
            ordemGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;

            ordemGridView.RowHeadersVisible = false;

            ordemGridView.Columns[0].Name = "Id";
            ordemGridView.Columns[0].Width = 50;

            ordemGridView.Columns[1].Name = "Cliente";
            ordemGridView.Columns[1].Width = 110;

            ordemGridView.Columns[2].Name = "Gerenciamento";
            ordemGridView.Columns[2].Width = 100;

            ordemGridView.Columns[3].Name = "Preço";
            ordemGridView.Columns[3].Width = 80;

            ordemGridView.Columns[4].Name = "Data Realizada";
            ordemGridView.Columns[4].Width = 117;

            ordemGridView.Columns[5].Name = "Status";
            ordemGridView.Columns[5].Width = 70;

            ordemGridView.Columns[6].Name = "descrição";
            ordemGridView.Columns[6].Width = 150;

            ordemGridView.Columns[7].Name = "Data Limite";
            ordemGridView.Columns[7].Width = 117;

            ordemGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ordemGridView.MultiSelect = false;
            ordemGridView.Dock = DockStyle.Fill;

            ordemGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(ordemGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            ordemGridView.Rows.Clear();

            IEnumerable<Carteira_De_Clientes.Models.Ordem> collectionOrdens = Carteira_De_Clientes.Controllers.Ordem.GetAllOrdens();

            if (collectionOrdens != null && collectionOrdens.Count() > 0)
            {
                foreach (var item in collectionOrdens)
                {
                    Carteira_De_Clientes.Models.FuncionarioServico funcionarioServicoOrdem = Carteira_De_Clientes.Controllers.FuncionarioServico.GetFuncionarioServico(item.FuncionarioServicoId.ToString());
                    Carteira_De_Clientes.Models.Cliente clienteOrdem = Carteira_De_Clientes.Controllers.Cliente.GetCliente(item.ClienteId.ToString());

                    string[] linhaOrdem = { item.Id.ToString(), clienteOrdem.Nome, funcionarioServicoOrdem.Id.ToString(), item.PrecoOrdem, item.DataRealizada, item.Pago.ToString(), item.Descricao, item.DataLimite };


                    ordemGridView.Rows.Add(linhaOrdem);
                }
            }
        }

        private void adicionarOrdemButton_Click(object sender, EventArgs e)
        {
            Ordem telaOrdem = new Ordem(null);
            telaOrdem.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaOrdem.ShowDialog();
        }


        private void atualizarOrdemButton_Click(object sender, EventArgs e)
        {
            if (this.ordemGridView.SelectedRows.Count > 0 &&
                this.ordemGridView.SelectedRows[0].Index !=
                this.ordemGridView.Rows.Count - 1)
            {
                string idOrdemSelecionado = ordemGridView.Rows[this.ordemGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                Ordem telaOrdem = new Ordem(Int32.Parse(idOrdemSelecionado));

                if (telaOrdem != null)
                {
                    telaOrdem.AlterarVisibilidadeId(true);

                    telaOrdem.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                    telaOrdem.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nenhuma Ordem de Serviço foi selecionada!");
                }
            }
        }

        private void deletarOrdemButton_Click(object sender, EventArgs e)
        {
            if (this.ordemGridView.SelectedRows.Count > 0 &&
                this.ordemGridView.SelectedRows[0].Index !=
                this.ordemGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a Ordem de Serviço?", "Exclusão de Ordem de Serviço", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idOrdem = ordemGridView.Rows[this.ordemGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Carteira_De_Clientes.Controllers.Ordem.ExcluirOrdem(idOrdem);
                    MessageBox.Show("Ordem de Serviço excluída com sucesso!");
                    PopulateDataGridView();
                    this.ordemGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }
            }
            else
            {
                MessageBox.Show("Nenhuma Ordem de Serviço foi selecionada!");
            }
        }

        private void recarregarDadosGrid(object sender, FormClosedEventArgs e)
        {
            PopulateDataGridView();
            this.ordemGridView.Refresh();
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}