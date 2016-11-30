using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Instructor : PersonaGimnasio
    {
        #region Atributos
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de clase
        /// </summary>
        static Instructor()
        {
            Instructor._random = new Random();
        }

        public Instructor()
        {
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {

            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Le asigna dos clases al azar al instructor
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(3));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(3));
        }

        /// <summary>
        /// Se sobreescribe el metodo de PersonaGimnasio, devuelve todas las clases que da el instructor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Gimnasio.EClases clase in this._clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Retorna una cadena con los datos del objeto de tipo Instructor, reutiliza el metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Retorna una cadena con los datos del objeto de tipo Instructor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// La igualdad se da cuando el instructor pasado por parametro da la clase pasada por parametro
        /// </summary>
        /// <param name="instructor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Instructor instructor, Gimnasio.EClases clase)
        {
            bool esIgual = false;

            foreach (Gimnasio.EClases unaClase in instructor._clasesDelDia)
            {
                if (unaClase == clase)
                {
                    esIgual = true;
                    break;
                }
            }

            return esIgual;
        }

        /// <summary>
        /// La desigualdad se da cuando no se da la igualdad
        /// </summary>
        /// <param name="instructor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Instructor instructor, Gimnasio.EClases clase)
        {
            return !(instructor == clase);
        }
        #endregion
    }
}
