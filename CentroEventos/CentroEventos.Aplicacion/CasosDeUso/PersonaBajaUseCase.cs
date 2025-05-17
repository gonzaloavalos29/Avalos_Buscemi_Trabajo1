using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;

    public PersonaBajaUseCase(IRepositorioPersona repositorioPersona){
        _repositorioPersona=repositorioPersona;
    }

    public void Ejecutar(int Id){
        var PersonaEliminar =_repositorioPersona.ObtenerPorId(Id)?? throw new EntidadNotFoundException("Persona no encontrada");
        if(_repositorioPersona.EsResponsable(Id)|| _repositorioPersona.TieneReservas(Id))
            throw new OperacionInvalidaException("La persona no puede eliminarse");
        _repositorioPersona.Eliminar(Id);
    }
}
