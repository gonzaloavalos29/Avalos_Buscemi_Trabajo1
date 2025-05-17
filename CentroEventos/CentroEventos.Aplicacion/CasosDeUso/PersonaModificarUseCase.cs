using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaModificarUseCase
{
    private readonly IRepositorioPersona repositorioPersona;
    private readonly ValidadorPersona _validador;

    public PersonaModificarUseCase(IRepositorioPersona repo){
        repositorioPersona=repo;
        _validador= new ValidadorPersona(repo);
    }

    public void Ejecutar(Persona persona){
        var add = repositorioPersona.ObtenerPorId(persona.Id)?? throw new EntidadNotFoundException("Persona no encontrada");
        _validador.Validar(persona);
        repositorioPersona.Modificar(persona);
    }
}
