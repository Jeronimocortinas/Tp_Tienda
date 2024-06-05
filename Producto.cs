using System;
using System.Collections.Generic;


class Producto{
    public string Nombre { get; }
    public double Costo { get; }
    public double PrecioVenta { get; }
    public int Stock { get; set; }

    public Producto(string nombre, double costo, int stock){
        if (string.IsNullOrEmpty(nombre) || costo <= 0){
            throw new ArgumentException("Nombre y costo son obligatorios");
        }
        Nombre = nombre;
        Costo = costo;
        PrecioVenta = costo * 1.3;
        Stock = stock;
    }
}
