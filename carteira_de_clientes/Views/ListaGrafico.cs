using System;
using System.Drawing;
using System.Windows.Forms;
using Carteira_De_Clientes;

namespace View
{
    public class ListaGrafico : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView clienteGridView = new DataGridView();
        private Button grafico1Button = new Button();
        private Button grafico2Button = new Button();
        private Button grafico3Button = new Button();
        private Button voltarButton = new Button();

        public ListaGrafico()
        {
            this.Text = "Listagem de Cliente";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopLevel = false;
            this.AutoScroll = true;
            this.Load += new EventHandler(ListaCliente_Load);

        }

        private void ListaCliente_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            // SetupDataGridView();
            // PopulateDataGridView();
        }

        private void clienteGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.clienteGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            grafico1Button.Text = "Grafico1";
            grafico1Button.Location = new Point(270, 10);
            grafico1Button.BackColor = Color.Snow;
            grafico1Button.Click += new EventHandler(grafico1Button_Click);

            grafico2Button.Text = "Grafico2";
            grafico2Button.Location = new Point(350, 10);
            grafico2Button.BackColor = Color.Snow;
            grafico2Button.Click += new EventHandler(Grafico2Button_Click);

            grafico3Button.Text = "Grafico3";
            grafico3Button.Location = new Point(430, 10);
            grafico3Button.BackColor = Color.Snow;
            grafico3Button.Click += new EventHandler(grafico3Button_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(510, 10);
            voltarButton.BackColor = Color.Snow;
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(grafico1Button);
            buttonPanel.Controls.Add(grafico2Button);
            buttonPanel.Controls.Add(grafico3Button);
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
            this.Controls.Add(clienteGridView);

            clienteGridView.ColumnCount = 4;

            clienteGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            clienteGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            clienteGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(clienteGridView.Font, FontStyle.Bold);

            clienteGridView.Name = "clienteGridView";
            clienteGridView.Location = new Point(8, 8);
            clienteGridView.Size = new Size(600, 400);
            clienteGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            clienteGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            clienteGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            clienteGridView.GridColor = Color.Black;
            clienteGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;

            clienteGridView.RowHeadersVisible = false;

            clienteGridView.Columns[0].Name = "Id";
            clienteGridView.Columns[0].Width = 100;
            clienteGridView.Columns[1].Name = "Nome";
            clienteGridView.Columns[1].Width = 200;
            clienteGridView.Columns[2].Name = "Endereco";
            clienteGridView.Columns[2].Width = 300;
            clienteGridView.Columns[3].Name = "Telefone";
            clienteGridView.Columns[3].Width = 200;

            clienteGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clienteGridView.MultiSelect = false;
            clienteGridView.Dock = DockStyle.Fill;

            clienteGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(clienteGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            // clienteGridView.Rows.Clear();

            // IEnumerable<Carteira_De_Clientes.Models.Cliente> collectionClientes = Carteira_De_Clientes.Controllers.Cliente.GetAllClientes();

            // if (collectionClientes != null && collectionClientes.Count() > 0)
            // {
            //     foreach (var item in collectionClientes)
            //     {
            //         string[] linhaCliente = { item.Id.ToString(), item.Nome, item.Endereco, item.Telefone};

            //         clienteGridView.Rows.Add(linhaCliente);
            //     }
            // }
        }

        private void grafico1Button_Click(object sender, EventArgs e)
        {
            var pagouMasOServicoNaoFoiRealizado = Carteira_De_Clientes.Controllers.Grafico.PagouMasOServicoNaoFoiRealizado();
            //  if (this.clienteGridView.SelectedRows.Count > 0 &&
            //     this.clienteGridView.SelectedRows[0].Index !=
            //     this.clienteGridView.Rows.Count - 1)
            // {
            //     string idClienteSelecionado = clienteGridView.Rows[this.clienteGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
            //     Cliente telaCliente = new Cliente(Int32.Parse(idClienteSelecionado));

            //     if (telaCliente != null)
            //     {
            //         telaCliente.AlterarVisibilidadeId(true);
            //         telaCliente.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            //         telaCliente.ShowDialog();

            //     }
            // }
        }

        private void Grafico2Button_Click(object sender, EventArgs e)
        {
            if (this.clienteGridView.SelectedRows.Count > 0 &&
                this.clienteGridView.SelectedRows[0].Index !=
                this.clienteGridView.Rows.Count - 1)
            {
                string idClienteSelecionado = clienteGridView.Rows[this.clienteGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                Cliente telaCliente = new Cliente(Int32.Parse(idClienteSelecionado));

                if (telaCliente != null)
                {
                    telaCliente.AlterarVisibilidadeId(true);
                    telaCliente.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                    telaCliente.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Nenhum cliente foi selecionado!");
            }
        }

        private void grafico3Button_Click(object sender, EventArgs e)
        {
            if (this.clienteGridView.SelectedRows.Count > 0 &&
                this.clienteGridView.SelectedRows[0].Index !=
                this.clienteGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir o Cliente?", "Exclusão de Cliente", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idCliente = clienteGridView.Rows[this.clienteGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Carteira_De_Clientes.Controllers.Cliente.ExcluirCliente(idCliente);
                    MessageBox.Show("Cliente excluído com sucesso!");
                    PopulateDataGridView();
                    this.clienteGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }

            }
            else
            {
                MessageBox.Show("Nenhum cliente foi selecionado!");
            }
        }

        private void recarregarDadosGrid(object sender, FormClosedEventArgs e)
        {
            PopulateDataGridView();
            this.clienteGridView.Refresh();
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}