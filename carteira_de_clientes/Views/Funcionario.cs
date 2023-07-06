using System.Drawing;
using System.Drawing.Text;
using System.IO;
namespace View
{
    public class Funcionario : Form
    {

        Label lblId;
        TextBox txtId;
        Panel buttonPanel = new Panel();
        Label lblNome;
        TextBox txtNome;
        Label lblEmail;
        TextBox txtEmail;
        Label lblPerfil;
        ComboBox comboBoxPerfil;
        Label lblSalario;
        TextBox txtSalario;
        MaskedTextBox maskedTxtSenha;
        Label lblSenha;
        Button btnConfirmar;
        Button btnVoltar;

        public Funcionario(int? funcionarioId)
        {

            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(700, 350);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(800, 600);


            lblId = new Label();
            lblId.Text = "Id:";
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 60);

            txtId = new TextBox();
            txtId.Location = new Point(80, 60);
            txtId.Size = new Size(200, 18);
            txtId.Enabled = false;

            lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 120);

            txtNome = new TextBox();
            txtNome.Focus();
            txtNome.Location = new Point(80, 120);
            txtNome.Size = new Size(200, 18);

            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 180);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(80, 180);
            txtEmail.Size = new Size(200, 18);

            lblPerfil = new Label();
            lblPerfil.Text = "Perfil:";
            lblPerfil.AutoSize = true;
            lblPerfil.Location = new Point(20, 240);

            comboBoxPerfil = new ComboBox();
            comboBoxPerfil.Location = new Point(80, 240);
            comboBoxPerfil.Size = new Size(200, 100);
            comboBoxPerfil.TabIndex = 0;
            this.setComboBoxPerfil();
            comboBoxPerfil.Text = " ";

            lblSalario = new Label();
            lblSalario.Text = "Salário:";
            lblSalario.AutoSize = true;
            lblSalario.Location = new Point(20, 300);

            txtSalario = new TextBox();
            txtSalario.Location = new Point(80, 300);
            txtSalario.Size = new Size(200, 100);

            lblSenha = new Label();
            lblSenha.Text = "Senha:";
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(20, 360);

            maskedTxtSenha = new MaskedTextBox();
            maskedTxtSenha.Location = new Point(80, 360);
            maskedTxtSenha.Size = new Size(200, 100);
            maskedTxtSenha.ForeColor = System.Drawing.ColorTranslator.FromHtml("#748E83");

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(500, 10);
            btnVoltar.AutoSize = true;
            btnVoltar.Click += new EventHandler(voltarButton_Click);
            btnVoltar.BackColor = Color.Snow;

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(420, 10);
            btnConfirmar.AutoSize = true;
            btnConfirmar.Click += new EventHandler(adicionarFuncionarioButton_Click);
            btnConfirmar.BackColor = Color.Snow;

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            lblId.Visible = false;
            txtId.Visible = false;


            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.maskedTxtSenha);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.comboBoxPerfil);
            this.Controls.Add(this.lblSalario);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.buttonPanel);

            if (funcionarioId != null)
            {
                this.setarDadosFuncionarioEdicao(funcionarioId);
            }
        }


        public void AlterarVisibilidadeId(bool visivel)
        {
            lblId.Visible = visivel;
            txtId.Visible = visivel;
        }

        private void adicionarFuncionarioButton_Click(object sender, EventArgs e)
        {

            try
            {
                String nome = txtNome.Text;
                String email = txtEmail.Text;
                String salario = txtSalario.Text;
                String role = comboBoxPerfil.SelectedItem.ToString();

                if (this.txtId.Text != null && Int32.TryParse(this.txtId.Text, out int idFuncionario))
                {

                    Carteira_De_Clientes.Controllers.Funcionario.AlterarFuncionario(this.txtId.Text, nome, email, role, salario);
                    MessageBox.Show("Funcionario atualizado com sucesso!");
                }
                else
                {
                    Carteira_De_Clientes.Controllers.Funcionario.CadastrarFuncionario(nome, maskedTxtSenha.Text, email, role, salario);
                    MessageBox.Show("Funcionario cadastrado com sucesso!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void setComboBoxPerfil()
        {

            comboBoxPerfil.Items.Clear();

            comboBoxPerfil.Items.Add(Carteira_De_Clientes.Models.Generic.Roles.Comum);
            comboBoxPerfil.Items.Add(Carteira_De_Clientes.Models.Generic.Roles.Admin);
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setarDadosFuncionarioEdicao(int? funcionarioId)
        {
            Carteira_De_Clientes.Models.Funcionario funcionario = Carteira_De_Clientes.Controllers.Funcionario.GetFuncionario(funcionarioId.ToString());

            this.txtId.Text = funcionarioId.ToString();
            this.txtNome.Text = funcionario.Nome;
            this.txtEmail.Text = funcionario.Email;
            this.txtSalario.Text = funcionario.Salario.ToString();
            this.comboBoxPerfil.SelectedItem = funcionario.Funcao;
            this.maskedTxtSenha.Text = funcionario.Senha;
            this.maskedTxtSenha.Enabled = false;
        }

    }


}
