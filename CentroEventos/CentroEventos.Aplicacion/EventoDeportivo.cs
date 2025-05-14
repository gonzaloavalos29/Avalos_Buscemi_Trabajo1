using System;
using System.Dynamic;

namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    private int Id{get;set;}
    private string Nombre{get;set;}="";
    private string Descripcion{get;set;}="";
    private DateTime FechaHoraInicio{get;set;} //Fecha y hora de cuando inicia el evento
    private double DuracionHoras{get;set;}
    private int CupoMaximo{get;set;}
    private int ResponsableId{get;set;}  //id de la persona responsable
    

}
