
using System.Linq;
using System;
using Carteira_De_Clientes.Controllers;


namespace View
{
    public class Ordem : Form
    {

        Panel buttonPanel = new Panel();
        Label lblId;
        Label lblComboboxFuncionarioServico;
        Label lblPrecoOrdem;
        Label lblComboboxCliente;
        Label lblDataLimite;
        Label lblDataRealizada;
        Label lblDescricao;
        Label lblStatus;


        TextBox txtId;
        ComboBox comboboxFuncionarioServico;
        TextBox txtPrecoOrdem;
        ComboBox comboboxCliente;
        TextBox txtDataLimite;
        TextBox txtDataRealizada;
        TextBox txtDescricao;
        ComboBox comboBoxPerfil;

        Button btnConfirmar;
        Button btnVoltar;

        List<Carteira_De_Clientes.Models.FuncionarioServico> listFuncionarioServico = new List<Carteira_De_Clientes.Models.FuncionarioServico>();
        List<Carteira_De_Clientes.Models.Cliente> listCliente = new List<Carteira_De_Clientes.Models.Cliente>();
        List<Carteira_De_Clientes.Models.Funcionario> listFuncionario = new List<Carteira_De_Clientes.Models.Funcionario>();

        public Ordem(int? ordemId)
        {
            this.Text = "Cadastro de Ordem de Serviço";
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
            txtId.Location = new Point(120, 60);
            txtId.Size = new Size(200, 18);
            txtId.Enabled = false;


            lblComboboxFuncionarioServico = new Label();
            lblComboboxFuncionarioServico.Text = "Gerenciamento:";
            lblComboboxFuncionarioServico.AutoSize = true;
            lblComboboxFuncionarioServico.Location = new Point(20, 120);

            comboboxFuncionarioServico = new ComboBox();
            comboboxFuncionarioServico.Location = new Point(120, 120);
            comboboxFuncionarioServico.Size = new Size(200, 100);
            this.adicionarFuncionarioServicosCombobox();


            lblComboboxCliente = new Label();
            lblComboboxCliente.Text = "Cliente:";
            lblComboboxCliente.AutoSize = true;
            lblComboboxCliente.Location = new Point(20, 180);

            comboboxCliente = new ComboBox();
            comboboxCliente.Location = new Point(120, 180);
            comboboxCliente.Size = new Size(200, 100);
            this.adicionarClientesCombobox();


            lblStatus = new Label();
            lblStatus.Text = "Status:";
            lblStatus.Location = new Point(20, 240);

            comboBoxPerfil = new ComboBox();
            comboBoxPerfil.Location = new Point(120, 240);
            comboBoxPerfil.Size = new Size(200, 100);
            comboBoxPerfil.TabIndex = 0;
            this.setComboBoxPerfil();
            comboBoxPerfil.Text = " ";

            lblPrecoOrdem = new Label();
            lblPrecoOrdem.Text = "Preço:";
            lblPrecoOrdem.Location = new Point(20, 300);

            txtPrecoOrdem = new TextBox();
            txtPrecoOrdem.Location = new Point(120, 300);
            txtPrecoOrdem.Size = new Size(200, 100);


            lblDataLimite = new Label();
            lblDataLimite.Text = "Limite Data:";
            lblDataLimite.Location = new Point(20, 360);

            txtDataLimite = new TextBox();
            txtDataLimite.Location = new Point(120, 360);
            txtDataLimite.Size = new Size(200, 100);


            lblDataRealizada = new Label();
            lblDataRealizada.Text = "Data Realizada:";
            lblDataRealizada.Location = new Point(20, 420);

            txtDataRealizada = new TextBox();
            txtDataRealizada.Location = new Point(120, 420);
            txtDataRealizada.Size = new Size(200, 100);


            lblDescricao = new Label();
            lblDescricao.Text = "Descrição:";
            lblDescricao.Location = new Point(20, 480);

            txtDescricao = new TextBox();
            txtDescricao.Location = new Point(120, 480);
            txtDescricao.Size = new Size(200, 100);


            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.BackColor = Color.Snow;
            btnConfirmar.Location = new Point(420, 10);
            btnConfirmar.Click += new EventHandler(confirmarOrdemButton_Click);

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.BackColor = Color.Snow;
            btnVoltar.Location = new Point(500, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblComboboxFuncionarioServico);
            this.Controls.Add(this.comboboxFuncionarioServico);
            this.Controls.Add(this.lblComboboxCliente);
            this.Controls.Add(this.comboboxCliente);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboBoxPerfil);
            this.Controls.Add(this.lblDataLimite);
            this.Controls.Add(this.lblDataRealizada);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblPrecoOrdem);
            this.Controls.Add(this.txtDataLimite);
            this.Controls.Add(this.txtDataRealizada);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtPrecoOrdem);
            this.Controls.Add(this.buttonPanel);


            if (ordemId != null)
            {
                this.setarDadoOrdemEdicao(ordemId);
            }
        }

        private void setComboBoxPerfil()
        {

            comboBoxPerfil.Items.Clear();

            comboBoxPerfil.Items.Add(Carteira_De_Clientes.Models.Generic.Paid.Pendente);
            comboBoxPerfil.Items.Add(Carteira_De_Clientes.Models.Generic.Paid.Pago);
        }



        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmarOrdemButton_Click(object sender, EventArgs e)
        {
            string precoOrdem = txtPrecoOrdem.Text;
            string dataRealizada = txtDataRealizada.Text;
            string pago = comboBoxPerfil.SelectedItem.ToString();
            string descricao = txtDescricao.Text;
            string dataLimite = txtDataLimite.Text;

            Carteira_De_Clientes.Models.FuncionarioServico funcionarioServicoSelecionado = this.buscarFuncionarioServicoSelecionadoCombobox();
            Carteira_De_Clientes.Models.Cliente clienteSelecionado = this.buscarClienteSelecionadoCombobox();

            if (this.txtId.Text != null && Int32.TryParse(this.txtId.Text, out int idFuncionario))
            {
                Carteira_De_Clientes.Controllers.Ordem.AlterarOrdem(this.txtId.Text, clienteSelecionado.Id.ToString(), funcionarioServicoSelecionado.Id.ToString(), precoOrdem, dataRealizada, pago, descricao, dataLimite);
                MessageBox.Show("Ordem de Serviço atualizada com sucesso!");
            }
            else
            {
                Carteira_De_Clientes.Controllers.Ordem.CadastrarOrdem(clienteSelecionado.Id.ToString(), funcionarioServicoSelecionado.Id.ToString(), precoOrdem, dataRealizada, pago, descricao, dataLimite);
                MessageBox.Show("Ordem de Serviço cadastrada com sucesso!");
            }

            this.Close();
        }

        private void adicionarFuncionarioServicosCombobox()
        {
            comboboxFuncionarioServico.Items.Clear();
            IEnumerable<Carteira_De_Clientes.Models.FuncionarioServico> collectionFuncionarioServico = Carteira_De_Clientes.Controllers.FuncionarioServico.GetAllFuncionarioServicos();
            IEnumerable<Carteira_De_Clientes.Models.Funcionario> collectionFuncionario = Carteira_De_Clientes.Controllers.Funcionario.GetAllFuncionarios();


            // if (collectionFuncionarioServico != null && collectionFuncionarioServico.Count() > 0 && collectionFuncionario != null && collectionFuncionario.Count() > 0)
            // {
            //     this.listFuncionarioServico.AddRange(collectionFuncionarioServico.ToList());
            //     this.listFuncionario.AddRange(collectionFuncionario.ToList());

            //     foreach (var funcionarioServico in collectionFuncionarioServico)
            //     {
            //         foreach (var funcionario in collectionFuncionario)
            //         {
            //             comboboxFuncionarioServico.Items.Add("ID: " + funcionarioServico.Id + " / Contem: " + funcionario.Nome);
            //         }
            //     }

            //     comboboxFuncionarioServico.SelectedIndex = 0;
            // }


            if (collectionFuncionarioServico != null && collectionFuncionarioServico.Count() > 0 )
            {
                this.listFuncionarioServico.AddRange(collectionFuncionarioServico.ToList());

                    foreach (var funcionarioServico in collectionFuncionarioServico)
                    {
                        //comboboxFuncionarioServico.Items.Add("ID: " + funcionarioServico.Id);
                        comboboxFuncionarioServico.Items.Add(funcionarioServico.Id);
                    }

                comboboxFuncionarioServico.SelectedIndex = 0;
            }
        }

        private void adicionarClientesCombobox()
        {
            comboboxCliente.Items.Clear();
            IEnumerable<Carteira_De_Clientes.Models.Cliente> collectionCliente = Carteira_De_Clientes.Controllers.Cliente.GetAllClientes();

            if (collectionCliente != null && collectionCliente.Count() > 0)
            {
                this.listCliente.AddRange(collectionCliente.ToList());

                foreach (var cliente in collectionCliente)
                {
                    //comboboxCliente.Items.Add("ID: " + cliente.Id + " / Nome: " + cliente.Nome);
                    comboboxCliente.Items.Add(cliente.Nome);
                }

                comboboxCliente.SelectedIndex = 0;
            }
        }

        private Carteira_De_Clientes.Models.FuncionarioServico buscarFuncionarioServicoSelecionadoCombobox()
        {
            Carteira_De_Clientes.Models.FuncionarioServico funcionarioServicoSelecionado = null;

            if (comboboxFuncionarioServico.SelectedItem != null)
            {
                String nomeFuncionarioServico = comboboxFuncionarioServico.SelectedItem.ToString();

                funcionarioServicoSelecionado = this.listFuncionarioServico.FirstOrDefault(item => item.Id.ToString().Equals(nomeFuncionarioServico));
            }

            return funcionarioServicoSelecionado;
        }

        private Carteira_De_Clientes.Models.Cliente buscarClienteSelecionadoCombobox()
        {
            Carteira_De_Clientes.Models.Cliente clienteSelecionado = null;

            if (comboboxCliente.SelectedItem != null)
            {
                String nomeCliente = comboboxCliente.SelectedItem.ToString();

                clienteSelecionado = this.listCliente.FirstOrDefault(item => item.Nome.Equals(nomeCliente));

            }

            return clienteSelecionado;
        }


        private void setarDadoOrdemEdicao(int? ordemId)
        {
            Carteira_De_Clientes.Models.Ordem ordem = Carteira_De_Clientes.Controllers.Ordem.GetOrdem(ordemId.ToString());

            Carteira_De_Clientes.Models.FuncionarioServico funcionarioServico = Carteira_De_Clientes.Controllers.FuncionarioServico.GetFuncionarioServico(ordem.FuncionarioServicoId.ToString());
            Carteira_De_Clientes.Models.Cliente cliente = Carteira_De_Clientes.Controllers.Cliente.GetCliente(ordem.ClienteId.ToString());

            this.txtId.Text = ordemId.ToString();
            this.comboboxCliente.SelectedItem = cliente.Nome;
            this.comboboxFuncionarioServico.SelectedItem = funcionarioServico.Id;
            this.txtPrecoOrdem.Text = ordem.PrecoOrdem;
            this.txtDataRealizada.Text = ordem.DataRealizada;
            this.comboBoxPerfil.SelectedItem = ordem.Pago;
            this.txtDescricao.Text = ordem.Descricao;
            this.txtDataLimite.Text = ordem.DataLimite;
        }


    }
}