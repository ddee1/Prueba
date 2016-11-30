using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        public enum EClases { CrossFit = 0, Natacion = 1, Pilates = 2, Yoga = 3 };

        #region Atributos y Propiedades
        public List<Alumno> _alumnos;
        public List<Instructor> _instructores;
        public List<Jornada> _jornadas;

        [XmlIgnore]
        public Jornada this[int index]
        {
            get
            {
                return this._jornadas[index];
            }
        }

        

        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
        }

        public List<Instructor> Instructores
        {
            get { return _instructores; }
        }

        public List<Jornada> Jornada
        {
            get { return _jornadas; }
        }

        
        #endregion

        #region Constructores
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// La igualdad se da cuando el alumno ya esta cargado en el gimnasio
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio gym, Alumno alumno)
        {
            bool flag = false;

            foreach (Alumno unAlumno in gym._alumnos)
            {
                if (unAlumno == alumno)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// La desigualdad se da cuando no se da la igualdad
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio gym, Alumno alumno)
        {
            return !(gym == alumno);
        }

        /// <summary>
        /// Se agrega un alumno al gimnasio si este no fue cargado previamente
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gym, Alumno alumno)
        {
            if (gym != alumno)
                gym._alumnos.Add(alumno);
            else
                throw new AlumnoRepetidoException();

            return gym;
        }

        /// <summary>
        /// La igualdad se da cuando el instructor ya esta cargado en el gimnasio
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="instructor"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio gym, Instructor instructor)
        {
            bool esIgual = false;

            foreach (Instructor unInstructor in gym._instructores)
            {
                if (unInstructor == instructor)
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
        /// <param name="gym"></param>
        /// <param name="instructor"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio gym, Instructor instructor)
        {
            return !(gym == instructor);
        }

        /// <summary>
        /// Se agrega un instructor al gimnasio si este no fue cargado previamente
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="instructor"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gym, Instructor instructor)
        {
            if (gym != instructor)
                gym._instructores.Add(instructor);

            return gym;
        }

        /// <summary>
        /// La igualdad retorna el primer instructor disponible para dar la clase, sino retorna SinInstructorException
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio gym, EClases clase)
        {
            Instructor instructorDisponible = null;

            foreach (Instructor instr in gym._instructores)
            {
                if (instr == clase)
                {
                    instructorDisponible = instr;
                    break;
                }
            }

            if (!Object.Equals(instructorDisponible, null))
                return instructorDisponible;
            else
                throw new SinInstructorException();
        }

        /// <summary>
        /// La desigualdad retorna el primer instructor que no esta disponible para dar la clase
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio gym, EClases clase)
        {
            Instructor instructorNoDisponible = null;

            foreach (Instructor instr in gym._instructores)
            {
                if (instr != clase)
                {
                    instructorNoDisponible = instr;
                    break;
                }
            }

            return instructorNoDisponible;
        }

        /// <summary>
        /// Se genera una jornada con la clase pasada por parametro, se le asigna un instructor y se cargan todos los alumnos
        /// </summary>
        /// <param name="gym"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gym, EClases clase)
        {
            try
            {
                //La jornada se genera con el primer instructor disponile para dar la clase
                Jornada jornada = new Jornada(clase, gym == clase);

                //Se agregan todos los alumnos que tomen esa clase
                foreach (Alumno unAlumno in gym._alumnos)
                {
                    if (unAlumno == clase)
                    {
                        jornada._alumnos.Add(unAlumno);
                        break;
                    }
                }

                gym._jornadas.Add(jornada);
                return gym;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Retorna una cadena son los datos del objeto de tipo Gimnasio
        /// </summary>
        /// <param name="gym"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gym)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in gym._jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Retorna una cadena con los datos del objeto de tipo Gimnasio, reutiliza el metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        /// <summary>
        /// persiste los datos del Gimnasio serializandolos en un archivo xml con el nombre "Gimnasio.xml"
        /// </summary>
        /// <param name="gym"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gym)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            return xml.Guardar("Gimnasio.xml", gym);
        }

        /// <summary>
        /// Retorna un objeto del tipo Gimnasio generado a partir de la deserializacion del archivo "Gimnasio.xml"
        /// </summary>
        /// <param name="gym"></param>
        /// <returns></returns>
        public static Gimnasio Leer(Gimnasio gym)
        {
            Gimnasio unGym;
            Xml<Gimnasio> xml = new Xml<Gimnasio>();

            xml.Leer("Gimnasio.xml", out unGym);
            return unGym;
        }
        #endregion
    }
}
