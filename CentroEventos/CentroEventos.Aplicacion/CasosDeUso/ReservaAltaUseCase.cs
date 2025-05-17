using System;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase {
    private readonly IRepositorioReserva _repoReserva;
    private readonly ValidadorReserva _validador;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public ReservaAltaUseCase(IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, IServicioAutorizacion servicioAutorizacion) {
        _repoReserva = repoReserva;
        _validador = new ValidadorReserva(_repoReserva,repoEvento,repoPersona);
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Reserva datosReserva, int idUsuario) {
// Validar que el usuario esta autorizado
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuario,Permiso.ReservaAlta))
            throw new FalloAutorizacionException();
            
// Usamos el validador de reserva
        _validador.Validar(datosReserva);

// Completar datos de la reserva antes de guardar

        datosReserva.FechaAltaReserva = DateTime.Now;
        datosReserva.EstadoAsistencia = EstadoAsistencia.Pendiente;
// Agregar la reserva al repositorio
        _repoReserva.Agregar(datosReserva);
    }
}