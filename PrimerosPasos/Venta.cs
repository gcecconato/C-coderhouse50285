using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_PrimerosPasos
{
    public class Venta
    {
        private int _idVenta;
        private string _comentarios;
        private int _idUsuario;

        public int IdVenta
        {
            get
            {
                //lógica
                return this._idVenta;
            }
            set
            {
                //lógica
                this._idVenta = value;
            }
        }
        public string Comentarios
        {
            get
            {
                //lógica
                return this._comentarios;
            }
            set
            {
                //lógica
                this._comentarios = value;
            }
        }
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
        public Venta() 
        { 
            this._idVenta = 0;
            this._comentarios = string.Empty;
            this._idUsuario = 0;      
        }
        public Venta(int idVenta, string comentarios, int idUsuario)
        {
            this._idVenta = idVenta;
            this._comentarios = comentarios;
            this._idUsuario = idUsuario;
        }
    }
}
