using System;
using System.Drawing;
using System.Windows.Forms;
using Carteira_De_Clientes;

namespace View
{
    public class ListaFuncionario : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView funcionarioGridView = new DataGridView();
        private Button adicionarFuncionarioButton = new Button();
        private Button atualizarFuncionarioButton = new Button();
        private Button deletarFuncionarioButton = new Button();
        private Button voltarButton = new Button();

        public ListaFuncionario()
        {
            this.Text = "Listagem de Funcionario";
            this.Load += new EventHandler(ListaFuncionario_Load);
        }

        private void ListaFuncionario_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void funcionarioGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.funcionarioGridView.Columns[e.ColumnIndex].Name == "Release Date")
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



            adicionarFuncionarioButton.Text = "Novo";
            adicionarFuncionarioButton.Location = new Point(270, 10);
            adicionarFuncionarioButton.Click += new EventHandler(adicionarFuncionarioButton_Click);
            adicionarFuncionarioButton.BackColor = Color.Snow;

            atualizarFuncionarioButton.Text = "Editar";
            atualizarFuncionarioButton.Location = new Point(350, 10);
            atualizarFuncionarioButton.Click += new EventHandler(atualizarFuncionarioButton_Click);
            atualizarFuncionarioButton.BackColor = Color.Snow;

            deletarFuncionarioButton.Text = "Excluir";
            deletarFuncionarioButton.Location = new Point(430, 10);
            deletarFuncionarioButton.Click += new EventHandler(deletarFuncionarioButton_Click);
            deletarFuncionarioButton.BackColor = Color.Snow;
            
            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(510, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);
            voltarButton.BackColor = Color.Snow;
            
            buttonPanel.Controls.Add(adicionarFuncionarioButton);
            buttonPanel.Controls.Add(atualizarFuncionarioButton);
            buttonPanel.Controls.Add(deletarFuncionarioButton);
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
            this.Controls.Add(funcionarioGridView);

            funcionarioGridView.ColumnCount = 5;

            funcionarioGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            funcionarioGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightGreen;
            funcionarioGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            funcionarioGridView.Name = "funcionarioGridView";
            funcionarioGridView.Location = new Point(8, 8);
            funcionarioGridView.Size = new Size(500, 250);
            funcionarioGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            funcionarioGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            funcionarioGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            funcionarioGridView.GridColor = Color.Black;
            funcionarioGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;
            funcionarioGridView.RowHeadersVisible = false;

            funcionarioGridView.Columns[0].Name = "Id";
            funcionarioGridView.Columns[0].Width = 50;
            funcionarioGridView.Columns[1].Name = "Nome";
            funcionarioGridView.Columns[1].Width = 200;
            funcionarioGridView.Columns[2].Name = "Acesso";
            funcionarioGridView.Columns[2].Width = 100;
            funcionarioGridView.Columns[3].Name = "Email";
            funcionarioGridView.Columns[3].Width = 300;
            funcionarioGridView.Columns[4].Name = "Salario";
            funcionarioGridView.Columns[4].Width = 150;
            funcionarioGridView.Columns[4].DefaultCellStyle.Font =
            new Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            funcionarioGridView.AllowUserToResizeColumns = false;
            funcionarioGridView.AllowUserToResizeRows = false;

            funcionarioGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            funcionarioGridView.MultiSelect = false;
            funcionarioGridView.Dock = DockStyle.Fill;

            funcionarioGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                funcionarioGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {

            funcionarioGridView.Rows.Clear();

            IEnumerable<Carteira_De_Clientes.Models.Funcionario> collectionFuncionarios = Carteira_De_Clientes.Controllers.Funcionario.GetAllFuncionarios();

            if (collectionFuncionarios != null && collectionFuncionarios.Count() > 0)
            {
                foreach (var item in collectionFuncionarios)
                {

                    string[] linhaFuncionario = { item.Id.ToString(), item.Nome, item.Role.ToString(), item.Email, item.Salario.ToString() };

                    funcionarioGridView.Rows.Add(linhaFuncionario);
                }
            }
        }

        private void adicionarFuncionarioButton_Click(object sender, EventArgs e)
        {

            Funcionario telaFuncionario = new Funcionario(null);
            telaFuncionario.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaFuncionario.ShowDialog();
        }

        private void atualizarFuncionarioButton_Click(object sender, EventArgs e)
        {
            if (this.funcionarioGridView.SelectedRows.Count > 0 &&
                            this.funcionarioGridView.SelectedRows[0].Index !=
                            this.funcionarioGridView.Rows.Count - 1)
            {
                string idClienteSelecionado = funcionarioGridView.Rows[this.funcionarioGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                Funcionario telaFuncionario = new Funcionario(Int32.Parse(idClienteSelecionado));
                telaFuncionario.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaFuncionario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum cliente foi selecionado!");
            }
        }

        private void deletarFuncionarioButton_Click(object sender, EventArgs e)
        {
            if (this.funcionarioGridView.SelectedRows.Count > 0 &&
                this.funcionarioGridView.SelectedRows[0].Index !=
                this.funcionarioGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir o item?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idFuncionario = funcionarioGridView.Rows[this.funcionarioGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Carteira_De_Clientes.Controllers.Funcionario.ExcluirFuncionario(idFuncionario);
                    MessageBox.Show("Funcionario excluído com sucesso!");
                    PopulateDataGridView();
                    this.funcionarioGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }

            }
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void recarregarDadosGrid(object sender, FormClosedEventArgs e)
        {
            PopulateDataGridView();
            this.funcionarioGridView.Refresh();
        }
    }

}