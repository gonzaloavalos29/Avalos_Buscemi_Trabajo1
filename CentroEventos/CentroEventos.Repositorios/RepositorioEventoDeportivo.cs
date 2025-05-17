
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Repositorios {
    public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo {
        private readonly string archivo = "Eventos/eventos.csv";
        private readonly string archivoId = "Eventos/ultimoId.txt";

        public void Agregar(EventoDeportivo eventoDeportivo)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(EventoDeportivo evento) {
            int nuevoId = ObtenerNuevoId();
            evento.Id = nuevoId;
            var linea = $"{evento.Id}, {evento.Nombre}, {evento.FechaHoraInicio}";
            Directory.CreateDirectory("Eventos");
            File.AppendAllLines(archivo, new[] { linea });
        }

        public List<EventoDeportivo> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Modificar(EventoDeportivo eventoDeportivo)
        {
            throw new NotImplementedException();
        }

        public EventoDeportivo? ObtenerPorId(int Id)
        {
            throw new NotImplementedException();
        }

        private int ObtenerNuevoId() {
            if (!File.Exists(archivoId))
                File.WriteAllText(archivoId, "0");
            int ultimoId = int.Parse(File.ReadAllText(archivoId));
            int nuevoId = ultimoId + 1;
            File.WriteAllText(archivoId, nuevoId.ToString());
            return nuevoId;
        }
    }
}