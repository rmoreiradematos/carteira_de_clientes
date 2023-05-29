using System;
using System.Drawing;
using System.Windows.Forms;

namespace carteira_de_clientes
{
    public partial class TelaLogin : Form
    {
        private Button btnEntrar;
        private Button btnSenha;
        private Label lblLogin;
        private Label lblSenha;
        private TextBox txbLogin;
        private TextBox txbSenha;
        private PictureBox picboxPremyer;

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //Form1
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(525, 600);
            this.Text = "Carteira de Clientes";
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormClosing += TelaLogin_FormClosing;
            // TextBox Login
            txbLogin = new TextBox();
            txbLogin.Location = new System.Drawing.Point(200, 270);
            txbLogin.Size = new System.Drawing.Size(150, 30);
            txbLogin.Name = "txbLogin";
            txbLogin.Focus();
            this.Controls.Add(txbLogin);

            // TextBox Senha
            txbSenha = new TextBox();
            txbSenha.Location = new System.Drawing.Point(200, 370);
            txbSenha.Size = new System.Drawing.Size(150, 30);
            txbSenha.Name = "txbSenha";
            this.Controls.Add(txbSenha);

            // Botao Entrar
            btnEntrar = new Button();
            btnEntrar.Location = new System.Drawing.Point(325, 500);
            btnEntrar.Size = new System.Drawing.Size(100, 30);
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += BtnEntrar_Click;
            this.Controls.Add(btnEntrar);

            // Botao Esqueceu a Senha
            btnSenha = new Button();
            btnSenha.Location = new System.Drawing.Point(100, 500);
            btnSenha.Size = new System.Drawing.Size(120, 30);
            btnSenha.Text = "Esqueceu a senha?";
            btnSenha.UseVisualStyleBackColor = true;
            txbSenha.UseSystemPasswordChar = true;
            btnSenha.Click += BtnSenha_Click;
            this.Controls.Add(btnSenha);

            // Label Login
            lblLogin = new Label();
            lblLogin.Location = new System.Drawing.Point(150, 271);
            lblLogin.Size = new System.Drawing.Size(100, 40);
            lblLogin.Text = "Login:";
            this.Controls.Add(lblLogin);

            // Label Senha
            lblSenha = new Label();
            lblSenha.Location = new System.Drawing.Point(150, 371);
            lblSenha.Size = new System.Drawing.Size(100, 40);
            lblSenha.Text = "Senha:";
            this.Controls.Add(lblSenha);

            // PictureBox Premyer
            picboxPremyer = new PictureBox();
            picboxPremyer.Location = new System.Drawing.Point(150, 20);
            picboxPremyer.Size = new System.Drawing.Size(250, 200);
            picboxPremyer.Image = Image.FromFile(@"C:\Users\vitor\Desktop\Img\Premyer.png");
            picboxPremyer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picboxPremyer);
        }

        private void BtnSenha_Click(object sender, EventArgs e)
        {
            TelaEsqueceuSenha telaEsqueceuSenha = new TelaEsqueceuSenha();
            telaEsqueceuSenha.Show();
            this.Hide();
        }
        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal();
            telaMenuPrincipal.Show();
            this.Hide();
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