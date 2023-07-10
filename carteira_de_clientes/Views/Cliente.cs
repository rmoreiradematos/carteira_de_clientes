
using System.Linq;

namespace View
{
    public class Cliente : Form
    {

        Panel buttonPanel = new Panel();
        Label lblId;
        Label lblNome;
        Label lblEmail;
        Label lblTelefone;
        Label lblEndereco;


        TextBox txtId;
        TextBox txtNome;
        TextBox txtEmail;
        TextBox txtTelefone;
        TextBox txtEndereco;

        Button btnConfirmar;
        Button btnVoltar;



        public Cliente(int? clienteId)
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
            txtNome.Location = new Point(80, 120);
            txtNome.Size = new Size(200, 18);

            lblEndereco = new Label();
            lblEndereco.Text = "Endereco:";
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(20, 180);

            txtEndereco = new TextBox();
            txtEndereco.Location = new Point(80, 180);
            txtEndereco.Size = new Size(200, 18);

            lblTelefone = new Label();
            lblTelefone.Text = "Telefone:";
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(20, 240);

            txtTelefone = new TextBox();
            txtTelefone.Location = new Point(80, 240);
            txtTelefone.Size = new Size(200, 18);

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.BackColor = Color.Snow;
            btnConfirmar.Location = new Point(420, 10);
            btnConfirmar.Click += new EventHandler(confirmarClienteButton_Click);

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.BackColor = Color.Snow;
            btnVoltar.Location = new Point(500, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            lblId.Visible = false;
            txtId.Visible = false;


            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.buttonPanel);

            if (clienteId != null)
            {
                this.setarDadosClienteEdicao(clienteId);
            }
        }


        public void AlterarVisibilidadeId(bool visivel)
        {
            lblId.Visible = visivel;
            txtId.Visible = visivel;
        }

        private void confirmarClienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                String nomeCliente = txtNome.Text;
                String enderecoCliente = txtEndereco.Text;
                String telefoneCliente = txtTelefone.Text;

                if (this.txtId.Text != null && Int32.TryParse(this.txtId.Text, out int idCliente))
                {
                    Carteira_De_Clientes.Controllers.Cliente.AlterarCliente(this.txtId.Text, nomeCliente, telefoneCliente, enderecoCliente);
                    MessageBox.Show("Cliente atualizado com sucesso!");
                }
                else
                {
                    Carteira_De_Clientes.Controllers.Cliente.CadastrarCliente(nomeCliente, telefoneCliente, enderecoCliente);
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void setarDadosClienteEdicao(int? clienteId)
        {
            Carteira_De_Clientes.Models.Cliente cliente = Carteira_De_Clientes.Controllers.Cliente.GetCliente(clienteId.ToString());
            this.txtId.Text = clienteId.ToString();
            this.txtNome.Text = cliente.Nome;
            this.txtEndereco.Text = cliente.Endereco;
            this.txtTelefone.Text = cliente.Telefone;
        }

    }
}