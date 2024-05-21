

using System.Windows.Forms;

namespace Integração
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Integrar_Click(object sender, EventArgs e)
        {

            label2.Text = "Integrando, aguarde...";
            var funcionarios = new FuncionarioModel();
            var listaFuncionario = await funcionarios.ObterFuncionarioModelsAsync();

            //dataGridView1.DataSource = listaFuncionario;


            var atualizar = new FuncionarioModel();
            var listatualizar = await atualizar.EnviarFuncionariosAsync(listaFuncionario);


            label2.Text = "";
        }


    }
}