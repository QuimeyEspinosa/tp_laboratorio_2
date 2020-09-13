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
        /// <summary>
        /// Inicializa el formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Limpia los valores del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Limpia los valores del formulario
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "Resultado";
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            cmbOperador.Text = "+";
        }

        /// <summary>
        /// Realiza el calculo de los valores recibidos y los muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Realiza el calculo de los valores ingresados en base al operador ingresado
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado del calculo</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numIngresado1 = new Numero(numero1);
            Numero numIngresado2 = new Numero(numero2);

            return Calculadora.Operar(numIngresado1, numIngresado2, operador);
        }

        /// <summary>
        /// Convierte un numero decimal a binario y lo muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numIngresado1 = new Numero();

            if (!(String.IsNullOrEmpty(lblResultado.Text)))
            {
                lblResultado.Text = numIngresado1.DecimalBinario(lblResultado.Text);
            }
        }

        /// <summary>
        /// Convierte un numero binario a decimal y lo muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numIngresado1 = new Numero();

            if (!(String.IsNullOrEmpty(lblResultado.Text)))
            {
                lblResultado.Text = numIngresado1.BinarioDecimal(lblResultado.Text);
            }
        }

    }
}
