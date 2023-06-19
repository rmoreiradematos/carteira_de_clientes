using System;
using System.Drawing;
using System.Windows.Forms;

namespace carteira_de_clientes
{
    public partial class TelaRedefinirSenha : Form
    {
        private Label lblCpf;
        private Label lblSenha;
        private Label lblConfirmarSenha;
        private Button btnVoltar;
        private Button btnEnviar;
        private TextBox txbCpf;
        private TextBox txbSenha;
        private TextBox txbConfirmarSenha;
        private PictureBox picboxPremyer;
        private Label lblRecuperarSenha;
        private Label lblRecuperarSenha1;

        public TelaRedefinirSenha()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //FormEsqueceuSenha
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(525, 600);
            this.Text = "Carteira de Clientes";
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormClosing += TelaEsqueceuSenha_FormClosing;

            //textbox CPF
            txbCpf = new TextBox();
            txbCpf.Location = new System.Drawing.Point(215, 380);
            txbCpf.Size = new System.Drawing.Size(150, 30);
            this.Controls.Add(txbCpf);

            txbSenha = new TextBox();
            txbSenha.Location = new System.Drawing.Point(215, 410);
            txbSenha.Size = new System.Drawing.Size(150, 30);
            this.Controls.Add(txbSenha);

            txbConfirmarSenha = new TextBox();
            txbConfirmarSenha.Location = new System.Drawing.Point(215, 440);
            txbConfirmarSenha.Size = new System.Drawing.Size(150, 30);
            this.Controls.Add(txbConfirmarSenha);



            //label CPF
            lblCpf = new Label();
            lblCpf.Location = new System.Drawing.Point(175, 381);
            lblCpf.Size = new System.Drawing.Size(150, 30);
            lblCpf.Font = new Font(lblCpf.Font.FontFamily, 10, FontStyle.Regular);
            lblCpf.Text = "CPF:";
            this.Controls.Add(lblCpf);

            lblSenha = new Label();
            lblSenha.Location = new System.Drawing.Point(170, 411);
            lblSenha.Size = new System.Drawing.Size(150, 30);
            lblSenha.Font = new Font(lblSenha.Font.FontFamily, 10, FontStyle.Regular);
            lblSenha.Text = "Senha:";
            this.Controls.Add(lblSenha);

            lblConfirmarSenha = new Label();
            lblConfirmarSenha.Location = new System.Drawing.Point(120, 442);
            lblConfirmarSenha.Size = new System.Drawing.Size(150, 30);
            lblConfirmarSenha.Text = "Confirmar Senha:";
            this.Controls.Add(lblConfirmarSenha);


            Dictionary<string, EventHandler> labels = new Dictionary<string, EventHandler>();
            labels.Add("Enviar", btnEnviar_Click);
            labels.Add("Voltar", btnVoltar_Click);

            new Botoes(labels, 2, this, 75, 500, false);

            //PictureBox Premyer
            picboxPremyer = new PictureBox();
            picboxPremyer.Location = new System.Drawing.Point(150, 20);
            picboxPremyer.Size = new System.Drawing.Size(250, 200);
            picboxPremyer.Image = Image.FromFile(@"Views\assets\Premyer.png");
            picboxPremyer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picboxPremyer);


            //lblRecuperarSenha1
            lblRecuperarSenha1 = new Label();
            lblRecuperarSenha1.Location = new System.Drawing.Point(120, 260);
            lblRecuperarSenha1.Font = new Font(lblRecuperarSenha1.Font.FontFamily, 10, FontStyle.Regular);
            lblRecuperarSenha1.Size = new System.Drawing.Size(300, 100);
            lblRecuperarSenha1.ForeColor = Color.White;
            lblRecuperarSenha1.TextAlign = ContentAlignment.MiddleCenter;
            lblRecuperarSenha1.BackColor = Color.Gray;
            lblRecuperarSenha1.Text = "Redefina sua SENHA!";
            this.Controls.Add(lblRecuperarSenha1);

        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();
            this.Hide();
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {

            string senha = txbSenha.Text;
            string ConfirmSenha = txbConfirmarSenha.Text;



            if (senha == null || ConfirmSenha == null)
            {
                if (senha == ConfirmSenha)
                {
                    if (senha.Length >= 8 && senha.All(char.IsDigit))
                    {
                        MessageBox.Show("Senha alterada com Sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TelaLogin telaLogin = new TelaLogin();
                        telaLogin.Show();
                        this.Hide();
                    }

                }
            }

            else
            {
                MessageBox.Show("As senhas não coincidem, ou devem conter mais que 8 digitos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void TelaEsqueceuSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}