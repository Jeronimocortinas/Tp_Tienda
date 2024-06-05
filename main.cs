using System;
using System.Collections.Generic;


class Program{
  static void Main(string[] args){
      Tienda tienda = new Tienda();

      Carrito carrito = new Carrito();
      int opcion = 0;

      while (opcion != 7){
          Console.WriteLine("Menu:");
          Console.WriteLine("1. Mostrar productos");
          Console.WriteLine("2. Agregar productos a la tienda");
          Console.WriteLine("3. Agregar producto al carrito");
          Console.WriteLine("4. Eliminar producto del carrito");
          Console.WriteLine("5. Mostrar productos en el carrito");
          Console.WriteLine("6. Cobrar compra");
          Console.WriteLine("7. Salir");
          Console.Write("Seleccione una opción: ");
          string input = Console.ReadLine();
          if (!int.TryParse(input, out opcion)){
              Console.WriteLine("Por favor, ingrese un número válido.");
              continue;
          }
          switch (opcion){
              case 1:
                  tienda.MostrarProductos();
                  break;
              case 2:
                  tienda.AgregarProductoATienda();
                  break;
              case 3:
                  Console.Write("Ingrese el nombre del producto que desea agregar al carrito: ");
                  string nombreProductoAgregar = Console.ReadLine();
                  Console.Write("Ingrese la cantidad: ");
                  string cantidadAgregarStr = Console.ReadLine();
                  int cantidadAgregar;
                  if (!int.TryParse(cantidadAgregarStr, out cantidadAgregar) || cantidadAgregar <= 0){
                      Console.WriteLine("La cantidad ingresada no es válida.");
                      break;
                  }
                  Producto productoSeleccionado = tienda.Productos.Find(p => p.Nombre == nombreProductoAgregar);
                  if (productoSeleccionado != null){
                      carrito.AgregarProducto(productoSeleccionado, cantidadAgregar);
                  }
                  else{
                      Console.WriteLine("Producto no encontrado.");
                  }
                  break;
              case 4:
                  Console.Write("Ingrese el nombre del producto que desea eliminar del carrito: ");
                  string nombreProductoEliminar = Console.ReadLine();
                  Console.Write("Ingrese la cantidad: ");
                  string cantidadEliminarStr = Console.ReadLine();
                  int cantidadEliminar;
                  if (!int.TryParse(cantidadEliminarStr, out cantidadEliminar) || cantidadEliminar <= 0){
                      Console.WriteLine("La cantidad ingresada no es válida.");
                      break;
                  }
                  carrito.EliminarProducto(nombreProductoEliminar, cantidadEliminar);
                  break;
              case 5:
                  carrito.MostrarProductos();
                  break;
              case 6:
                  double subtotal = carrito.CalcularSubtotal();
                  Console.WriteLine($"Precio a pagar: {subtotal}");
                  Console.Write("Ingrese la cantidad pagada: ");
                  string cantidadPagadaStr = Console.ReadLine();
                  double cantidadPagada;
                  if (!double.TryParse(cantidadPagadaStr, out cantidadPagada) || cantidadPagada <= 0){
                      Console.WriteLine("La cantidad ingresada no es válida.");
                      break;
                  }
                  double vuelto = tienda.CobrarCompra(carrito, cantidadPagada);
                  if (vuelto >= 0){
                      Console.WriteLine($"Compra realizada con éxito. Su vuelto es: {vuelto}");
                  }
                  break;
              case 7:
                  Console.WriteLine("Hasta la proxima");
                  break;
              default:
                  Console.WriteLine("Ingrese una opcion valida");
                  break;
          }
      } while (opcion != 7);
  }
}
