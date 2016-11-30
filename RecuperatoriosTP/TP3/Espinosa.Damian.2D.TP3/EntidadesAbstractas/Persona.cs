using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero };

        #region Atributos y Propiedades

        private string _nombre;
        private string _apellido;
        private ENacionalidad _nacionalidad;
        private int _dni;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = ValidarNombreApellido(value); }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = ValidarNombreApellido(value); }
        }
        
        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        public int DNI
        {
            get { return _dni; }
            set { _dni = ValidaDocumento(this.Nacionalidad, value); }
        }
        

        

        

        [XmlIgnore]
        public string StringToDNI
        {
            set
            {
                try
                {
                    //Se valida que el dni tenga el formato correcto
                    this._dni = ValidaDocumento(this.Nacionalidad, value);
                }
                catch (Exception)
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }
        #endregion

        #region Constructores
        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el dni sea coherente con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidaDocumento(ENacionalidad nacionalidad, int dato) //**
        {
            bool flag = false;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        flag = true;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                        flag = true;
                    break;
                default:
                    throw new NacionalidadInvalidaException("Nacionalidad Invalida");
            }

            if (flag)
                throw new DniIvalidoException("Dni Invalido");
            else
                return dato;
        }

        /// <summary>
        /// Valida que el documento corresponda con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidaDocumento(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidaDocumento(nacionalidad, int.Parse(dato));
            }
            catch (DniIvalidoException)
            {
                throw;
            }
            catch (NacionalidadInvalidaException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw new DniIvalidoException();
            }
        }


        /// <summary>
        /// Valida nombre y apellido 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {          
            Regex reg = new Regex("^[A-Za-z]+$");
            if (reg.IsMatch(dato))
                return dato;
            else
                return "";
        }

        /// <summary>
        /// Retorna una cadena con todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + Apellido + ", " + Nombre);
            sb.AppendLine("NACIONALIDAD: " + Nacionalidad);
            sb.AppendLine("DNI: " + DNI);

            return sb.ToString();
        }
        #endregion
    }
}
