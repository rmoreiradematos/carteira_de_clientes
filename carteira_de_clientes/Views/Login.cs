namespace Carteira_De_Clientes
{

    public class Login : Form
    {
        private Button btnEntrar;
        private Button btnSenha;
        private Label lblLogin;
        private Label lblSenha;
        private TextBox txbLogin;
        private TextBox txbSenha;
        private PictureBox picboxPremyer;
        
        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {

            //Formulario Login
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(525, 600);
            this.Text = "Carteira de Clientes";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#b5bac9");;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormClosing += TelaLogin_FormClosing;


            // TextBox Login
            txbLogin = new TextBox();
            txbLogin.Location = new System.Drawing.Point(220, 310);
            txbLogin.Size = new System.Drawing.Size(150, 30);
            txbLogin.Name = "txbLogin";
            txbLogin.Focus();
            this.Controls.Add(txbLogin);


            // TextBox Senha
            txbSenha = new TextBox();
            txbSenha.Location = new System.Drawing.Point(220, 360);
            txbSenha.Size = new System.Drawing.Size(150, 30);
            txbSenha.Name = "txbSenha";
            txbSenha.UseSystemPasswordChar = true;
            this.Controls.Add(txbSenha);


            // Botao Entrar
            btnEntrar = new Button();
            btnEntrar.Location = new System.Drawing.Point(325, 500);
            btnEntrar.Size = new System.Drawing.Size(100, 30);
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += BtnEntrar_Click;
            this.Controls.Add(btnEntrar);


            // Label Login
            lblLogin = new Label();
            lblLogin.Location = new System.Drawing.Point(170, 311);
            lblLogin.Size = new System.Drawing.Size(100, 40);
            lblLogin.Font = new Font(lblLogin.Font.FontFamily, 10, FontStyle.Regular);
            lblLogin.Text = "Login:";
            this.Controls.Add(lblLogin);


            // Label Senha
            lblSenha = new Label();
            lblSenha.Location = new System.Drawing.Point(170, 361);
            lblSenha.Size = new System.Drawing.Size(100, 40);
            lblSenha.Font = new Font(lblSenha.Font.FontFamily, 10, FontStyle.Regular);
            lblSenha.Text = "Senha:";
            this.Controls.Add(lblSenha);


            // PictureBox Premyer
            picboxPremyer = new PictureBox();
            picboxPremyer.Location = new System.Drawing.Point(150, 20);
            picboxPremyer.Size = new System.Drawing.Size(250, 200);
            picboxPremyer.Image = Image.FromFile(@"Views\assets\Premyer.png");
            picboxPremyer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picboxPremyer);

        }
        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controllers.Login.GetLogin(txbLogin.Text, txbSenha.Text))
                {
                    Carteira_De_Clientes.Controllers.UserSession.UserName = txbLogin.Text;
                    Carteira_De_Clientes.Controllers.UserSession.Role = Carteira_De_Clientes.Controllers.Funcionario.GetFuncionarioByEmail(txbLogin.Text).Funcao.ToString();
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
