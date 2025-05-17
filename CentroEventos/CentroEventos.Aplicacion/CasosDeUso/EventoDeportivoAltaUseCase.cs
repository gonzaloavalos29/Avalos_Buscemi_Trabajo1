using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoAltaUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly ValidadorEventoDeportivo _Validador;

    public EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioPersona _repoPersona){
        _repoEvento=repoEvento;
        _Validador= new ValidadorEventoDeportivo(_repoPersona,_repoEvento);
    }

    public void Ejecutar(EventoDeportivo evento){
        _Validador.Validar(evento);
        _repoEvento.Agregar(evento);
    }
}
