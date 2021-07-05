using PracticaExamen.Enums;

namespace PracticaExamen.poco
{
    public class Prestamo
    {
        public decimal Monto { get; set; }
        public decimal Interes { get; set; }
        public int Plazo { get; set; }
        public Periodo Periodo { get; set; }
    }
}
