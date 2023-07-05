using System;
using System.Collections.Generic;

namespace MendozaMejia_ForoControlRollback.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public int? ClienteId { get; set; }

    public int? EmpleadoId { get; set; }

    public bool? Estado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
