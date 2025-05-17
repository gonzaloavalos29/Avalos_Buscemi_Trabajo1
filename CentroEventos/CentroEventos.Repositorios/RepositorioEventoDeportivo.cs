
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Repositorios;

namespace CentroEventos.Repositorios {
    public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo {
        private readonly string archivo = "Eventos/eventos.csv";
        private readonly string archivoId = "Eventos/ultimoId.txt";

        public void Guardar(EventoDeportivo evento) {
            int nuevoId = nuevoId;
            var linea = $"{evento.Id}, {evento.Nombre}, {evento.Fecha}";
            File.AppendAllLines(archivo, new[] { linea });
        }

        private int ObtenerNuevoId() {
            int ultimoId = File.Exists(archivoId) ? int.Parse(File.ReadAllText(archivoId)) : 0;
            int nuevoId = ultimoId + 1;
            File.WriteAllText(archivoId, nuevoId.ToString());
            return nuevoId;
        }
    }
}