using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_PrimerosPasos
{
    public class ProductoVendido
    {
        private int _idProductoVendido;
        private int _idProducto;
        private long _stock;
        private int _idVenta;

        public int IdProductoVendido
        {
            get
            {
                //lógica
                return this._idProductoVendido;
            }
            set
            {
                //lógica
                this._idProductoVendido = value;
            }
        }
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
        public ProductoVendido() 
        {
            this._idProductoVendido = 0;
            this._idProducto = 0;
            this._stock = 0;   
            this._idVenta = 0;
        }
    public ProductoVendido(int idProductoVendido, int idProducto, long stock, int idVenta)
        {
            this._idProductoVendido = idProductoVendido;
            this._idProducto = idProducto;
            this._stock = stock;
            this._idVenta = idVenta;
        }

    }
}
