using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_aDatos
{
    public class Producto
    {
        private int _idProducto;
        private string _descripcion;
        private double _costo;
        private double _precioVenta;
        private long _stock;
        private int _idUsuario;
        public int IdProducto
        {
            get
            {
                //lógica
                return this._idProducto;
            }
            set
            {
                //lógica
                this._idProducto = value;
            }
        }
        public string Descripcion
        {
            get
            {
                //lógica
                return this._descripcion;
            }
            set
            {
                //lógica
                this._descripcion = value;
            }
        }
        public double Costo
        {
            get
            {
                //lógica
                return this._costo;
            }
            set
            {
                //lógica
                this._costo = value;
            }
        }
        public double PrecioVenta
        {
            get
            {
                //lógica
                return this._precioVenta;
            }
            set
            {
                //lógica
                this._precioVenta = value;
            }
        }
        public long Stock
        {
            get
            {
                //lógica
                return this._stock;
            }
            set
            {
                //lógica
                this._stock = value;
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
        public Producto()
        {
            this._idProducto = 0;
            this._descripcion = string.Empty;
            this._costo = 0;
            this._precioVenta = 0;
            this._stock = 0;
            this._idUsuario = 0;
        }

        public Producto(int idProducto, string descripcion, double costo,
                        double precioVenta, long stock, int idUsuario)
        {
            this._idProducto = idProducto;
            this._descripcion = descripcion;
            this._costo = costo;
            this._precioVenta = precioVenta;
            this._stock = stock;
            this._idUsuario = idUsuario;
        }
    }
}
