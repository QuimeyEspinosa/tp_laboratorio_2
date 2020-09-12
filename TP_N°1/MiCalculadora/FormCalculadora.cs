using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            lblResultado.Text = String.Empty;
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            cmbOperador.Text = String.Empty;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            if(String.IsNullOrEmpty(cmbOperador.Text))
            {
                cmbOperador.Text = "+";
            }

            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = resultado.ToString();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numIngresado1 = new Numero(numero1);
            Numero numIngresado2 = new Numero(numero2);

            return Calculadora.Operar(numIngresado1, numIngresado2, operador);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numIngresado1 = new Numero();

            if (!(String.IsNullOrEmpty(lblResultado.Text)))
            {
                lblResultado.Text = numIngresado1.DecimalBinario(lblResultado.Text);
            }
        }

        private void ConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numIngresado1 = new Numero();

            if (!(String.IsNullOrEmpty(lblResultado.Text)))
            {
                lblResultado.Text = numIngresado1.BinarioDecimal(lblResultado.Text);
            }
        }
    }
}
