using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Atributos
        private static string MESSAGE = "Hubo un error con el archivo";
        #endregion

        #region Constructores
        public ArchivosException(Exception innerException)
            : base(ArchivosException.MESSAGE, innerException)
        { }
        #endregion
    }
}
