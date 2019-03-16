﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos;

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

            SqlParameter[] pms = new SqlParameter[2];
            pms[0] = new SqlParameter("@usuario", SqlDbType.VarChar);
            pms[0].Value = txtUsuario.Text;
            pms[1] = new SqlParameter("@password", SqlDbType.VarChar);
            pms[1].Value = txtPassword.Text;

            DataConnection.DataConnection dataQuery = new DataConnection.DataConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = dataQuery.getList("LogIn", pms);
            da.Fill(dt);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
