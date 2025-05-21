using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoAltaUseCase
{
    private IRepositorioEventoDeportivo _repoEvento;
    private readonly ValidadorEventoDeportivo _Validador;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repoEvento = repoEvento;
        _Validador = new ValidadorEventoDeportivo(_repoEvento, repoPersona);
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(EventoDeportivo evento, int idUsuario){
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
                throw new UnauthorizedAccessException("El usuario no tiene permiso para crear eventos.");
        _Validador.Validar(evento);
        _repoEvento.Agregar(evento);
    }
}
