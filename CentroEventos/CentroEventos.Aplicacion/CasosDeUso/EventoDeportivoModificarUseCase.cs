using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoModificarUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly ValidadorEventoDeportivo _Validar;

    public EventoDeportivoModificarUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repoPersona)
    {
        _repoEvento = repositorioEventoDeportivo;
        _Validar = new ValidadorEventoDeportivo(repoPersona, repositorioEventoDeportivo);
    }

    public void Ejecutar(EventoDeportivo evento)
    {
        var mod = _repoEvento.ObtenerPorId(evento.Id) ?? throw new EntidadNotFoundException("El evento no existe");
        if (evento.FechaHoraInicio < DateTime.Now) throw new OperacionInvalidaException("No se puede modificar un evento terminado");

        _Validar.Validar(evento);
        _repoEvento.Modificar(evento);
    }
}
