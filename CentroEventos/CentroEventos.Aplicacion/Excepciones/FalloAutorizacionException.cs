using System;

namespace CentroEventos.Aplicacion;

public class FalloAutorizacionException:Exception
{
    public FalloAutorizacionException(): base("No autorizado"){}
}
