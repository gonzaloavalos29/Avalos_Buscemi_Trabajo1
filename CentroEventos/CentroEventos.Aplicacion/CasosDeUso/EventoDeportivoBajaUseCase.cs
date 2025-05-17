using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoBajaUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEvento;
    private readonly IRepositorioReserva _repositorioReserva;

    public EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo,IRepositorioReserva repositorioReserva){
        _repositorioEvento=repositorioEventoDeportivo;
        _repositorioReserva=repositorioReserva;
    }

    public void Ejecutar(int Id){
        var del= _repositorioEvento.ObtenerPorId(Id)??throw new EntidadNotFoundException("Evento no encontrado");
        if(_repositorioReserva.ListarPorEvento(Id).Any())throw new OperacionInvalidaException("No se Puede eliminar un evento con reservas asociadas");
        _repositorioEvento.Eliminar(Id);
    }
}
