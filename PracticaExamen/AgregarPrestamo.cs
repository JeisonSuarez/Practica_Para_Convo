using PracticaExamen.Enums;
using PracticaExamen.model;
using PracticaExamen.poco;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PracticaExamen
{
    public partial class AgregarPrestamo : Form
    {
        public PrestamoModel model { get; set; }
        
        public DataGridView dgvP;
        DataTable dt;
        public AgregarPrestamo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            decimal monto = decimal.Parse(txtPrestamo.Text);
            decimal interes = decimal.Parse(txtInteres.Text);
            interes = interes / 100;
            int plazo = int.Parse(txtPlazo.Text);
            int index = cmbPeriodo.SelectedIndex;
            Periodo periodo = (Periodo)Enum.GetValues(typeof(Periodo)).GetValue(index);

            


            decimal abono = 0;
            decimal saldo = monto;
            decimal intereses = 0;
            decimal cuota;

            for (int i = 0; i <= plazo; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Año"] = i;

                saldo = saldo - abono;
                intereses = interes * saldo;
                cuota = abono + intereses;
                abono = monto / plazo;

                dr["Abono"] = abono;
                dr["Interes"] = intereses;
                dr["Cuota"] = cuota;
                dr["Saldo"] = saldo;
                dt.Rows.Add(dr);

            }
            dgvCalendarioPago.DataSource = dt;


        }



        private void AgregarPrestamo_Load(object sender, EventArgs e)
        {
            cmbPeriodo.Items.AddRange(Enum.GetValues(typeof(Periodo))
                .Cast<object>()
                .ToArray());
            cmbPeriodo.SelectedIndex = 0;

            dt = new DataTable();
            dt.Columns.Add("Año");
            dt.Columns.Add("Abono");
            dt.Columns.Add("Interes");
            dt.Columns.Add("Cuota");
            dt.Columns.Add("Saldo");
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal monto = decimal.Parse(txtPrestamo.Text);
            decimal interes = decimal.Parse(txtInteres.Text);
            interes = interes / 100;
            int plazo = int.Parse(txtPlazo.Text);
            int index = cmbPeriodo.SelectedIndex;
            Periodo periodo = (Periodo)Enum.GetValues(typeof(Periodo)).GetValue(index);
            Prestamo p = new Prestamo()
            {
                Monto = monto,
                Interes = interes,
                Plazo = plazo,
                Periodo = periodo

            };
            model.AddElement(p);

            dgvP.DataSource = model.GetAll();
            dgvP.Refresh();

        }
    }
}
