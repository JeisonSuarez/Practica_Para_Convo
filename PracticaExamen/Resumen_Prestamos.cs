using PracticaExamen.model;
using PracticaExamen.poco;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticaExamen
{
    public partial class Resumen_Prestamos : Form
    {

        DataTable dt;
        public PrestamoModel Model { get; set; }
        public Resumen_Prestamos()
        {
            InitializeComponent();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPrestamo addDialog = new AgregarPrestamo();
            addDialog.model = Model;
            addDialog.dgvP = dgvResumen;
            
            addDialog.ShowDialog();
            Model = addDialog.model;
        }

        private void Resumen_Prestamos_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Monto");
            dt.Columns.Add("Interes");
            dt.Columns.Add("Plazo");
            dt.Columns.Add("Periodo");
            dgvResumen.DataSource = dt;
            
            LoadPrestamos();
            dgvResumen.Refresh();
        }
        private void LoadPrestamos()
        {
            if (Model.GetAll() == null)
            {
                return;
            }

            foreach (Prestamo p in Model.GetAll())
            {
                DataRow dr = dt.NewRow();
                dr["Monto"] = p.Monto;
                dr["Interes"] = p.Interes;
                dr["Plazo"] = p.Plazo;
                dr["Periodo"] = p.Periodo;
                dt.Rows.Add(dr);
            }
            dgvResumen.DataSource = dt;
            dgvResumen.Refresh();

        }
    }
}
