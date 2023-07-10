
using System.Linq;

namespace View
{
    public class Servico : Form
    {

        Panel buttonPanel = new Panel();
        Label lblId;
        Label lblNome;
        Label lblPrecoServico;


        TextBox txtId;
        TextBox txtNome;
        TextBox txtPrecoServico;

        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;


        public Servico(int? servicoId)
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
            lblNome.Text = "Tipo:";
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 120);

            txtNome = new TextBox();
            txtNome.Location = new Point(80, 120);
            txtNome.Size = new Size(200, 18);

            lblPrecoServico = new Label();
            lblPrecoServico.Text = "Preço:";
            lblPrecoServico.AutoSize = true;
            lblPrecoServico.Location = new Point(20, 180);

            txtPrecoServico = new TextBox();
            txtPrecoServico.Location = new Point(80, 180);
            txtPrecoServico.Size = new Size(200, 18);

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.BackColor = Color.Snow;
            btnConfirmar.Location = new Point(420, 10);
            btnConfirmar.Click += new EventHandler(confirmarServicoButton_Click);

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
            this.Controls.Add(this.lblPrecoServico);
            this.Controls.Add(this.txtPrecoServico);
            this.Controls.Add(this.buttonPanel);

            if (servicoId != null)
            {
                this.setarDadosServicoEdicao(servicoId);
            }
        }


        public void AlterarVisibilidadeId(bool visivel)
        {
            lblId.Visible = visivel;
            txtId.Visible = visivel;

        }

        private void confirmarServicoButton_Click(object sender, EventArgs e)
        {
            try
            {
                String nomeServico = txtNome.Text;
                String precoServico = txtPrecoServico.Text;


                if (this.txtId.Text != null && Int32.TryParse(this.txtId.Text, out int idServico))
                {
                    Carteira_De_Clientes.Controllers.Servico.AlterarServico(this.txtId.Text, nomeServico, precoServico);
                    MessageBox.Show("Serviço atualizado com sucesso!");
                }
                else
                {
                    Carteira_De_Clientes.Controllers.Servico.CadastrarServico(nomeServico, precoServico);
                    MessageBox.Show("Serviço cadastrado com sucesso!");
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


        private void setarDadosServicoEdicao(int? servicoId)
        {
            Carteira_De_Clientes.Models.Servico servico = Carteira_De_Clientes.Controllers.Servico.GetServico(servicoId.ToString());
            this.txtId.Text = servicoId.ToString();
            this.txtNome.Text = servico.Nome.ToString();
            this.txtPrecoServico.Text = servico.PrecoServico;
        }

    }
}