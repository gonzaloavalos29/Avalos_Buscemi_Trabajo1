namespace CentroEventos.Aplicacion;
public class Persona
{
    private int Id {get;set;}
    private string DNI{get;set;}="";
    private string Nombre{get;set;}="";
    private string Apellido{get;set;}="";
    private string Email{get;set;}="";
    private string Telefono{get;set;}="";

    public override string ToString()=>$"[{Id}], {Nombre} {Apellido}: DNI: {DNI}, Email: {Email}, Telefono: {Telefono}";
    
}
