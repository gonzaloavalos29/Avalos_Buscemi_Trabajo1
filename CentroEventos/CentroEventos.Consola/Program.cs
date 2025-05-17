using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Servicios;

var servicioAutorizacion = new ServicioAutorizacionProvisorio();
var repoEvento = new RepositorioEventoDeportivo();
var useCase = new CrearEventoUseCase(servicioAutorizacion, repoEvento);

try {
    useCase.Ejecutar(1, new EventoDeportivo { Nombre = "Torneo Futbol", FechaHoraInicio = DateTime.Today});
    Console.WriteLine("Evento creado correctamente.");
} catch (UnauthorizedAccessException ex) {
    Console.WriteLine(ex.Message);
}