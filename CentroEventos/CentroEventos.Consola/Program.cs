using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Repositorios;

// Crear una instancia del repositorio
var repo = new RepositorioPersona();
var repoevento = new RepositorioEventoDeportivo();

Console.WriteLine("== Agregar persona ==");
Console.Write("Nombre: ");
string? nombre = Console.ReadLine();

Console.Write("Apellido: ");
string? apellido = Console.ReadLine();

Console.Write("DNI: ");
string? dni = Console.ReadLine();

Console.Write("Email: ");
string? email = Console.ReadLine();

Console.Write("Telefono: ");
string? telefono = Console.ReadLine();

// Agregar una persona
var persona = new Persona
{
    Nombre = nombre ?? "",
    Apellido = apellido ?? "",
    DNI = dni ?? "",
    Email = email ?? "",
    Telefono= telefono ?? ""
};

var agregarPersona = new PersonaAltaUseCase(repo);
Console.WriteLine($"Persona agregada con ID: {persona.Id}");

// Listar personas
Console.WriteLine("Listado de personas:");
foreach (var p in repo.Listar()) {
    Console.WriteLine($"{p.Id}: {p.Nombre} {p.Apellido} - DNI: {p.DNI} - Email: {p.Email}");
}

// Buscar por ID
Console.Write("\nIngrese el ID de la persona a buscar: ");
string? inputBuscar = Console.ReadLine();
if (int.TryParse(inputBuscar, out int idBuscar)) {
    var encontrada = repo.ObtenerPorId(idBuscar);
    if (encontrada is not null) {
        Console.WriteLine($"Encontrada: {encontrada.Nombre} {encontrada.Apellido}");
        var modificarPersona = new PersonaModificarUseCase(repo);
        // Modificar email
        Console.Write("Ingrese nuevo email para esta persona: ");
        string? nuevoEmail = Console.ReadLine();
        encontrada.Email = nuevoEmail ?? encontrada.Email;
        modificarPersona.Ejecutar(encontrada);
        Console.WriteLine($"Email modificado para persona con ID {encontrada.Id}");
    } else {
        Console.WriteLine($"No se encontró una persona con ID {idBuscar}.");
    }
} else {
    Console.WriteLine("ID inválido.");
}

// Eliminar persona
Console.WriteLine("Ingrese Id de la persona a eliminar: ");
string? inputEliminar = Console.ReadLine();
if (inputEliminar != "")
{
    if (int.TryParse(inputEliminar, out int idEliminar))
    {
        var eliminarPersona = new PersonaBajaUseCase(repo);
        eliminarPersona.Ejecutar(persona.Id);
        Console.WriteLine($"Persona con Id{persona.Id} eliminada");
    }
    else
    {
        Console.WriteLine("Id no encontrado");
    }
}

