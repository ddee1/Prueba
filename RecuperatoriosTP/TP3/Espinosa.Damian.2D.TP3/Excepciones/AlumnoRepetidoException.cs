using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Atributos
        private static string MESSAGE = "Alumno repetido.";
        #endregion

        #region Constructores
        public AlumnoRepetidoException()
            : base(AlumnoRepetidoException.MESSAGE)
        { }
        #endregion
    }
}
