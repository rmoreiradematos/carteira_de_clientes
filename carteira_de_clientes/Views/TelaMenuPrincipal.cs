using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace carteira_de_clientes
{
    public partial class TelaMenuPrincipal : Form
    {
        private PictureBox picboxPremyer;
        private PictureBox picboxTabela;
        private DataGridView dataGridViewFuncionario;
        private DataGridView dataGridViewCliente;
        private DataGridView dataGridViewOrdemServico;
        private Label lblBemVindo;
        private Chart chart;
        private bool isActiveBtnFuncionario = false;
        private bool isActiveBtnCliente = false;
        private bool isActiveBtnGrafico = false;
        private bool isActiveBtnOrdemServico = false;
        private Button btnGrafico;


        //Funcionario
        public Label lblNomeFuncionario;
        public Label lblCpfFuncionario;
        public Label lblSenhaFuncionario;
        public Label lblAdminFuncionario;
        public Label lblUsuarioFuncionario;
        public TextBox txbNomeFuncionario;
        public TextBox txbCpfFuncionario;
        public TextBox txbSenhaFuncionario;
        public CheckBox cbAdminFuncionario;
        public CheckBox cbUsuarioFuncionario;
        public Button btnShowSenhaFuncionario;



        //Clientes
        public Label lblNomeCliente;
        public Label lblEnderecoCliente;
        public Label lblTelefoneCliente;
        public TextBox txbNomeCliente;
        public TextBox txbEnderecoCliente;
        public TextBox txbTelefoneCliente;


        //Ordem de Servico
        public Label lblNomeOrdemServico;
        public Label lblPrecoOrdemServico;
        public Label lblDoneOrdemServico;



        public TelaMenuPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {

            //TelaMenuPrincipal
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Carteira de Clientes";
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += TelaLogin_FormClosing;

            Dictionary<string, EventHandler> labels = new Dictionary<string, EventHandler>();
            labels.Add("FUNCIONARIOS", btnFuncionario_Click);
            labels.Add("CLIENTES", btnCliente_Click);
            labels.Add("GRAFICOS", btnGrafico_Click);
            labels.Add("ORDEM DE SERVIÇO", btnOrdemServico_Click);
            labels.Add("SAIR", btnSair_Click);

            new Botoes(labels, 5, this, 15, 350, true);



            //Label Funcionario
            lblNomeFuncionario = new Label();
            lblNomeFuncionario.Location = new System.Drawing.Point(700, 700);
            lblNomeFuncionario.Text = "Nome: ";
            lblNomeFuncionario.Size = new System.Drawing.Size(50, 20);
            lblNomeFuncionario.Font = new Font(lblNomeFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            lblNomeFuncionario.Visible = false;
            lblNomeFuncionario.BringToFront();
            this.Controls.Add(lblNomeFuncionario);

            lblSenhaFuncionario = new Label();
            lblSenhaFuncionario.Location = new System.Drawing.Point(700, 730);
            lblSenhaFuncionario.Size = new System.Drawing.Size(50, 20);
            lblSenhaFuncionario.Text = "Senha: ";
            lblSenhaFuncionario.Font = new Font(lblSenhaFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            lblSenhaFuncionario.Visible = false;
            lblSenhaFuncionario.BringToFront();
            this.Controls.Add(lblSenhaFuncionario);

            lblAdminFuncionario = new Label();
            lblAdminFuncionario.Location = new System.Drawing.Point(715, 760);
            lblAdminFuncionario.Size = new System.Drawing.Size(50, 20);
            lblAdminFuncionario.Text = "Admin";
            lblAdminFuncionario.Font = new Font(lblAdminFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            lblAdminFuncionario.Visible = false;
            lblAdminFuncionario.BringToFront();
            this.Controls.Add(lblAdminFuncionario);

            lblUsuarioFuncionario = new Label();
            lblUsuarioFuncionario.Location = new System.Drawing.Point(715, 790);
            lblUsuarioFuncionario.Size = new System.Drawing.Size(60, 20);
            lblUsuarioFuncionario.Text = "Usuario";
            lblUsuarioFuncionario.Font = new Font(lblUsuarioFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            lblUsuarioFuncionario.Visible = false;
            lblUsuarioFuncionario.BringToFront();
            this.Controls.Add(lblUsuarioFuncionario);

            lblCpfFuncionario = new Label();
            lblCpfFuncionario.Location = new System.Drawing.Point(700, 760);
            lblCpfFuncionario.Size = new System.Drawing.Size(50, 20);
            lblCpfFuncionario.Text = "CPF: ";
            lblCpfFuncionario.Font = new Font(lblCpfFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            lblCpfFuncionario.Visible = false;
            lblCpfFuncionario.BringToFront();
            this.Controls.Add(lblCpfFuncionario);


            //Botao ShowSenhaFuncionario para mostrar a senha
            btnShowSenhaFuncionario = new Button();
            btnShowSenhaFuncionario.Location = new System.Drawing.Point(810, 788);
            btnShowSenhaFuncionario.Size = new System.Drawing.Size(140, 27);
            btnShowSenhaFuncionario.Text = "Mostrar senha";
            btnShowSenhaFuncionario.Font = new Font(btnShowSenhaFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            btnShowSenhaFuncionario.BringToFront();
            btnShowSenhaFuncionario.Click += new EventHandler(btnShowSenhaFuncionario_Click);
            btnShowSenhaFuncionario.Visible = false;
            this.Controls.Add(btnShowSenhaFuncionario);


            //CheckBox Funcionario
            cbAdminFuncionario = new CheckBox();
            cbAdminFuncionario.Location = new System.Drawing.Point(700, 790);
            cbAdminFuncionario.Size = new System.Drawing.Size(90, 20);
            cbAdminFuncionario.Font = new Font(cbAdminFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            cbAdminFuncionario.Text = "ADMIN";
            cbAdminFuncionario.Visible = false;
            cbAdminFuncionario.BringToFront();
            this.Controls.Add(cbAdminFuncionario);

            cbUsuarioFuncionario = new CheckBox();
            cbUsuarioFuncionario.Location = new System.Drawing.Point(700, 815);
            cbUsuarioFuncionario.Size = new System.Drawing.Size(90, 20);
            cbUsuarioFuncionario.Text = "USUARIO";
            cbUsuarioFuncionario.Font = new Font(cbUsuarioFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            cbUsuarioFuncionario.Visible = false;
            cbUsuarioFuncionario.BringToFront();
            this.Controls.Add(cbUsuarioFuncionario);



            //TextBox Funcionario
            txbNomeFuncionario = new TextBox();
            txbNomeFuncionario.Location = new System.Drawing.Point(750, 698);
            txbNomeFuncionario.Size = new System.Drawing.Size(200, 20);
            txbNomeFuncionario.Font = new Font(txbNomeFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            txbNomeFuncionario.Visible = false;
            txbNomeFuncionario.BringToFront();
            this.Controls.Add(txbNomeFuncionario);

            txbSenhaFuncionario = new TextBox();
            txbSenhaFuncionario.Location = new System.Drawing.Point(750, 728);
            txbSenhaFuncionario.Size = new System.Drawing.Size(200, 20);
            txbSenhaFuncionario.Font = new Font(txbSenhaFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            txbSenhaFuncionario.UseSystemPasswordChar = true;
            txbSenhaFuncionario.Visible = false;
            txbSenhaFuncionario.BringToFront();
            this.Controls.Add(txbSenhaFuncionario);

            txbCpfFuncionario = new TextBox();
            txbCpfFuncionario.Location = new System.Drawing.Point(750, 758);
            txbCpfFuncionario.Size = new System.Drawing.Size(200, 20);
            txbCpfFuncionario.Font = new Font(txbCpfFuncionario.Font.FontFamily, 10, FontStyle.Regular);
            txbCpfFuncionario.Visible = false;
            txbCpfFuncionario.BringToFront();
            this.Controls.Add(txbCpfFuncionario);


            //Label Cliente
            lblNomeCliente = new Label();
            lblNomeCliente.Location = new System.Drawing.Point(700, 700);
            lblNomeCliente.Text = "Nome: ";
            lblNomeCliente.Size = new System.Drawing.Size(68, 20);
            lblNomeCliente.Font = new Font(lblNomeCliente.Font.FontFamily, 10, FontStyle.Regular);
            lblNomeCliente.Visible = false;
            lblNomeCliente.BringToFront();
            this.Controls.Add(lblNomeCliente);

            lblEnderecoCliente = new Label();
            lblEnderecoCliente.Location = new System.Drawing.Point(700, 730);
            lblEnderecoCliente.Size = new System.Drawing.Size(68, 20);
            lblEnderecoCliente.Text = "Endereco: ";
            lblEnderecoCliente.Font = new Font(lblEnderecoCliente.Font.FontFamily, 10, FontStyle.Regular);
            lblEnderecoCliente.Visible = false;
            lblEnderecoCliente.BringToFront();
            this.Controls.Add(lblEnderecoCliente);

            lblTelefoneCliente = new Label();
            lblTelefoneCliente.Location = new System.Drawing.Point(700, 760);
            lblTelefoneCliente.Size = new System.Drawing.Size(68, 20);
            lblTelefoneCliente.Text = "Telefone: ";
            lblTelefoneCliente.Font = new Font(lblTelefoneCliente.Font.FontFamily, 10, FontStyle.Regular);
            lblTelefoneCliente.Visible = false;
            lblTelefoneCliente.BringToFront();
            this.Controls.Add(lblTelefoneCliente);


            //TextBox Cliente
            txbNomeCliente = new TextBox();
            txbNomeCliente.Location = new System.Drawing.Point(770, 698);
            txbNomeCliente.Size = new System.Drawing.Size(200, 20);
            txbNomeCliente.Font = new Font(txbNomeCliente.Font.FontFamily, 10, FontStyle.Regular);
            txbNomeCliente.Visible = false;
            txbNomeCliente.BringToFront();
            this.Controls.Add(txbNomeCliente);

            txbEnderecoCliente = new TextBox();
            txbEnderecoCliente.Location = new System.Drawing.Point(770, 728);
            txbEnderecoCliente.Size = new System.Drawing.Size(200, 20);
            txbEnderecoCliente.Font = new Font(txbEnderecoCliente.Font.FontFamily, 10, FontStyle.Regular);
            txbEnderecoCliente.Visible = false;
            txbEnderecoCliente.BringToFront();
            this.Controls.Add(txbEnderecoCliente);

            txbTelefoneCliente = new TextBox();
            txbTelefoneCliente.Location = new System.Drawing.Point(770, 758);
            txbTelefoneCliente.Size = new System.Drawing.Size(200, 20);
            txbTelefoneCliente.Font = new Font(txbTelefoneCliente.Font.FontFamily, 10, FontStyle.Regular);
            txbTelefoneCliente.Visible = false;
            txbTelefoneCliente.BringToFront();
            this.Controls.Add(txbTelefoneCliente);







            //PictureBox Premyer
            picboxPremyer = new PictureBox();
            picboxPremyer.Location = new System.Drawing.Point(15, 1);
            picboxPremyer.Size = new System.Drawing.Size(350, 300);
            picboxPremyer.Image = Image.FromFile(@"Views\assets\Premyer.png");
            picboxPremyer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picboxPremyer);

            //dataGridView
            dataGridViewFuncionario = new DataGridView();
            dataGridViewFuncionario.Location = new System.Drawing.Point(400, 20);
            dataGridViewFuncionario.Size = new System.Drawing.Size(1500, 600);
            dataGridViewFuncionario.Columns.Add("ID", "ID");
            dataGridViewFuncionario.Columns[0].Width = 77;
            dataGridViewFuncionario.Columns.Add("NOME", "NOME");
            dataGridViewFuncionario.Columns[1].Width = 400;
            dataGridViewFuncionario.Columns.Add("FUNÇÃO", "FUNÇÃO");
            dataGridViewFuncionario.Columns[2].Width = 450;
            dataGridViewFuncionario.Columns.Add("TIPO", "TIPO");
            dataGridViewFuncionario.Columns[3].Width = 450;
            dataGridViewFuncionario.Columns.Add("ACESSO", "ACESSO");
            dataGridViewFuncionario.Columns[4].Width = 80;
            dataGridViewFuncionario.AllowUserToResizeColumns = false;
            dataGridViewFuncionario.AllowUserToResizeRows = false;
            dataGridViewFuncionario.Visible = false;
            this.Controls.Add(dataGridViewFuncionario);

            //dataGridViewCliente
            dataGridViewCliente = new DataGridView();
            dataGridViewCliente.Location = new System.Drawing.Point(400, 20);
            dataGridViewCliente.Size = new System.Drawing.Size(1500, 600);
            dataGridViewCliente.Columns.Add("ID", "ID");
            dataGridViewCliente.Columns[0].Width = 77;
            dataGridViewCliente.Columns.Add("NOME", "NOME");
            dataGridViewCliente.Columns[1].Width = 400;
            dataGridViewCliente.Columns.Add("ENDEREÇO", "ENDEREÇO");
            dataGridViewCliente.Columns[2].Width = 450;
            dataGridViewCliente.Columns.Add("TELEFONE", "TELEFONE");
            dataGridViewCliente.Columns[3].Width = 450;
            dataGridViewCliente.Columns.Add("ACESSO", "ACESSO");
            dataGridViewCliente.Columns[4].Width = 80;
            dataGridViewCliente.AllowUserToResizeColumns = false;
            dataGridViewCliente.AllowUserToResizeRows = false;
            dataGridViewCliente.Visible = false;
            this.Controls.Add(dataGridViewCliente);

            //dataGridViewOrdemServico
            dataGridViewOrdemServico = new DataGridView();
            dataGridViewOrdemServico.Location = new System.Drawing.Point(400, 350);
            dataGridViewOrdemServico.Size = new System.Drawing.Size(1500, 700);
            dataGridViewOrdemServico.Columns.Add("ID", "ID");
            dataGridViewOrdemServico.Columns[0].Width = 208;
            dataGridViewOrdemServico.Columns.Add("ID USUARIO", "ID USUARIO");
            dataGridViewOrdemServico.Columns[1].Width = 208;
            dataGridViewOrdemServico.Columns.Add("ID CLIENTE", "ID CLIENTE");
            dataGridViewOrdemServico.Columns[2].Width = 208;
            dataGridViewOrdemServico.Columns.Add("LIMITE DATA", "LIMITE DATA");
            dataGridViewOrdemServico.Columns[3].Width = 208;
            dataGridViewOrdemServico.Columns.Add("DATA REALIZADA", "DATA REALIZADA");
            dataGridViewOrdemServico.Columns[4].Width = 208;
            dataGridViewOrdemServico.Columns.Add("PERIODO CONTRATADO", "PERIODO CONTRATADO");
            dataGridViewOrdemServico.Columns[5].Width = 208;
            dataGridViewOrdemServico.Columns.Add("AÇÃO", "AÇÃO");
            dataGridViewOrdemServico.Columns[6].Width = 209;
            dataGridViewOrdemServico.AllowUserToResizeColumns = false;
            dataGridViewOrdemServico.AllowUserToResizeRows = false;
            dataGridViewOrdemServico.Visible = false;
            this.Controls.Add(dataGridViewOrdemServico);

            //PictureBox Tabela
            picboxTabela = new PictureBox();
            picboxTabela.Location = new System.Drawing.Point(380, 0);
            picboxTabela.Size = new System.Drawing.Size(1550, 1080);
            picboxTabela.Image = Image.FromFile(@"Views\assets\Tabela.png");
            picboxTabela.SizeMode = PictureBoxSizeMode.StretchImage;
            lblBemVindo = new Label();
            lblBemVindo.Location = new System.Drawing.Point(900, 500);
            lblBemVindo.Text = "Seja bem vindo!";
            lblBemVindo.AutoSize = true;
            lblBemVindo.Font = new Font(lblBemVindo.Font.FontFamily, 50, FontStyle.Bold);
            //this.Controls.Add(lblBemVindo);
            this.Controls.Add(picboxTabela);

        }

        private void btnShowSenhaFuncionario_Click(object sender, EventArgs e)
        {
            // Mostra A SENHA
            txbSenhaFuncionario.UseSystemPasswordChar = !txbSenhaFuncionario.UseSystemPasswordChar;
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            //Aparecer e desaparecer os Data Grid Views
            //lblAdminFuncionario.Visible = !lblAdminFuncionario.Visible;
            //lblUsuarioFuncionario.Visible = !lblUsuarioFuncionario.Visible;
            btnShowSenhaFuncionario.Visible = !btnShowSenhaFuncionario.Visible;
            lblCpfFuncionario.Visible = !lblCpfFuncionario.Visible;
            txbCpfFuncionario.Visible = !txbCpfFuncionario.Visible;
            cbAdminFuncionario.Visible = !cbAdminFuncionario.Visible;
            cbUsuarioFuncionario.Visible = !cbUsuarioFuncionario.Visible;
            lblSenhaFuncionario.Visible = !lblSenhaFuncionario.Visible;
            txbSenhaFuncionario.Visible = !txbSenhaFuncionario.Visible;
            txbNomeFuncionario.Visible = !txbNomeFuncionario.Visible;
            lblNomeFuncionario.Visible = !lblNomeFuncionario.Visible;
            dataGridViewCliente.Visible = false;
            dataGridViewOrdemServico.Visible = false;
            if (chart != null)
            {
                chart.Visible = false;
            }
            dataGridViewFuncionario.Visible = !dataGridViewFuncionario.Visible;

            //Muda a cor do botao
            Button clickedButton = (Button)sender;
            clickedButton.ForeColor = Color.Red;
            foreach (Control control in Controls)
            {
                if (control is Button button && button != clickedButton)
                {
                    button.ForeColor = Color.Black;
                }
            }

            Dictionary<string, EventHandler> labels1 = new Dictionary<string, EventHandler>();
            labels1.Add("ADICIONAR", btnAdicionar_Click);
            labels1.Add("EDITAR", btnEditar_Click);
            labels1.Add("EXCLUIR", btnExcluir_Click);
            new Botoes(labels1, 3, this, 700, 920, false);


        }

        private void btnExcluir_Click(object? sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAdicionar_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            lblNomeCliente.Visible = !lblNomeCliente.Visible;
            lblEnderecoCliente.Visible = !lblEnderecoCliente.Visible;
            lblTelefoneCliente.Visible = !lblTelefoneCliente.Visible;
            txbNomeCliente.Visible = !txbNomeCliente.Visible;
            txbEnderecoCliente.Visible = !txbEnderecoCliente.Visible;
            txbTelefoneCliente.Visible = !txbTelefoneCliente.Visible;
            dataGridViewOrdemServico.Visible = false;
            dataGridViewFuncionario.Visible = false;
            if (chart != null)
            {
                chart.Visible = false;
            }
            dataGridViewCliente.Visible = !dataGridViewCliente.Visible;

            Button clickedButton = (Button)sender;
            clickedButton.ForeColor = Color.Red;

            foreach (Control control in Controls)
            {
                if (control is Button button && button != clickedButton)
                {
                    button.ForeColor = Color.Black;
                }
            }

        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            dataGridViewCliente.Visible = false;
            dataGridViewOrdemServico.Visible = false;
            dataGridViewFuncionario.Visible = false;



            // Configuração do gráfico
            try
            {
                if (chart == null)
                {
                    chart = new Chart();
                    chart.ChartAreas.Add(new ChartArea());
                    chart.Location = new System.Drawing.Point(700, 300);
                    chart.Size = new System.Drawing.Size(800, 600);

                    // Dados do gráfico
                    Series series = new Series();
                    series.ChartType = SeriesChartType.Line;
                    series.Points.AddXY(1, 2);
                    series.Points.AddXY(2, 4);
                    series.Points.AddXY(3, 1);
                    series.Points.AddXY(4, 6);
                    series.Points.AddXY(5, 3);

                    // Adiciona a série ao gráfico
                    chart.Series.Add(series);

                    // Adiciona o gráfico ao formulário
                    this.Controls.Add(chart);
                    chart.BringToFront();
                }
                else
                {
                    chart.Visible = !chart.Visible;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }


            Button clickedButton = (Button)sender;
            clickedButton.ForeColor = Color.Red;

            foreach (Control control in Controls)
            {
                if (control is Button button && button != clickedButton)
                {
                    button.ForeColor = Color.Black;
                }
            }

        }

        private void btnOrdemServico_Click(object sender, EventArgs e)
        {
            dataGridViewFuncionario.Visible = false;
            dataGridViewCliente.Visible = false;
            if (chart != null)
            {
                chart.Visible = false;
            }
            dataGridViewOrdemServico.Visible = !dataGridViewOrdemServico.Visible;

            Button clickedButton = (Button)sender;
            clickedButton.ForeColor = Color.Red;

            // Define a cor preta para os outros botões
            foreach (Control control in Controls)
            {
                if (control is Button button && button != clickedButton)
                {
                    button.ForeColor = Color.Black;
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja salvar as alterações?", "Aviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Cancel)
            {

            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                //COLOCAR UMA LOGICA DE SALVAMENTO
                Application.Exit();
            }
        }

        private void TelaLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        public void SetActiveBtnFuncionario(bool isActive)
        {
            isActiveBtnFuncionario = isActive;
        }

        public void SetActiveBtnCliente(bool isActive)
        {
            isActiveBtnCliente = isActive;
        }

        public void SetActiveBtnGrafico(bool isActive)
        {
            isActiveBtnGrafico = isActive;
        }

        public void SetActiveBtnOrdemServico(bool isActive)
        {
            isActiveBtnOrdemServico = isActive;
        }

        public bool GetActiveBtnFuncionario()
        {
            return isActiveBtnFuncionario;
        }

        public bool GetActiveBtnCliente()
        {
            return isActiveBtnCliente;
        }

        public bool GetActiveBtnGrafico()
        {
            return isActiveBtnGrafico;
        }

        public bool GetActiveBtnOrdemServico()
        {
            return isActiveBtnOrdemServico;
        }
    }
}