namespace CentroEventos.Aplicacion.Validadores;

public class ValidacionException:Exception {
    public ValidacionException(string m): base(m){} // la defino de esta forma para poder mandarle msg personalizados
}
