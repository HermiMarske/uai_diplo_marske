using ConstantesData;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class altaActividad : Form
    {
        public altaActividad()
        {
            InitializeComponent();
        }

        private void altaActividad_Load(object sender, EventArgs e)
        {
            //Llenado de combo de paises
            List<Pais> paises = new List<Pais>();
            DataConnection.DataConnection dataQueryPaises = new DataConnection.DataConnection();
            DataTable dtp = new DataTable();
            dtp = dataQueryPaises.getList(SP.LISTAR_PAISES, null);
            foreach (DataRow drp in dtp.Rows)
            {
                Pais pais = new Pais((int)drp[0], (string)drp[1]);
                paises.Add(pais);
            }
            comboPais.DataSource = paises;

            //llenado combo de pilotos
            List<Piloto> pilotos = new List<Piloto>();
            DataConnection.DataConnection dataQueryPilotos = new DataConnection.DataConnection();
            DataTable dtpiloto = new DataTable();
            dtpiloto = dataQueryPilotos.getList(SP.LISTAR_PILOTOS_COMBO, null);
            foreach (DataRow drp in dtpiloto.Rows)
            {
                Persona persona = new Persona();
                persona.SetApellido((string)drp[2]);
                persona.SetNombre((string)drp[1]);
                Piloto piloto = new Piloto((int)drp[0], persona );
                pilotos.Add(piloto);
            }
            comboPiloto.DataSource = pilotos;

            //llenado combo de clientes
            List<Cliente> cliente = new List<Cliente>();
            DataConnection.DataConnection dataQueryClientes = new DataConnection.DataConnection();
            DataTable dtpCliente = new DataTable();
            dtpCliente = dataQueryClientes.getList(SP.LISTAR_CLIENTES_COMBO, null);
            foreach (DataRow drp in dtpCliente.Rows)
            {
                Cliente c = new Cliente((int)drp[0], (string)drp[1]);
                cliente.Add(c);
            }
            comboCliente.DataSource = cliente;

            //llenado combo de aviones
            List<Avion> aviones = new List<Avion>();
            DataConnection.DataConnection dataQueryAviones = new DataConnection.DataConnection();
            DataTable dtpAvion = new DataTable();
            dtpAvion = dataQueryAviones.getList(SP.LISTAR_AVIONES_COMBO, null);
            foreach (DataRow drp in dtpAvion.Rows)
            {
                Avion a = new Avion((int)drp[0], (string)drp[1]);
                aviones.Add(a);
            }
            comboAvion.DataSource = aviones;



        }

        private void comboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Provincia> provincias = new List<Provincia>();
            Pais pais = (Pais)comboPais.SelectedItem;
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            SqlParameter[] pmsProvincias = new SqlParameter[1];
            pmsProvincias[0] = new SqlParameter("@pais", SqlDbType.Int);
            pmsProvincias[0].Value = pais.GetId();
            dt = dataQuery.getList(SP.LISTAR_PROVINCIAS, pmsProvincias);
            comboProvincias.Text = null;
            foreach (DataRow dr in dt.Rows)
            {
                Provincia provincia = new Provincia((string)dr[0], (int)dr[1]);
                provincias.Add(provincia);
            }
            comboProvincias.DataSource = provincias;
        }

        private void comboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Localidad> localidades = new List<Localidad>();
            Provincia provincia = (Provincia)comboProvincias.SelectedItem;
            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            DataTable dt = new DataTable();
            SqlParameter[] pmsLocalidades = new SqlParameter[1];
            if (provincia != null)
            {
                pmsLocalidades[0] = new SqlParameter("@provincia", SqlDbType.Int);
                pmsLocalidades[0].Value = provincia.GetId();
                dt = dataQuery.getList(SP.LISTAR_LOCALIDADES, pmsLocalidades);
                foreach (DataRow dr in dt.Rows)
                {
                    Localidad localidad = new Localidad((string)dr[0], (int)dr[1], (int)dr[2]);
                    localidades.Add(localidad);
                }
            }
            comboLocalidades.Text = null;
            comboLocalidades.DataSource = localidades;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Actividad ac = new Actividad();

            ac.SetFechaHoraInicio(pickerFechaHoraInicio.Value);
            ac.SetHoras((int)numericUpDownHs.Value);
            ac.SetTexto(txtTexto.Text);
            ac.SetPiloto((Piloto)comboPiloto.SelectedItem);
            ac.SetLocalidad((Localidad)comboLocalidades.SelectedItem);
            ac.SetCliente((Cliente)comboCliente.SelectedItem);
            ac.SetAvion((Avion)comboAvion.SelectedItem);

            String rta = ControladorABMActividad.altaActividad(ac);

            MessageBox.Show(rta);
        }
    }
}
