using System;

namespace CentroEventos.Aplicacion;

public class CupoExcedidoException:Exception
{
    public CupoExcedidoException():base("No hay cupo disponible"){}
}
