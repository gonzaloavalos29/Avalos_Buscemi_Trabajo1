using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void Agregar(Reserva reserva);
    void Modificar(Reserva reserva);
    void Eliminar(int Id);
    Boolean ExisteReserva(int EventoId, int PersonaId);
    List<Reserva> Listar();
    List<Reserva> ListarPorEvento(int Id);

}
