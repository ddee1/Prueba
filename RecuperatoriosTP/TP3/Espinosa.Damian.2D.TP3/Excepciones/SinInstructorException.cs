using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinInstructorException : Exception
    {
        #region Atributos
        private static string MESSAGE = "No hay instructor para la clase.";
        #endregion

        #region Constructores
        public SinInstructorException()
            : base(SinInstructorException.MESSAGE)
        { }
        #endregion
    }
}
