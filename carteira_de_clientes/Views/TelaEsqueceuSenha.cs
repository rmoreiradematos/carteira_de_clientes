using System;
using System.Drawing;
using System.Windows.Forms;

namespace carteira_de_clientes
{
    public partial class TelaEsqueceuSenha : Form
    {
        private Label lblCpf;
        private Button btnVoltar;
        private Button btnEnviar;
        private TextBox txbCpf;
        private PictureBox picboxPremyer;
        private Label lblRecuperarSenha;
        private Label lblRecuperarSenha1;

        public TelaEsqueceuSenha()
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



            //label CPF
            lblCpf = new Label();
            lblCpf.Location = new System.Drawing.Point(175, 381);
            lblCpf.Size = new System.Drawing.Size(150, 30);
            lblCpf.Font = new Font(lblCpf.Font.FontFamily, 10, FontStyle.Regular);
            lblCpf.Text = "CPF:";
            this.Controls.Add(lblCpf);

            //button Enviar
            // btnEnviar = new Button();
            // btnEnviar.Text = "Enviar";
            // btnEnviar.Location = new System.Drawing.Point(325, 500);
            // btnEnviar.Size = new System.Drawing.Size(75, 23);
            // btnEnviar.UseVisualStyleBackColor = true;
            // btnEnviar.Click += btnEnviar_Click;
            // this.Controls.Add(btnEnviar);

            // //button Voltar
            // btnVoltar = new Button();
            // btnVoltar.Text = "Voltar";
            // btnVoltar.Location = new System.Drawing.Point(150, 500);
            // btnVoltar.Size = new System.Drawing.Size(75, 23);
            // btnVoltar.UseVisualStyleBackColor = true;
            // btnVoltar.Click += btnVoltar_Click;
            // this.Controls.Add(btnVoltar);
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

            //lblRecuperarSenha
            lblRecuperarSenha = new Label();
            lblRecuperarSenha.Location = new System.Drawing.Point(210, 240);
            lblRecuperarSenha.Size = new System.Drawing.Size(350, 30);
            lblRecuperarSenha.Text = "Recuperar senha";
            lblRecuperarSenha.ForeColor = Color.Blue;
            lblRecuperarSenha.Font = new Font(lblRecuperarSenha.Font.FontFamily, 10, FontStyle.Regular);
            //this.Controls.Add(lblRecuperarSenha);

            //lblRecuperarSenha1
            lblRecuperarSenha1 = new Label();
            lblRecuperarSenha1.Location = new System.Drawing.Point(120, 260);
            lblRecuperarSenha1.Font = new Font(lblRecuperarSenha1.Font.FontFamily, 10, FontStyle.Regular);
            lblRecuperarSenha1.Size = new System.Drawing.Size(300, 100);
            lblRecuperarSenha1.ForeColor = Color.White;
            lblRecuperarSenha1.TextAlign = ContentAlignment.MiddleCenter;
            lblRecuperarSenha1.BackColor = Color.Gray;
            lblRecuperarSenha1.Text = "Para recuperar sua senha, informe seu CPF para a alteração da senha.";
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

            string cpf = txbCpf.Text;

            // Verifica se o CPF possui 11 dígitos numéricos
            if (cpf.Length == 11 && cpf.All(char.IsDigit))
            {
                MessageBox.Show("CPF validado com SUCESSO!\n\nRedefina sua senha!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TelaRedefinirSenha telaRedefinirSenha = new TelaRedefinirSenha();
                telaRedefinirSenha.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Verifique seu CPF se está correto,\n Deve conter APENAS numeros!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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