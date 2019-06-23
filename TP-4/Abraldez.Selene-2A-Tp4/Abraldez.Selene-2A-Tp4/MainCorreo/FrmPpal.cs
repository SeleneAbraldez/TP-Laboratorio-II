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

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        /// <summary>
        /// método ActualizarEstados limpiará los 3 ListBox y luego recorrerá la lista de paquetes agregando cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete paquete in this.correo.Paquetes)
            {
                if (paquete.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(paquete);
                }
            }
        }

        /// evento click del botón btnAgregar realizará las siguientes acciones en el siguiente orden:
            ///a.Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado.
            ///b.Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
            ///c.Llamará al método ActualizarEstados.
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingId.Text); //a
            paquete.InformaEstado += this.paq_InformaEstado;
            try
            {
                this.correo += paquete; //b
            }
            catch (TrackingIdRepetidoException exception)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show(exception.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            this.ActualizarEstados(); //c
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// llamar al método FinEntregas a fin de cerrar todos los hilos abiertos.
        /// </summary>
        private void FrmPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            
            try
            {
                if (!(Object.Equals(elemento, null)))
                {
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                    (elemento.MostrarDatos(elemento)).Guardar("salida.txt");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

    }
}
 