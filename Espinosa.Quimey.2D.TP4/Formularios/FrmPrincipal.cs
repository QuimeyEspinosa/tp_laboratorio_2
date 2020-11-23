using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public delegate void MiApp();

    public partial class FrmPrincipal : Form
    {
        public event MiApp IniciarApp;

        Thread thVendedor;
        Thread thActualizador;

        public FrmPrincipal()
        {
            InitializeComponent();
            IniciarApp += Comercio.Iniciar;
            IniciarApp += AgregarThreads;
            IniciarApp += AbrirNegocio;
        }

        /// <summary>
        /// Invoca al evento IniciarApp y carga dgv_Productos, cmbBox y rtxt de Ventas pendientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                IniciarApp.Invoke();
                this.dgv_Productos.DataSource = Comercio.MisProductos;
                this.cmb_Tipo.DataSource = Enum.GetValues(typeof(Producto.ETipo));
                foreach (Venta item in Comercio.VentasPendientes)
                {
                    rtxt_VentasPendientes.Text += item.ToString();
                }
            }
            catch (ConexionALaBaseException miEx)
            {
                MessageBox.Show(miEx.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                miEx.Guardar();
            }
            catch (ArchivoException miEx2)
            {
                MessageBox.Show(miEx2.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                miEx2.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ex.Guardar();
            }
        }



        /// <summary>
        /// Asigna el o los métodos que van a ejecutar los hilos
        /// </summary>
        private void AgregarThreads()
        {
            thVendedor = new Thread(Comercio.EntregarVentas);
            thActualizador = new Thread(this.Actualizar);
        }

        /// <summary>
        /// Inicia los threads
        /// </summary>
        private void AbrirNegocio()
        {
            try
            {
                thVendedor.Start();
                thActualizador.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Guardar();
            }
        }

        /// <summary>
        /// Actualiza constantemente los datos vistos en pantalla(dgv, rtxt's)
        /// </summary>
        private void Actualizar()
        {
            try
            {
                //actualizo constantemente
                while (true)
                {
                    Thread.Sleep(1000);
                    //si el rtxt pertenece a otro hilo...
                    if (this.rtxt_VentasPendientes.InvokeRequired)
                    {
                        this.rtxt_VentasPendientes.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.rtxt_VentasPendientes.Text = string.Empty;
                            foreach (Venta item in Comercio.VentasPendientes)
                            {
                                this.rtxt_VentasPendientes.Text += item.ToString();
                            }
                        });
                    }
                    if (this.rtxt_VentasEntregadas.InvokeRequired)
                    {
                        this.rtxt_VentasEntregadas.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.rtxt_VentasEntregadas.Text = string.Empty;
                            foreach (Venta item in Comercio.VentasEntregadas)
                            {
                                this.rtxt_VentasEntregadas.Text += item.ToString();
                            }
                        });
                    }
                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                ex.Guardar();
            }
        }

        /// <summary>
        /// Aborta los hilos
        /// </summary>
        private void CerrarNegocio()
        {
            thVendedor.Abort();
            thActualizador.Abort();
        }



        /// <summary>
        /// Botón que valida los datos de los textbox y agrega un producto al comercio y la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AgregarProducto_Click(object sender, EventArgs e)
        {
            Producto nuevoProd;
            float auxPrecioProducto;
            int auxStock;

            if (!string.IsNullOrEmpty(this.txt_Descripcion.Text))
            {
                if (float.TryParse(this.txt_Precio.Text, out auxPrecioProducto))
                {
                    if (int.TryParse(this.txt_Stock.Text, out auxStock))
                    {
                        try
                        {
                            nuevoProd = new Producto(Producto.MapearEnum(this.cmb_Tipo.Text), this.txt_Descripcion.Text, auxPrecioProducto, auxStock);

                            if (Comercio.AgregarProducto(nuevoProd))
                            {
                                MessageBox.Show("Se agregó con éxito el siguiente producto: \n\n" +
                                $"Descripción: {nuevoProd.Descripcion.ToString()}\n" +
                                $"Precio: ${nuevoProd.PrecioUnitario.ToString()}\n" +
                                $"Stock: {nuevoProd.Unidades.ToString()}\n",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                                this.txt_Descripcion.Text = string.Empty;
                                this.txt_Precio.Text = string.Empty;
                                this.txt_Stock.Text = string.Empty;
                            }
                            ActualizarDgvProductos();

                        }
                        catch (NuevoProductoException miEx)
                        {
                            MessageBox.Show(miEx.Message,
                           "Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                            miEx.Guardar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,
                           "Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                            ex.Guardar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha ingresado un stock válido",
                           "Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha ingresado un precio válido",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se ha ingresado una descripción válida",
                   "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Botón que aumenta un valor de stock aleatorio a los productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GenerarStock_Click(object sender, EventArgs e)
        {
            Comercio.AgregarStock();
            ActualizarDgvProductos();
        }

        /// <summary>
        /// Genera una venta y la agrega al comercio y a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GenerarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Comercio.ConfirmarVenta(Comercio.NuevaVentaRandom());

                rtxt_VentasPendientes.Text = string.Empty;
                foreach (Venta item in Comercio.VentasPendientes)
                {
                    rtxt_VentasPendientes.Text += item.ToString();
                }
                ActualizarDgvProductos();
            }
            catch (NuevaVentaException miEx)
            {
                rtxt_VentasPendientes.Text += $"{miEx.Message}\n------------------------------------------------------------------------------\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ex.Guardar();
            }
        }

        /// <summary>
        /// Al cerrar el formulario aborta los hilos y guarda las Ventas pendientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarNegocio();
            try
            {
                Comercio.GuardarVentasPendientesXml();
            }
            catch (ArchivoException miEx)
            {
                MessageBox.Show(miEx.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                miEx.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                ex.Guardar();
            }
        }



        /// <summary>
        /// Actualiza el dataGridView de los productos
        /// </summary>
        private void ActualizarDgvProductos()
        {
            dgv_Productos.DataSource = null;
            dgv_Productos.DataSource = Comercio.MisProductos;
        }

        /// <summary>
        /// Leave de txt que aplica una "normalización" a la descripción
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Descripcion_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Validacion.AsignarLeaveString(((TextBox)sender).Text.Trim());
        }

        /// <summary>
        /// Leave de txt que aplica una pequeña validación al precio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Precio_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Validacion.AsignarLeaveStringNumero(((TextBox)sender).Text.Trim());
        }

        /// <summary>
        /// Leave de txt que aplica una pequeña validación al stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Stock_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Validacion.AsignarLeaveStringNumero(((TextBox)sender).Text.Trim());
        }
    }
}
