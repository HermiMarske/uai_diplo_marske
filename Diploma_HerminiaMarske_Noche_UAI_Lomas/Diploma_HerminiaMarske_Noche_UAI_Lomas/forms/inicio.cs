﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas
{
    public partial class formInicio : Form
    {
        public formInicio()
        {
            InitializeComponent();
        }

        private void actividadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupAltaCliente_Enter(object sender, EventArgs e)
        {

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            altaCliente formAltaCliente = new altaCliente();

            formAltaCliente.Show();

        }

        private void formInicio_Load(object sender, EventArgs e)
        {
          

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanelListaClientes.Show();
        }
    }
}