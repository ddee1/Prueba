using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    public class Jornada
    {
        #region Atributos
        public List<Alumno> _alumnos;
        public Gimnasio.EClases _clase;
        public Instructor _instructor;
        #endregion

        #region Constructores
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// La igualdad se da cuando un alumno ya esta cargado en la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            bool esIgual = false;

            foreach (Alumno unAlumno in jornada._alumnos)
            {
                if (unAlumno == alumno)
                    esIgual = true;
            }

            return esIgual;
        }

        /// <summary>
        /// La desigualdad se da cuando no se da la igualdad
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        /// <summary>
        /// Agrega un alumno a la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada != alumno)
                jornada._alumnos.Add(alumno);

            return jornada;
        }

        /// <summary>
        /// Retorna una cadena con los datos del objeto de tipo Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this._clase + " POR ");
            sb.AppendLine(this._instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno unAlumno in this._alumnos)
            {
                sb.AppendLine(unAlumno.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        /// <summary>
        /// Persiste los datos de la jornada en un archivo de texto llamado 'Jornada.txt'
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Retorna una cadena con los datos de la jornada almacenados en el archivo 'Jornada.txt'
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static string Leer(Jornada jornada)
        {
            string datosJornada = "";
            Texto texto = new Texto();

            texto.Leer("Jornada.txt", out datosJornada);

            return datosJornada;
        }
        #endregion
    }
}
