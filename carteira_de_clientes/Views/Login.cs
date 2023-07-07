
using System.Windows.Forms;

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

        private PictureBox picboxLogin; 

        private PictureBox picboxSenha;
        
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
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
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
            Panel panelLogin = new Panel();
            panelLogin.Location = new System.Drawing.Point(170, 311);
            panelLogin.Size = new System.Drawing.Size(200, 40);
            this.Controls.Add(panelLogin);

            PictureBox picboxLogin = new PictureBox();
            picboxLogin.Location = new System.Drawing.Point(0, 0);
            picboxLogin.Size = new System.Drawing.Size(28, 22);
            picboxLogin.Image = Image.FromFile(@"Views\assets\perfil.png");
            picboxLogin.SizeMode = PictureBoxSizeMode.StretchImage;
            panelLogin.Controls.Add(picboxLogin);

            Label lblLogin = new Label();
            lblLogin.Location = new System.Drawing.Point(35, 0);
            lblLogin.Size = new System.Drawing.Size(100, 24);
            lblLogin.Font = new Font(lblLogin.Font.FontFamily, 10, FontStyle.Regular);
            lblLogin.Text = " ";
            panelLogin.Controls.Add(lblLogin);

            // Label Senha

            Panel panelSenha = new Panel();
            panelSenha.Location = new System.Drawing.Point(170, 361);
            panelSenha.Size = new System.Drawing.Size(200, 40);
            this.Controls.Add(panelSenha);

            PictureBox picboxSenha = new PictureBox();
            picboxSenha.Location = new System.Drawing.Point(0, 0);
            picboxSenha.Size = new System.Drawing.Size(28, 22);
            picboxSenha.Image = Image.FromFile(@"Views\assets\senha.png");
            picboxSenha.SizeMode = PictureBoxSizeMode.StretchImage;
            panelSenha.Controls.Add(picboxSenha);

            Label lblSenha = new Label();
            lblSenha.Location = new System.Drawing.Point(35, 0);
            lblSenha.Size = new System.Drawing.Size(100, 24);
            lblSenha.Font = new Font(lblSenha.Font.FontFamily, 10, FontStyle.Regular);
            lblSenha.Text = " ";
            panelSenha.Controls.Add(lblSenha);


            
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
