using System;
using System.Drawing;
using System.Windows.Forms;
using Carteira_De_Clientes;

namespace View
{
    public class ListaServico : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView servicoGridView = new DataGridView();
        private Button adicionarServicoButton = new Button();
        private Button atualizarServicoButton = new Button();
        private Button deletarServicoButton = new Button();
        private Button voltarButton = new Button();

        public ListaServico()
        {
            this.Text = "Listagem de Serviço";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopLevel = false;
            this.AutoScroll = true;
            this.Load += new EventHandler(ListaServico_Load);

        }

        private void ListaServico_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void servicoGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.servicoGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            adicionarServicoButton.Text = "Novo";
            adicionarServicoButton.Location = new Point(270, 10);
            adicionarServicoButton.BackColor = Color.Snow;
            adicionarServicoButton.Click += new EventHandler(adicionarServicoButton_Click);

            atualizarServicoButton.Text = "Editar";
            atualizarServicoButton.Location = new Point(350, 10);
            atualizarServicoButton.BackColor = Color.Snow;
            atualizarServicoButton.Click += new EventHandler(atualizarServicoButton_Click);

            deletarServicoButton.Text = "Excluir";
            deletarServicoButton.Location = new Point(430, 10);
            deletarServicoButton.BackColor = Color.Snow;
            deletarServicoButton.Click += new EventHandler(deletarServicoButton_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(510, 10);
            voltarButton.BackColor = Color.Snow;
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(adicionarServicoButton);
            buttonPanel.Controls.Add(atualizarServicoButton);
            buttonPanel.Controls.Add(deletarServicoButton);
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
            this.Controls.Add(servicoGridView);

            servicoGridView.ColumnCount = 3;

            servicoGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            servicoGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            servicoGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(servicoGridView.Font, FontStyle.Bold);

            servicoGridView.Name = "servicoGridView";
            servicoGridView.Location = new Point(8, 8);
            servicoGridView.Size = new Size(600, 400);
            servicoGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            servicoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            servicoGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            servicoGridView.GridColor = Color.Black;
            servicoGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;

            servicoGridView.RowHeadersVisible = false;

            servicoGridView.Columns[0].Name = "Id";
            servicoGridView.Columns[0].Width = 115;
            servicoGridView.Columns[1].Name = "Tipo do Serviço";
            servicoGridView.Columns[1].Width = 420;
            servicoGridView.Columns[2].Name = "Preço do Serviço";
            servicoGridView.Columns[2].Width = 260;

            servicoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            servicoGridView.MultiSelect = false;
            servicoGridView.Dock = DockStyle.Fill;

            servicoGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(servicoGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            servicoGridView.Rows.Clear();

            IEnumerable<Carteira_De_Clientes.Models.Servico> collectionServicos = Carteira_De_Clientes.Controllers.Servico.GetAllServicos();

            if (collectionServicos != null && collectionServicos.Count() > 0)
            {
                foreach (var item in collectionServicos)
                {
                    string[] linhaServico = { item.Id.ToString(), item.Nome, item.PrecoServico };

                    servicoGridView.Rows.Add(linhaServico);
                }
            }
        }

        private void adicionarServicoButton_Click(object sender, EventArgs e)
        {
            Servico telaServico = new Servico(null);
            telaServico.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaServico.ShowDialog();
        }

        private void atualizarServicoButton_Click(object sender, EventArgs e)
        {
            if (this.servicoGridView.SelectedRows.Count > 0 &&
                this.servicoGridView.SelectedRows[0].Index !=
                this.servicoGridView.Rows.Count - 1)
            {
                string idServicoSelecionado = servicoGridView.Rows[this.servicoGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                Servico telaServico = new Servico(Int32.Parse(idServicoSelecionado));
                
                if (telaServico != null)
                {
                    telaServico.AlterarVisibilidadeId(true);
                    telaServico.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                    telaServico.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Nenhum serviço foi selecionado!");
            }
        }

        private void deletarServicoButton_Click(object sender, EventArgs e)
        {
            if (this.servicoGridView.SelectedRows.Count > 0 &&
                this.servicoGridView.SelectedRows[0].Index !=
                this.servicoGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir o Serviço?", "Exclusão de Serviço", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idServico = servicoGridView.Rows[this.servicoGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Carteira_De_Clientes.Controllers.Servico.ExcluirServico(idServico);
                    MessageBox.Show("Serviço excluído com sucesso!");
                    PopulateDataGridView();
                    this.servicoGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }

            }
            else
            {
                MessageBox.Show("Nenhum serviço foi selecionado!");
            }
        }

        private void recarregarDadosGrid(object sender, FormClosedEventArgs e)
        {
            PopulateDataGridView();
            this.servicoGridView.Refresh();
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}