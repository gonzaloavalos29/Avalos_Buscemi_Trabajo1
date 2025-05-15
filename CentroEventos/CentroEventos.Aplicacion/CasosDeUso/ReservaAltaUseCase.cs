using System;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase {
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ReservaAltaUseCase(IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IrepositorioPersona repoPersona, IServicioAutorizacion servicioAutorizacion) {
        _repoReserva = repoReserva;
        _repoEvento = repoEvento;
        _repoPersona = repoPersona;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Reserva datosReserva, int idUsuario) {
// Validar que el usuario esta autorizado
        if (!_servicioAutorizacion.EstaAutorizado(idUsuario))
            throw new FalloAutorizacionException("Usuario no autorizado.");
// Validar que la persona existe
        var persona = _repoPersona.BuscarPorId(datosReserva.PersonaId);
        if (persona == null) 
            throw new EntidadNotFoundException("Persona no encontrada.");
// Validar que el evento existe
        var evento = _repoEvento.BuscarPorId(datosReserva.EventoDeportivoId);
        if (evento == null)
            throw new EntidadNotFoundException("Evento no encontrado.");
// Validar que la persona no tenga ya una reserva para este evento
        var reservas = _repoReserva.ListarPorEvento(evento.Id);
        if (reservas.Any(r => PersonaId == datosReserva.PersonaId))
            throw new DuplicadoException("La persona ya tiene una reserva para este evento.");
// Validar que el evento tiene cupo disponible
        if (reservas.Count() >= evento.CupoMaximo)
            throw new CupoExcedidoException("No hay cupos disponibles para este evento.");
// Completar datos de la reserva antes de guardar
        datosReserva.FechaAltaReserva = DateTime.Now;
        datosReserva.EstadoAsistencia = EstadoAsistencia.Pendiente;
// Agregar la reserva al repositorio
        _repoReserva.Agregar(datosReserva);
    }
}