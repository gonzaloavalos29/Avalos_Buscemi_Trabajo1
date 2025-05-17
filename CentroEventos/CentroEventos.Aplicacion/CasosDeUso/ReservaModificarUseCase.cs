using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaModificarUseCase
{
    private readonly IRepositorioReserva _repo;


    public ReservaModificarUseCase(IRepositorioReserva repo){
        _repo=repo;
    }

    public void Ejecutar(Reserva reserva){
        var mod=_repo.ObtenerPorId(reserva.Id)??throw new EntidadNotFoundException("Reserva no encontrada");
        _repo.Modificar(reserva);
    }
}
