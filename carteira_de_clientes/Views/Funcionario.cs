using System.Drawing;
using System.Drawing.Text;
using System.IO;
namespace View
{
    public class Funcionario : Form
    {

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
        ProgressBar pbTest;

        public Funcionario(int? funcionarioId)
        {

            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(700, 350);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(800, 600);

            txtId = new TextBox();
            txtId.Location = new Point(80, 60);
            txtId.Size = new Size(100, 18);
            txtId.Enabled = false;

            lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.AutoSize = true;
            lblNome.Location = new Point(10, 10);
            lblNome.ForeColor = Color.Snow;
            lblNome.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtNome = new TextBox();
            txtNome.Location = new Point(70, 10);
            txtNome.Size = new Size(200, 100);
            txtNome.ForeColor = System.Drawing.ColorTranslator.FromHtml("#748E83");
            txtNome.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(300, 10);
            lblEmail.ForeColor = Color.Snow;
            lblEmail.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtEmail = new TextBox();
            txtEmail.Location = new Point(380, 10);
            txtEmail.Size = new Size(200, 100);
            txtEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#748E83");
            txtEmail.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblPerfil = new Label();
            lblPerfil.Text = "Perfil:";
            lblPerfil.AutoSize = true;
            lblPerfil.Location = new Point(10, 100);
            lblPerfil.ForeColor = Color.Snow;
            lblPerfil.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            comboBoxPerfil = new ComboBox();
            comboBoxPerfil.Location = new Point(70, 100);
            comboBoxPerfil.Size = new Size(200, 100);
            comboBoxPerfil.TabIndex = 0;
            this.setComboBoxPerfil();
            comboBoxPerfil.Text = " ";
            comboBoxPerfil.ForeColor = System.Drawing.ColorTranslator.FromHtml("#748E83");
            comboBoxPerfil.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblSalario = new Label();
            lblSalario.Text = "Salário:";
            lblSalario.AutoSize = true;
            lblSalario.Location = new Point(10, 190);
            lblSalario.ForeColor = Color.Snow;
            lblSalario.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtSalario = new TextBox();
            txtSalario.Location = new Point(70, 190);
            txtSalario.Size = new Size(200, 100);
            txtSalario.ForeColor = System.Drawing.ColorTranslator.FromHtml("#748E83");
            txtSalario.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblSenha = new Label();
            lblSenha.Text = "Senha:";
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(300, 190);
            lblSenha.ForeColor = Color.Snow;
            lblSenha.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            maskedTxtSenha = new MaskedTextBox();
            maskedTxtSenha.Location = new Point(380, 190);
            maskedTxtSenha.Size = new Size(200, 100);
            maskedTxtSenha.ForeColor = System.Drawing.ColorTranslator.FromHtml("#748E83");
            maskedTxtSenha.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            maskedTxtSenha.UseSystemPasswordChar = true;

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(400, 10);
            btnVoltar.AutoSize = true;
            btnVoltar.Click += new EventHandler(voltarButton_Click);
            btnVoltar.BackColor = Color.Snow;
            btnVoltar.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(490, 10);
            btnConfirmar.AutoSize = true;
            btnConfirmar.Click += new EventHandler(adicionarFuncionarioButton_Click);
            btnConfirmar.BackColor = Color.Snow;
            btnConfirmar.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

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
