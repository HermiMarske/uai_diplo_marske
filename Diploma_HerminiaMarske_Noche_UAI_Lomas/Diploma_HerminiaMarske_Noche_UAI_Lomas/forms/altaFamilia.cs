using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using ConstantesData;
using System.Data.SqlClient;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class altaFamilia : Form
    {
        List<Patente> patentes = new List<Patente>();
        List<Patente> patentesSeleccionadas = new List<Patente>();
        List<Patente> patentesSeleccionadasModif = new List<Patente>();

        Familia familiaSeleccionada = new Familia();

        private const string FAMILIA_CREADA = "FAMILIA_CREADA";
        private const string FAMILIA_MODIFICADA = "FAMILIA_MODIFICADA";

        public altaFamilia()
        {
            InitializeComponent();
        }

        private void altaFamilia_Load(object sender, EventArgs e)
        {
            cargarData();
        }

        private void cargarData()
        {
            List<Familia> familias = new List<Familia>();
            DataConnection.DataConnection dataQueryFamilias = new DataConnection.DataConnection();
            DataTable dtf = new DataTable();
            dtf = dataQueryFamilias.getList(SP.LISTAR_FAMILIAS, null);
            foreach (DataRow drf in dtf.Rows)
            {
                Familia familia = new Familia((int)drf[0], ControladorEncriptacion.Decrypt((string)drf[1]));
                DataConnection.DataConnection dataQueryFamiliasPatentes = new DataConnection.DataConnection();
                DataTable dtfp = new DataTable();
                dtfp = dataQueryFamiliasPatentes.getList(SP.LISTAR_PATENTES_FAMILIAS, null);
                List<Patente> patentes = new List<Patente>();
                foreach (DataRow drfp in dtfp.Rows)
                {
                    if (familia.GetId() == (int)drfp[0])
                    {
                        Patente p = new Patente((int)drfp[2], ControladorEncriptacion.Decrypt((string)drfp[3]), (int)drfp[0]);
                        patentes.Add(p);
                    }
                }
                familia.SetPatentes(patentes);
                familias.Add(familia);
            }
            listboxFam.DataSource = familias;

            //LISTA DE PATENTES

            DataConnection.DataConnection dataQueryPatentes = new DataConnection.DataConnection();
            DataTable dtpat = new DataTable();
            dtpat = dataQueryPatentes.getList(SP.LISTAR_TODAS_PATENTES, null);
            foreach (DataRow drpat in dtpat.Rows)
            {
                Patente patente = new Patente((int)drpat[0], ControladorEncriptacion.Decrypt((string)drpat[1]));
                patentes.Add(patente);
            }
            checkedListPatentes.DataSource = patentes;
            checkedDisponibles.DataSource = patentes;
        }

        private void listboxFam_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Patente> patentes = new List<Patente>();
            Familia familia = (Familia)listboxFam.SelectedItem;
            listBoxPatXFam.DataSource = familia.GetPatentes();

            //OBTENER FAMILIA SELECCIONADA Y METERLA EN EL COSO DE MODIFICAR

            familiaSeleccionada = (Familia)listboxFam.SelectedItem;
            txtNombreFamModif.Text = familiaSeleccionada.GetDescripcion();

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            foreach (Patente p in checkedListPatentes.CheckedItems)
            {
                patentesSeleccionadas.Add(p);
            }
            listPatOtorgadas.DataSource = patentesSeleccionadas;
        }

        private void btnCrearFam_Click(object sender, EventArgs e)
        {
            string nombreFamilia = txtNombreFam.Text;
            if (string.IsNullOrEmpty(nombreFamilia) || nombreFamilia.Length < 5)
            {
                MessageBox.Show("Nombre de Familia no valido");
                txtNombreFam.Focus();
                txtNombreFam.Focus();
                txtNombreFam.Focus();
            }
            else if (listPatOtorgadas.Items.Count == 0)
            {
                MessageBox.Show("Lista de patentes vacia, seleccione patentes primero");
            }
            else
            {
                List<Patente> patentesOtorgadas = new List<Patente>();
                foreach (Patente p in listPatOtorgadas.Items)
                {
                    patentesOtorgadas.Add(p);
                }
                Familia familia = new Familia();

                familia.SetDescripcion(nombreFamilia);
                familia.SetPatentes(patentesOtorgadas);

                string respuesta = ControladorABMFamilia.altaFam(familia);

                if (respuesta.Equals(FAMILIA_CREADA))
                {
                    MessageBox.Show("Familia creada exitosamente.");
                }
                cargarData();
            }



        }

        private void btnPasarModif_Click(object sender, EventArgs e)
        {
            foreach (Patente p in checkedDisponibles.CheckedItems)
            {
                patentesSeleccionadasModif.Add(p);
            }
            listModifOtorgadas.DataSource = patentesSeleccionadasModif;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombreFamilia = txtNombreFamModif.Text;
            
            familiaSeleccionada.SetDescripcion(nombreFamilia);


            if (string.IsNullOrEmpty(nombreFamilia) || nombreFamilia.Length < 5)
            {
                MessageBox.Show("Nombre de Familia no valido");
                txtNombreFamModif.Focus();
            }
            else if (listModifOtorgadas.Items.Count == 0)
            {
                MessageBox.Show("Lista de patentes vacia, seleccione patentes primero");
            }
            else
            {
                List<Patente> patentesOtorgadas = new List<Patente>();
                foreach (Patente p in listModifOtorgadas.Items)
                {
                    patentesOtorgadas.Add(p);
                }



                familiaSeleccionada.SetPatentes(patentesOtorgadas);

                string respuesta = ControladorABMFamilia.modificarFam(familiaSeleccionada);

                if (respuesta.Equals(FAMILIA_MODIFICADA))
                {
                    MessageBox.Show("Familia modificada exitosamente.");
                }

            }
            cargarData();
        }

        private void btnModificarFam_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrarFam_Click(object sender, EventArgs e)
        {
            Familia fam = new Familia();

            fam = (Familia) listboxFam.SelectedItem;

            string rta = ControladorABMFamilia.borrarFamilia(fam);

            MessageBox.Show(rta);

            cargarData();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalirModif_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
