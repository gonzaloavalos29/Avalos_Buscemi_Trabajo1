using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void Agregar(EventoDeportivo eventoDeportivo);
    void Modificar(EventoDeportivo eventoDeportivo);
    void Eliminar(int Id);

    EventoDeportivo? ObtenerPorId(int Id);
}
