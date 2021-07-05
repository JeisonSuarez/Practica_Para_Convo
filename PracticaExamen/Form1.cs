using PracticaExamen.model;
using System;
using System.Windows.Forms;

namespace PracticaExamen
{
    public partial class Form1 : Form
    {
        PrestamoModel prestamoModel;

        public Form1()
        {
            InitializeComponent();
        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resumen_Prestamos agregar = new Resumen_Prestamos();
            agregar.Model = prestamoModel;
            agregar.MdiParent = this;
            agregar.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prestamoModel = new PrestamoModel();
        }
    }
}
