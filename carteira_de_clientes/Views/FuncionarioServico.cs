
using System.Linq;
using System;
using Carteira_De_Clientes.Controllers;


namespace View
{
    public class FuncionarioServico : Form
    {

        Panel buttonPanel = new Panel();
        Label lblId;
        Label lblComboboxFuncionario;
        Label lblComboboxServico;

        TextBox txtId;
        ComboBox comboboxFuncionario;
        ComboBox comboboxServico;

        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;

        List<Carteira_De_Clientes.Models.Funcionario> listFuncionario = new List<Carteira_De_Clientes.Models.Funcionario>();
        List<Carteira_De_Clientes.Models.Servico> listServico = new List<Carteira_De_Clientes.Models.Servico>();

        public FuncionarioServico(int? funcionarioServicoId)
        {
            this.Text = "Cadastro de Gerenciamento de Atividades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#748E83");

            this.Size = new Size(600, 600);

            lblId = new Label();
            lblId.Text = "Id:";
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 60);

            txtId = new TextBox();
            txtId.Location = new Point(120, 60);
            txtId.Size = new Size(200, 18);
            txtId.Enabled = false;

            lblComboboxFuncionario = new Label();
            lblComboboxFuncionario.Text = "Funcionario:";
            lblComboboxFuncionario.AutoSize = true;
            lblComboboxFuncionario.Location = new Point(20, 120);

            comboboxFuncionario = new ComboBox();
            comboboxFuncionario.Location = new Point(120, 120);
            comboboxFuncionario.Size = new Size(200, 18);
            this.adicionarFuncionariosCombobox();

            lblComboboxServico = new Label();
            lblComboboxServico.Text = "Serviço:";
            lblComboboxServico.AutoSize = true;
            lblComboboxServico.Location = new Point(20, 180);

            comboboxServico = new ComboBox();
            comboboxServico.Location = new Point(120, 180);
            comboboxServico.Size = new Size(200, 18);
            this.adicionarServicosCombobox();


            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.BackColor = Color.Snow;
            btnConfirmar.Location = new Point(420, 10);
            btnConfirmar.Click += new EventHandler(confirmarFuncionarioServicoButton_Click);

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
            this.Controls.Add(this.lblComboboxFuncionario);
            this.Controls.Add(this.comboboxFuncionario);
            this.Controls.Add(this.lblComboboxServico);
            this.Controls.Add(this.comboboxServico);
            this.Controls.Add(this.buttonPanel);


            if (funcionarioServicoId != null)
            {
                this.setarDadoFuncionarioServicoEdicao(funcionarioServicoId);
            }
        }



        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmarFuncionarioServicoButton_Click(object sender, EventArgs e)
        {
            try
            {

                Carteira_De_Clientes.Models.Funcionario funcionarioSelecionado = this.buscarFuncionarioSelecionadoCombobox();
                Carteira_De_Clientes.Models.Servico servicoSelecionado = this.buscarServicoSelecionadoCombobox();

                if (this.txtId.Text != null && Int32.TryParse(this.txtId.Text, out int idFuncionarioServico))
                {
                    Carteira_De_Clientes.Controllers.FuncionarioServico.AlterarFuncionarioServico(this.txtId.Text, funcionarioSelecionado.Id.ToString(), servicoSelecionado.Id.ToString());
                    MessageBox.Show("Gerenciamento de Atividade atualizado com sucesso!");
                }
                else
                {
                    Carteira_De_Clientes.Controllers.FuncionarioServico.CadastrarFuncionarioServico(funcionarioSelecionado.Id.ToString(), servicoSelecionado.Id.ToString());
                    MessageBox.Show("Gerenciamento de Atividade cadastrado com sucesso!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void adicionarFuncionariosCombobox()
        {
            comboboxFuncionario.Items.Clear();
            IEnumerable<Carteira_De_Clientes.Models.Funcionario> collectionFuncionario = Carteira_De_Clientes.Controllers.Funcionario.GetAllFuncionarios();

            if (collectionFuncionario != null && collectionFuncionario.Count() > 0)
            {
                this.listFuncionario.AddRange(collectionFuncionario.ToList());

                foreach (var funcionario in collectionFuncionario)
                {
                    comboboxFuncionario.Items.Add(funcionario.Nome);
                }

                comboboxFuncionario.SelectedIndex = 0;
            }
        }

        private void adicionarServicosCombobox()
        {
            comboboxServico.Items.Clear();
            IEnumerable<Carteira_De_Clientes.Models.Servico> collectionServico = Carteira_De_Clientes.Controllers.Servico.GetAllServicos();

            if (collectionServico != null && collectionServico.Count() > 0)
            {
                this.listServico.AddRange(collectionServico.ToList());

                foreach (var servico in collectionServico)
                {
                    comboboxServico.Items.Add(servico.Nome);
                }

                comboboxServico.SelectedIndex = 0;
            }
        } 

        private Carteira_De_Clientes.Models.Funcionario buscarFuncionarioSelecionadoCombobox()
        {
            Carteira_De_Clientes.Models.Funcionario funcionarioSelecionado = new Carteira_De_Clientes.Models.Funcionario();

            if (comboboxFuncionario.SelectedItem != null)
            {
                String nomeFuncionario = comboboxFuncionario.SelectedItem.ToString();

                funcionarioSelecionado = this.listFuncionario.Where(item => item.Nome.Equals(nomeFuncionario)).FirstOrDefault();
            }

            return funcionarioSelecionado;
        }

        private Carteira_De_Clientes.Models.Servico buscarServicoSelecionadoCombobox()
        {
            Carteira_De_Clientes.Models.Servico servicoSelecionado = new Carteira_De_Clientes.Models.Servico();

            if (comboboxServico.SelectedItem != null)
            {
                String nomeServico = comboboxServico.SelectedItem.ToString();

                servicoSelecionado = this.listServico.Where(item => item.Nome.Equals(nomeServico)).FirstOrDefault();
            }

            return servicoSelecionado;
        }        

        private void setarDadoFuncionarioServicoEdicao(int? funcionarioServicoId)
        {
            Carteira_De_Clientes.Models.FuncionarioServico funcionarioServico = Carteira_De_Clientes.Controllers.FuncionarioServico.GetFuncionarioServico(funcionarioServicoId.ToString());

            Carteira_De_Clientes.Models.Funcionario funcionario = Carteira_De_Clientes.Controllers.Funcionario.GetFuncionario(funcionarioServico.FuncionarioId.ToString());
            Carteira_De_Clientes.Models.Servico servico = Carteira_De_Clientes.Controllers.Servico.GetServico(funcionarioServico.ServicoId.ToString());



            this.txtId.Text = funcionarioServicoId.ToString();
            this.comboboxFuncionario.SelectedItem = funcionario.Nome;
            this.comboboxServico.SelectedItem = servico.Nome;
        }


    }
}