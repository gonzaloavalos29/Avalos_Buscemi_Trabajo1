using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoAltaUseCase
{
    private IRepositorioEventoDeportivo _repoEvento;
    private readonly ValidadorEventoDeportivo _Validador;

    public EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona){
        _repoEvento = repoEvento;
        _Validador= new ValidadorEventoDeportivo(_repoEvento, repoPersona);
    }

    public void Ejecutar(EventoDeportivo evento){
        _Validador.Validar(evento);
        _repoEvento.Agregar(evento);
    }
}
