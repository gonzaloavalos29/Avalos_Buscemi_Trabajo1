using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.CasosDeUso;

var servicioAutorizacion = new servicioAutorizacionProvisorio();
var repoEvento = new RepositorioEventoDeportivo();
var useCase = new CrearEventoUseCase(servicioAutorizacion, repoEvento);

try {
    useCase.Ejecutar(1, new EventoDeportivo { Nombre = "Torneo Futbol", Fecha = DateTime.Today});
    Console.WriteLine("Evento creado correctamente.");
} catch (UnauthorizedAccessException ex) {
    Console.WriteLine(ex.Message);
}