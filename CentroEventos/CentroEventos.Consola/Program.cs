using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Repositorios;

// Crear una instancia del repositorio
var repo = new RepositorioPersona();

// Agregar una persona
var persona = new Persona {
    Nombre = "Ana",
    Apellido = "Pérez",
    DNI = "12345678",
    Email = "ana.perez@email.com"
};

repo.Agregar(persona);
Console.WriteLine($"Persona agregada con ID: {persona.Id}");

// Listar personas
Console.WriteLine("Listado de personas:");
foreach (var p in repo.Listar()) {
    Console.WriteLine($"{p.Id}: {p.Nombre} {p.Apellido} - DNI: {p.DNI} - Email: {p.Email}");
}

// Buscar por ID
int idBuscar = 1;
var encontrada = repo.ObtenerPorId(idBuscar);
if (encontrada is not null) {
    Console.WriteLine($"Persona con ID {idBuscar}: {encontrada.Nombre} {encontrada.Apellido}");
} else {
    Console.WriteLine($"Persona con ID {idBuscar} no encontrada.");
}

// Modificar persona
if (encontrada is not null) {
    encontrada.Email = "nueva.direccion@email.com";
    repo.Modificar(encontrada);
    Console.WriteLine($"Persona con ID {encontrada.Id} modificada.");
}

// Eliminar persona
// repo.Eliminar(1);
// Console.WriteLine("🗑 Persona con ID 1 eliminada.");
