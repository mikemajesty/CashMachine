using BancoTegra.Controller;
using BancoTegra.Model.Entidades;
using BancoTegra.Utilities;
using System;
using System.Windows.Forms;
namespace BancoTegra.View.UI
{
    public partial class frmCashMachine : Form
    {
        public frmCashMachine()
        {
            InitializeComponent();
        }

        private void frmCashMachine_Load(object sender, EventArgs e)
        {
            FocarNoTxt();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            try
            {
                //Condição onde se o valor de notas for maior que um, ou seja, o
                //usuário digitou um valor valido o resultado será exibido.            
                if (new SaqueController().Sacar(Saque.PopularSaque(txtValor.Text)).Count > 0)
                {
                    SaqueController.GerarResultado(Saque.PopularSaque(txtValor.Text).Valor, txtResultado);
                }
            }
            catch (CustomException error)
            {
                LimparTxt();
                MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
                FocarNoTxt();
            }
            catch (Exception error)
            {
                LimparTxt();
                MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Erro");
                FocarNoTxt();
            }


        }

        private void LimparTxt()
        {
            txtValor.Text = string.Empty;
            txtResultado.Text = string.Empty;
        }

        private void FocarNoTxt()
        {
            this.ActiveControl = txtValor;
        }

        private void btnCorrigir_Click(object sender, EventArgs e)
        {
            LimparTxt();
            FocarNoTxt();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparTxt();
            FocarNoTxt();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AddTxt("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddTxt("2");

        }

        private void btn3_Click(object sender, EventArgs e)
        {

            AddTxt("3");

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddTxt("4");

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddTxt("5");

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddTxt("6");

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddTxt("7");

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddTxt("8");

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddTxt("9");

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AddTxt("0");

        }
        private void AddTxt(string valor)
        {
            if (txtResultado.Text.Length > 0)
            {
                txtResultado.Text = string.Empty;
                txtValor.Text = string.Empty;
                txtValor.Text += valor;

            }
            else
            {
                txtValor.Text += valor;

            }

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            if (txtResultado.Text.Trim().Length > 0)
            {
                txtResultado.Text = string.Empty;
            }
        }
        public static DialogResult MessageFullComButtonOkIconeDeInformacao(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            do
            {
                txtValor.Text = txtValor.Text.Trim().Replace("\r\n", "");
            } while (txtValor.Text.Contains("\r\n"));

            if ((sender as TextBox).Text.Length == 0 && e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void FocarNoButton()
        {
            this.ActiveControl = btnConfirmar;
        }
    }
}