using CentroEventos.Aplicacion.Servicios;

var servicioAutorizacion = new ServicioAutorizacionProvisorio();

int usuarioId = 1;
var permiso = Permiso.EventoAlta;

bool tienePermiso = servicioAutorizacion.PoseeElPermiso(usuarioId, permiso);

Console.WriteLine($"¿El usuario {usuarioId} tiene el permiso {permiso}? {tienePermiso}");