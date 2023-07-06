using System;
using System.Drawing;
using System.Windows.Forms;
using Carteira_De_Clientes;

namespace View
{
    public class ListaFuncionarioServico : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView funcionarioServicoGridView = new DataGridView();
        private Button adicionarFuncionarioServicoButton = new Button();
        private Button atualizarFuncionarioServicoButton = new Button();
        private Button deletarFuncionarioServicoButton = new Button();
        private Button voltarButton = new Button();
        PictureBox pictureBox = new PictureBox();

        public ListaFuncionarioServico()
        {
            this.Text = "Listagem de Gerenciamento de Atividades";
            this.Load += new EventHandler(listaFuncionarioServico_Load);
        }

        private void listaFuncionarioServico_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void funcionarioServicoGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.funcionarioServicoGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            adicionarFuncionarioServicoButton.Text = "Novo";
            adicionarFuncionarioServicoButton.Location = new Point(270, 10);
            adicionarFuncionarioServicoButton.BackColor = Color.Snow;
            adicionarFuncionarioServicoButton.Click += new EventHandler(adicionarFuncionarioServicoButton_Click);

            atualizarFuncionarioServicoButton.Text = "Editar";
            atualizarFuncionarioServicoButton.Location = new Point(350, 10);
            atualizarFuncionarioServicoButton.BackColor = Color.Snow;
            atualizarFuncionarioServicoButton.Click += new EventHandler(atualizarFuncionarioServicoButton_Click);

            deletarFuncionarioServicoButton.Text = "Excluir";
            deletarFuncionarioServicoButton.Location = new Point(430, 10);
            deletarFuncionarioServicoButton.BackColor = Color.Snow;
            deletarFuncionarioServicoButton.Click += new EventHandler(deletarFuncionarioServicoButton_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(510, 10);
            voltarButton.BackColor = Color.Snow;
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(adicionarFuncionarioServicoButton);
            buttonPanel.Controls.Add(atualizarFuncionarioServicoButton);
            buttonPanel.Controls.Add(deletarFuncionarioServicoButton);
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
            this.Controls.Add(funcionarioServicoGridView);

            funcionarioServicoGridView.ColumnCount = 3;

            funcionarioServicoGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            funcionarioServicoGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            funcionarioServicoGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(funcionarioServicoGridView.Font, FontStyle.Bold);

            funcionarioServicoGridView.Name = "funcionarioServicoGridView";
            funcionarioServicoGridView.Location = new Point(8, 8);
            funcionarioServicoGridView.Size = new Size(650, 400);
            funcionarioServicoGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            funcionarioServicoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            funcionarioServicoGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            funcionarioServicoGridView.GridColor = Color.Black;
            funcionarioServicoGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;

            funcionarioServicoGridView.RowHeadersVisible = false;

            funcionarioServicoGridView.Columns[0].Name = "Id";
            funcionarioServicoGridView.Columns[0].Width = 50;
            funcionarioServicoGridView.Columns[1].Name = "Funcionario";
            funcionarioServicoGridView.Columns[1].Width = 300;
            funcionarioServicoGridView.Columns[2].Name = "Serviço";
            funcionarioServicoGridView.Columns[2].Width = 445;

            funcionarioServicoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            funcionarioServicoGridView.MultiSelect = false;
            funcionarioServicoGridView.Dock = DockStyle.Fill;

            funcionarioServicoGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(funcionarioServicoGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            funcionarioServicoGridView.Rows.Clear();

            IEnumerable<Carteira_De_Clientes.Models.FuncionarioServico> collectionFuncionarioServicos = Carteira_De_Clientes.Controllers.FuncionarioServico.GetAllFuncionarioServicos();

            if (collectionFuncionarioServicos != null && collectionFuncionarioServicos.Count() > 0)
            {
                foreach (var item in collectionFuncionarioServicos)
                {
                    Carteira_De_Clientes.Models.Funcionario funcionarioFuncionarioServico = Carteira_De_Clientes.Controllers.Funcionario.GetFuncionario(item.FuncionarioId.ToString());
                    Carteira_De_Clientes.Models.Servico servicoFuncionarioServico = Carteira_De_Clientes.Controllers.Servico.GetServico(item.ServicoId.ToString());

                    string[] linhaFuncionarioServico = { item.Id.ToString(), funcionarioFuncionarioServico.Nome, servicoFuncionarioServico.Nome};


                    funcionarioServicoGridView.Rows.Add(linhaFuncionarioServico);
                }
            }
        }

        private void adicionarFuncionarioServicoButton_Click(object sender, EventArgs e)
        {
            FuncionarioServico telaFuncionarioServico = new FuncionarioServico(null);
            telaFuncionarioServico.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);            
            telaFuncionarioServico.ShowDialog();
        }

        private void atualizarFuncionarioServicoButton_Click(object sender, EventArgs e)
        {
            if (this.funcionarioServicoGridView.SelectedRows.Count > 0 &&
                this.funcionarioServicoGridView.SelectedRows[0].Index !=
                this.funcionarioServicoGridView.Rows.Count - 1)
            {
                string idFuncionarioServicoSelecionado = funcionarioServicoGridView.Rows[this.funcionarioServicoGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                FuncionarioServico telaFuncionarioServico = new FuncionarioServico(Int32.Parse(idFuncionarioServicoSelecionado));
                telaFuncionarioServico.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaFuncionarioServico.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum gerenciamento foi selecionado!");
            }
        }

        private void deletarFuncionarioServicoButton_Click(object sender, EventArgs e)
        {
            if (this.funcionarioServicoGridView.SelectedRows.Count > 0 &&
                this.funcionarioServicoGridView.SelectedRows[0].Index !=
                this.funcionarioServicoGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir o gerenciamento?", "Exclusão de gerenciamento", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idFuncionarioServico = funcionarioServicoGridView.Rows[this.funcionarioServicoGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Carteira_De_Clientes.Controllers.FuncionarioServico.ExcluirFuncionarioServico(idFuncionarioServico);
                    MessageBox.Show("Gerenciamento excluído com sucesso!");
                    PopulateDataGridView();
                    this.funcionarioServicoGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }
            }
            else
            {
                MessageBox.Show("Nenhum Gerenciamento foi selecionado!");
            }
        }

        private void recarregarDadosGrid(object sender, FormClosedEventArgs e)
        {
            PopulateDataGridView();
            this.funcionarioServicoGridView.Refresh();
        }        

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}