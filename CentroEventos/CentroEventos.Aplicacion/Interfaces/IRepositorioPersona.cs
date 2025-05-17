using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void Agregar(Persona persona);
    void Eliminar(int Id);
    void Modificar(Persona persona);
    Boolean TieneReservas(int Id);
    Boolean EsResponsable(int Id);
    Persona? ObtenerPorId(int Id);
    Persona? ObtenerPorDni(string DNI);
    Persona? ObtenerPorEmail(string Email);
    List<Persona> Listar();

}
