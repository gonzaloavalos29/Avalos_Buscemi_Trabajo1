using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorReserva {
    private readonly IRepositorioReserva _repoReservas;
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioPersona _repoPersona;

    public ValidadorReserva(IRepositorioReserva repositorioReserva, IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioPersona repositorioPersona) {
        _repoEvento = repositorioEventoDeportivo;
        _repoReservas = repositorioReserva;
        _repoPersona = repositorioPersona;
    }
    public void Validar(Reserva reserva) {
            var Persona = _repoPersona.ObtenerPorId(reserva.PersonaId);
            if (Persona == null) {
                throw new EntidadNotFoundException("Persona no encontrada");
            }
            var EventoDeportivo = _repoEvento.ObtenerPorId(reserva.EventoDeportivoId);
            if (EventoDeportivo == null) {
                throw new EntidadNotFoundException("Evento Deportivo no encontrado");
            }
            var cantReservas = _repoReservas.ListarPorEvento(reserva.EventoDeportivoId).Count;
            if (cantReservas >= EventoDeportivo.CupoMaximo) {
                throw new CupoExcedidoException();
            }
            if (_repoReservas.ExisteReserva(reserva.PersonaId, reserva.EventoDeportivoId)) {
                throw new DuplicadoException("La Persona ya tiene una reserva para este evento");
            }
    }
}