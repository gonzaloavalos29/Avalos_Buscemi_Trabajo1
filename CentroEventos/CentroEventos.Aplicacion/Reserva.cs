using System;

namespace CentroEventos.Aplicacion;

public class Reserva
{
    private int Id{get;set;}
    private int PersonaId{get;set;} 
    private int EventoDeportivoId{get;set;}
    private DateTime FechaAltaReserva{get;set;} //fecha y hora en la q se realizo la inscripcion
    private EstadoAsistencia EstadoAsistencia{get;set;}
}
