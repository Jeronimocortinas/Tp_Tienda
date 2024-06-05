using System;
using System.Collections.Generic;


class Tienda{
    public List<Producto> Productos { get; private set; }
    private double dineroEnCaja;

    public Tienda(){
        Productos = new List<Producto>();
        dineroEnCaja = 0;
    }

    public void AgregarProducto(Producto producto){
        Productos.Add(producto);
    }

    public void EliminarProducto(Producto producto){
        Productos.Remove(producto);
    }

    public void MostrarProductos(){
        Console.WriteLine("Listado de productos:");
        foreach (var producto in Productos){
            Console.WriteLine($"{producto.Nombre} - Precio: {producto.PrecioVenta} - Stock: {producto.Stock}");
        }
    }

    public double CobrarCompra(Carrito carrito, double cantidadPagada){
        double totalCompra = carrito.CalcularSubtotal();
        if (cantidadPagada >= totalCompra){
            double vuelto = cantidadPagada - totalCompra;
            dineroEnCaja += totalCompra;
            carrito.VaciarCarrito();
            return vuelto;
        }
        else{
            Console.WriteLine("Cantidad insuficiente de dinero.");
            return -1;
        }
    }


    public void AgregarProductoATienda(){
        Console.Write("Ingrese el nombre del nuevo producto: ");
        string nombreProducto = Console.ReadLine();
        Console.Write("Ingrese el costo del nuevo producto: ");
        double costoProducto;
        while (!double.TryParse(Console.ReadLine(), out costoProducto) || costoProducto <= 0){
            Console.WriteLine("El costo ingresado no es válido. Por favor, ingrese un número positivo.");
            Console.Write("Ingrese el costo del nuevo producto: ");
        }
        Console.Write("Ingrese la cantidad de stock inicial: ");
        int stockProducto;
        while (!int.TryParse(Console.ReadLine(), out stockProducto) || stockProducto < 0){
            Console.WriteLine("La cantidad ingresada no es válida. Por favor, ingrese un número entero no negativo.");
            Console.Write("Ingrese la cantidad de stock inicial: ");
        }
        Producto nuevoProducto = new Producto(nombreProducto, costoProducto, stockProducto);
        AgregarProducto(nuevoProducto);
    }
}