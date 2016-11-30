using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
       
        public enum EEstadoCuenta { MesPrueba, Deudor, AlDia };

        #region Atributos
        public Gimnasio.EClases _claseQueToma;
        public EEstadoCuenta _estadoCuenta;
        #endregion

        #region Constructores
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.MesPrueba)
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna Datos Alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Se sobreescribe el metodo de PersonaGimnasio retorna una cadena con el nombre de la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Retorna una cadena con los datos del objeto de tipo Alumno, reutiliza el metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// La igualdad se da cuando el alumno pasado por parametro no es deudor y toma la clase pasada por parametro
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno alumno, Gimnasio.EClases clase)
        {
            return (alumno._estadoCuenta != EEstadoCuenta.Deudor && alumno._claseQueToma == clase);
        }

        /// <summary>
        /// La desigualdad se da cuando el alumno no toma la clase
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno alumno, Gimnasio.EClases clase)
        {
            return alumno._claseQueToma != clase;
        }
        #endregion
    }
}
