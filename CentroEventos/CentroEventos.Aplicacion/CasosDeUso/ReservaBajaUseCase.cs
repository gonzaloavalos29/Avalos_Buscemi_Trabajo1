using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaBajaUseCase
{
    private readonly IRepositorioReserva _repo;

    public ReservaBajaUseCase(IRepositorioReserva repo){
        _repo= repo;
    }

    public void Ejecutar(int Id){
        var del = _repo.ObtenerPorId(Id)??throw new EntidadNotFoundException("Reserva no encontrada");
        _repo.Eliminar(Id);
    }
}
