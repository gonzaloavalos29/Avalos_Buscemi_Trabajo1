using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase
{
    private readonly IRepositorioPersona _repo;
    private readonly ValidadorPersona _validador;
    public PersonaAltaUseCase(IRepositorioPersona repo){
        _repo=repo;
        _validador= new ValidadorPersona(repo);
    }

    public void Ejecutar(Persona persona){
        _validador.Validar(persona);
        _repo.Agregar(persona);
    }
}
