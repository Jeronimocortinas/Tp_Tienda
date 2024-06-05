using System;
using System.Collections.Generic;


class Carrito
{
    private Dictionary<Producto, int> items;

    public Carrito()
    {
        items = new Dictionary<Producto, int>();
    }

    public void AgregarProducto(Producto producto, int cantidad)
    {
        if (producto.Stock >= cantidad)
        {
            if (items.ContainsKey(producto))
            {
                items[producto] += cantidad;
            }
            else
            {
                items.Add(producto, cantidad);
            }
            producto.Stock -= cantidad;
        }
        else
        {
            Console.WriteLine("No hay suficiente stock para este producto.");
        }
    }

    public void EliminarProducto(string nombreProducto, int cantidad)
    {
        Producto productoAEliminar = null;
        foreach (var item in items.Keys)
        {
            if (item.Nombre == nombreProducto)
            {
                productoAEliminar = item;
                break;
            }
        }

        if (productoAEliminar != null)
        {
            if (items[productoAEliminar] > cantidad)
            {
                items[productoAEliminar] -= cantidad;
                productoAEliminar.Stock += cantidad;
            }
            else
            {
                productoAEliminar.Stock += items[productoAEliminar];
                items.Remove(productoAEliminar);
            }
        }
        else
        {
            Console.WriteLine("Producto no encontrado en el carrito.");
        }
    }

    public void MostrarProductos()
    {
        Console.WriteLine("Productos en el carrito:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key.Nombre} - Cantidad: {item.Value} - Precio unitario: {item.Key.PrecioVenta}");
        }
    }

    public double CalcularSubtotal()
    {
        double subtotal = 0;
        foreach (var item in items)
        {
            subtotal += item.Key.PrecioVenta * item.Value;
        }
        return subtotal;
    }

    public void VaciarCarrito()
    {
        items.Clear();
    }
}
