using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaListarUseCase
{
    private readonly IRepositorioPersona repositorioPersona;

    public PersonaListarUseCase(IRepositorioPersona repo){
        repositorioPersona=repo;
    }

    public List<Persona> Ejecutar(){
        return repositorioPersona.Listar();
    }
}
