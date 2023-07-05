
using MendozaMejia_ForoControlRollback.Models;

class Program
{
    static void Main(string[] args)
    {
        agregarPedidoTransaction();
    }

    private static void agregarPedidoTransaction()
    {
        Console.WriteLine("Metodo agregar persona haciendo uso del control de transacciones");
        ForoBdRollbackContext context = new ForoBdRollbackContext();

        Empleado stdEmpleado = new Empleado();
        Cliente stdCliente = new Cliente();
        Pedido stdPedido = new Pedido();

        var dbContextTransaction = context.Database.BeginTransaction();

        try
        {
            //Añade a la tabla Empleado
            stdEmpleado.Nombre = "Juan";
            stdEmpleado.Direccion = "AV siempre viva";
            stdEmpleado.Telefono = "0987654321";
            stdEmpleado.Salario = 150;
            stdEmpleado.Estado = true;
            context.Empleados.Add(stdEmpleado);
            context.SaveChanges();

            //Añade a la tabla Cliente
            stdCliente.Nombre = "Jose";
            stdCliente.Apellido = "Perez";
            stdCliente.Direccion = "10 de octubre y venezuela";
            stdCliente.Telefono = "1234567890";
            stdCliente.FechaNacimiento = Convert.ToDateTime("1999-10-02");
            stdCliente.Estado = true;
            context.Clientes.Add(stdCliente);
            context.SaveChanges();

            //Añade a la tabla Pedido
            stdPedido.FechaPedido = Convert.ToDateTime("2015-09-02");
            stdPedido.ClienteId = stdCliente.ClienteId;
            stdPedido.EmpleadoId = stdEmpleado.EmpleadoId;
            stdPedido.Estado = true;
            context.Pedidos.Add(stdPedido);
            context.SaveChanges();

            if (string.IsNullOrEmpty(stdPedido.FechaPedido.ToString()))
            {
                Console.WriteLine("Se ha ingresado algun campo vacío. Rollback ejecutado.");
                dbContextTransaction.Rollback();
            }
            else
            {
                dbContextTransaction.Commit();
                Console.WriteLine("Datos ingresados");
            }

        }
        catch (Exception e)
        {
            dbContextTransaction.Rollback();
            Console.WriteLine("Error... " + e.ToString());
        }
    }
}
