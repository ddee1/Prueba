using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        #region Atributos
        public int _id;
        #endregion

        #region Constructores
        public PersonaGimnasio()
        { }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._id = id;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Datos del objeto de tipo PersonaGimnasio
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("CARNET NÚMERO: " + this._id);
            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Son iguales si tienen el mismo DNI o ID
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1._id == pg2._id || pg1.DNI == pg2.DNI));
        }

        /// <summary>
        /// desigualdad 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Se valida que el objeto sea del tipo PersonaGimnasio y se reutiliza la igualdad entre dos PersonaGimnasio
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio && (PersonaGimnasio)obj == this);
        }
        #endregion
    }
}
