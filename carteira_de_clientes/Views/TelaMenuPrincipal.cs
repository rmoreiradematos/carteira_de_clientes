using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace carteira_de_clientes
{
    public partial class TelaMenuPrincipal : Form
    {
        private Button btnFuncionario;
        private Button btnCliente;
        private Button btnGrafico;
        private Button btnOrdemServico;
        private Button btnSair;
        private PictureBox picboxPremyer;
        private PictureBox picboxTabela;
        private DataGridView dataGridViewFuncionario;
        private DataGridView dataGridViewCliente;
        private DataGridView dataGridViewOrdemServico;
        private Label lblBemVindo;
        private Chart chart1;


        public TelaMenuPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {

            // Inicialize o controle Chart
            chart1 = new Chart();
            chart1.Size = new System.Drawing.Size(650, 400);
            chart1.Location = new System.Drawing.Point(800, 400);

            // Adicione o controle Chart ao formulário
            this.Controls.Add(chart1);

            // Chame o método para preencher o gráfico com dados
            PreencherGrafico();


            //TelaMenuPrincipal
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Carteira de Clientes";
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += TelaLogin_FormClosing;


            //Botao do Funcionario
            btnFuncionario = new Button();
            btnFuncionario.Text = "FUNCIONARIOS";
            btnFuncionario.Location = new System.Drawing.Point(15, 350);
            btnFuncionario.Size = new System.Drawing.Size(350, 80);
            btnFuncionario.UseVisualStyleBackColor = true;
            btnFuncionario.Click += btnFuncionario_Click;
            btnFuncionario.Font = new Font(btnFuncionario.Font.FontFamily, 20, FontStyle.Bold);
            this.Controls.Add(btnFuncionario);

            //Botao do Cliente
            btnCliente = new Button();
            btnCliente.Text = "CLIENTES";
            btnCliente.Location = new System.Drawing.Point(15, 450);
            btnCliente.Size = new System.Drawing.Size(350, 80);
            btnCliente.UseVisualStyleBackColor = true;
            btnCliente.Click += btnCliente_Click;
            btnCliente.Font = new Font(btnCliente.Font.FontFamily, 20, FontStyle.Bold);
            this.Controls.Add(btnCliente);

            //Botao do Grafico
            btnGrafico = new Button();
            btnGrafico.Text = "GRAFICOS";
            btnGrafico.Location = new System.Drawing.Point(15, 550);
            btnGrafico.Size = new System.Drawing.Size(350, 80);
            btnGrafico.UseVisualStyleBackColor = true;
            btnGrafico.Click += btnGrafico_Click;
            btnGrafico.Font = new Font(btnGrafico.Font.FontFamily, 20, FontStyle.Bold);

            this.Controls.Add(btnGrafico);

            //Botao do Ordem Serviço
            btnOrdemServico = new Button();
            btnOrdemServico.Text = "ORDEM DE SERVIÇO";
            btnOrdemServico.Location = new System.Drawing.Point(15, 650);
            btnOrdemServico.Size = new System.Drawing.Size(350, 80);
            btnOrdemServico.UseVisualStyleBackColor = true;
            btnOrdemServico.Click += btnOrdemServico_Click;
            btnOrdemServico.Font = new Font(btnOrdemServico.Font.FontFamily, 20, FontStyle.Bold);
            this.Controls.Add(btnOrdemServico);

            //Botao do Sair
            btnSair = new Button();
            btnSair.Text = "SAIR";
            btnSair.Location = new System.Drawing.Point(15, 950);
            btnSair.Size = new System.Drawing.Size(350, 80);
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            btnSair.Font = new Font(btnSair.Font.FontFamily, 20, FontStyle.Bold);
            this.Controls.Add(btnSair);

            //PictureBox Premyer
            picboxPremyer = new PictureBox();
            picboxPremyer.Location = new System.Drawing.Point(15, 1);
            picboxPremyer.Size = new System.Drawing.Size(350, 300);
            picboxPremyer.Image = Image.FromFile(@"Views\assets\Premyer.png");
            picboxPremyer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picboxPremyer);

            //dataGridView
            dataGridViewFuncionario = new DataGridView();
            dataGridViewFuncionario.Location = new System.Drawing.Point(400, 350);
            dataGridViewFuncionario.Size = new System.Drawing.Size(1500, 700);
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
            dataGridViewCliente.Location = new System.Drawing.Point(400, 350);
            dataGridViewCliente.Size = new System.Drawing.Size(1500, 700);
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
            this.Controls.Add(lblBemVindo);
            this.Controls.Add(picboxTabela);



        }


        private void PreencherGrafico()
        {
            // Defina os dados para o gráfico
            int[] valores = { 10, 20, 30, 40, 50 };
            string[] categorias = { "Categoria 1", "Categoria 2", "Categoria 3", "Categoria 4", "Categoria 5" };

            // Limpe os pontos de dados existentes (se houver)
            chart1.Series.Clear();

            // Crie uma série para o gráfico de barras
            Series serie = chart1.Series.Add("Série 1");

            // Defina o tipo de gráfico como "Barras"
            serie.ChartType = SeriesChartType.Bar;

            // Adicione os pontos de dados ao gráfico
            for (int i = 0; i < valores.Length; i++)
            {
                serie.Points.AddXY(categorias[i], valores[i]);
            }
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            dataGridViewCliente.Visible = false;
            dataGridViewOrdemServico.Visible = false;
            dataGridViewFuncionario.Visible = !dataGridViewFuncionario.Visible;

            btnFuncionario.ForeColor = Color.Red;
            btnCliente.ForeColor = Color.Black;
            btnGrafico.ForeColor = Color.Black;
            btnOrdemServico.ForeColor = Color.Black;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            dataGridViewOrdemServico.Visible = false;
            dataGridViewFuncionario.Visible = false;
            dataGridViewCliente.Visible = !dataGridViewCliente.Visible;

            btnFuncionario.ForeColor = Color.Black;
            btnCliente.ForeColor = Color.Red;
            btnGrafico.ForeColor = Color.Black;
            btnOrdemServico.ForeColor = Color.Black;
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            dataGridViewOrdemServico.Visible = false;
            dataGridViewFuncionario.Visible = false;
            dataGridViewCliente.Visible = false;

            btnFuncionario.ForeColor = Color.Black;
            btnCliente.ForeColor = Color.Black;
            btnGrafico.ForeColor = Color.Red;
            btnOrdemServico.ForeColor = Color.Black;
        }

        private void btnOrdemServico_Click(object sender, EventArgs e)
        {
            dataGridViewFuncionario.Visible = false;
            dataGridViewCliente.Visible = false;
            dataGridViewOrdemServico.Visible = !dataGridViewOrdemServico.Visible;

            btnFuncionario.ForeColor = Color.Black;
            btnCliente.ForeColor = Color.Black;
            btnGrafico.ForeColor = Color.Black;
            btnOrdemServico.ForeColor = Color.Red;

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
    }
}