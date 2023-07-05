using System;
using System.Drawing;
using System.Windows.Forms;
using Banco;
using View;

namespace Carteira_De_Clientes
{
    public class Menu : Form
    {
        private PictureBox picboxPremyer;
        private PictureBox picboxTabela;
        private bool isActiveBtnFuncionario = false;
        private bool isActiveBtnCliente = false;
        private bool isActiveBtnGrafico = false;
        private bool isActiveBtnOrdemServico = false;
        private Panel contentPanel;

        public Menu()
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
            labels.Add("SERVIÇO", btnServico_Click);
            labels.Add("ORDEM DE SERVIÇO", btnOrdemServico_Click);
            labels.Add("GRAFICOS", btnGrafico_Click);
            labels.Add("SAIR", btnSair_Click);

            new Botoes(labels, 6, this, 15, 350, true);

            //PictureBox Premyer
            picboxPremyer = new PictureBox();
            picboxPremyer.Location = new System.Drawing.Point(15, 1);
            picboxPremyer.Size = new System.Drawing.Size(350, 300);
            picboxPremyer.Image = Image.FromFile(@"Views\assets\Premyer.png");
            picboxPremyer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picboxPremyer);


            //PictureBox Tabela
            picboxTabela = new PictureBox();
            picboxTabela.Location = new System.Drawing.Point(380, 0);
            picboxTabela.Size = new System.Drawing.Size(1550, 1080);
            picboxTabela.Image = Image.FromFile(@"Views\assets\Tabela.png");
            picboxTabela.SizeMode = PictureBoxSizeMode.StretchImage;
            picboxTabela.SendToBack();
            // lblBemVindo = new Label();
            // lblBemVindo.Location = new System.Drawing.Point(900, 500);
            // lblBemVindo.Text = "Seja bem vindo!";
            // lblBemVindo.AutoSize = true;
            // lblBemVindo.Font = new Font(lblBemVindo.Font.FontFamily, 50, FontStyle.Bold);
            //this.Controls.Add(lblBemVindo);
            this.Controls.Add(picboxTabela);


            contentPanel = new Panel();
            contentPanel.Size = new Size(800, 600);
            contentPanel.Location = new Point(700, 350);
            contentPanel.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(contentPanel);



        }

        private void btnServico_Click(object? sender, EventArgs e)
        {
            this.contentPanel.BringToFront();
            this.contentPanel.Controls.Clear();

            ListaServico listaServicoForm = new ListaServico();
            this.contentPanel.Controls.Add(listaServicoForm);
            listaServicoForm.Show();


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

        private void btnFuncionario_Click(object sender, EventArgs e)
        {

            this.contentPanel.BringToFront();
            this.contentPanel.Controls.Clear();

            ListaFuncionario listaFuncionarioForms = new ListaFuncionario();
            listaFuncionarioForms.StartPosition = FormStartPosition.CenterScreen;
            listaFuncionarioForms.FormBorderStyle = FormBorderStyle.None;
            listaFuncionarioForms.WindowState = FormWindowState.Maximized;
            listaFuncionarioForms.TopLevel = false;
            listaFuncionarioForms.AutoScroll = true;
            this.contentPanel.Controls.Add(listaFuncionarioForms);
            listaFuncionarioForms.Show();

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
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.contentPanel.BringToFront();
            this.contentPanel.Controls.Clear();

            ListaCliente listaClienteForm = new ListaCliente();
            this.contentPanel.Controls.Add(listaClienteForm);
            listaClienteForm.Show();


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
                DataBase dataBase = new DataBase();
                dataBase.SaveChanges();
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