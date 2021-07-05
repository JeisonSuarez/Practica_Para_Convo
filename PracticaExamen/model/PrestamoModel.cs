using PracticaExamen.poco;
using System;

namespace PracticaExamen.model
{
    public class PrestamoModel
    {
        private static Prestamo[] prestamos;
        public PrestamoModel()
        {

        }

        public void AddElement(Prestamo p)
        {
            if (prestamos == null)
            {
                prestamos = new Prestamo[1];
                prestamos[0] = p;
                return;

            }
            Prestamo[] temp = new Prestamo[prestamos.Length + 1];
            Array.Copy(prestamos, temp, prestamos.Length);
            temp[temp.Length - 1] = p;
            prestamos = temp;

        }
        public Prestamo[] GetAll()
        {
            return prestamos;
        }
    }
}
