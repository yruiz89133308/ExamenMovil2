using System;
using System.Collections.Generic;
using System.Text;

namespace Examen3PMO2.controller
{
    public class ValidarDatos
    {
        bool respuesta;
        public bool validarPersona(int pago, string descripcion, double monto, string fecha)
        {

            respuesta = (pago.Equals("") || descripcion == null || monto.Equals("") || fecha == null) ? false : true;

            return respuesta;
        }
    }
}