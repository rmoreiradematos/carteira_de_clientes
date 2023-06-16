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

            new Botoes(labels, 5, this, true);

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

        private void btnExcluir_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAlterar_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCadastrar_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            dataGridViewCliente.Visible = false;
            dataGridViewOrdemServico.Visible = false;
            if (chart != null)
            {
                chart.Visible = false;
            }
            dataGridViewFuncionario.Visible = !dataGridViewFuncionario.Visible;

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

        private void btnCliente_Click(object sender, EventArgs e)
        {
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
            series.ChartType = SeriesChartType.Pie;

            // Adiciona os pontos ao gráfico
            series.Points.AddXY("Serviços ", 20);
            series.Points.AddXY("Categoria 2", 30);
            series.Points.AddXY("Categoria 3", 15);
            series.Points.AddXY("Categoria 4", 35);

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