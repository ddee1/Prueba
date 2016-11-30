using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniIvalidoException : Exception
    {
        #region Atributos
        private static string MESSAGE = "El DNI es invalido";
        #endregion

        #region Constructores
        public DniIvalidoException()
            : this(DniIvalidoException.MESSAGE)
        { }

        public DniIvalidoException(Exception e)
            : this(DniIvalidoException.MESSAGE, e)
        { }

        public DniIvalidoException(string message)
            : this(message, null)
        { }

        public DniIvalidoException(string message, Exception e)
            : base(message, e)
        { }
        #endregion
    }
}
