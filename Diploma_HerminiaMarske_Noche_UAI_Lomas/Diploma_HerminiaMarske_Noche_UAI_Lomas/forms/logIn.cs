﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using ConstantesData;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.forms
{
    public partial class logIn : Form
    {
        public logIn()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string clave = txtPassword.Text;

            if (user == "" || clave == "")
            {
                MessageBox.Show("Por favor ingrese sus credenciales.");
                txtUsuario.Focus();
            } else
            {
                SqlParameter[] pms = new SqlParameter[2];
                pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
                pms[0].Value = txtUsuario.Text;
                pms[1] = new SqlParameter("@password", SqlDbType.VarChar);
                pms[1].Value = txtPassword.Text;

                DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
                DataTable dt = new DataTable();
                dt = dataQuery.getList(SP.LOG_IN, pms);
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
