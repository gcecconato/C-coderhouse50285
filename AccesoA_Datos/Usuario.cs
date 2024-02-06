using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_aDatos
{
    public class Usuario
    {
        private int _idUsuario;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contrasenia;
        private string _email;

        public int IdUsuario
        {
            get
            {
                //lógica
                return this._idUsuario;
            }
            set
            {
                //lógica
                this._idUsuario = value;
            }
        }
        public string Nombre
        {
            get
            {
                //lógica
                return this._nombre;
            }
            set
            {
                //lógica
                this._nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                //lógica
                return this._apellido;
            }
            set
            {
                //lógica
                this._apellido = value;
            }
        }
        public string NombreUsuario
        {
            get
            {
                //lógica
                return this._nombreUsuario;
            }
            set
            {
                //lógica
                this._nombreUsuario = value;
            }
        }
        public string Contrasenia
        {
            get
            {
                //lógica
                return this._contrasenia;
            }
            set
            {
                //lógica
                this._contrasenia = value;
            }
        }
        public string Email
        {
            get
            {
                //lógica
                return this._email;
            }
            set
            {
                //lógica
                this._email = value;
            }
        }
        public Usuario()
        {
            this._idUsuario = 0;
            this._nombre = string.Empty;
            this._apellido = string.Empty;
            this._nombreUsuario = string.Empty;
            this._contrasenia = string.Empty;
            this._email = string.Empty;
        }
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasenia,
                       string email)
        {
            this._idUsuario = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._contrasenia = contrasenia;
            this._email = email;
        }
    }
}
