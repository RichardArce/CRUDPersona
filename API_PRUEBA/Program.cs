using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//CONSUMO DE API

app.MapGet("/api/Chiste", async () =>
{
    using var htttpClient = new HttpClient();
    var response = await htttpClient.GetAsync("https://api.chucknorris.io/jokes/random"); //ARCHIVO DE CONFIGURACION
    response.EnsureSuccessStatusCode();

    var json = await response.Content.ReadAsStringAsync();
    return Results.Content(json, "application/json"); //OBJECT RESULT

}).WithName("GetChiste");


var personas = new List<Persona>
{
    new Persona { Id = 1, Nombre = "Juan", Apellido = "Pérez", Edad = 30 },
    new Persona { Id = 2, Nombre = "Ana", Apellido = "Gómez", Edad = 25 },
    new Persona { Id = 3, Nombre = "Luis", Apellido = "Martínez", Edad = 40 }
};


app.MapGet("/api/Personas", () =>
{
    return Results.Ok(personas);
}).WithName("GetPersonas");

app.MapPost("/api/Persona", (Persona persona) =>
{
    if (persona == null)
    {
        return Results.BadRequest("Persona no puede ser nula.");
    }
    persona.Id = personas.Count + 1; // Simular ID autogenerado
    personas.Add(persona);
    return Results.Ok(persona);
});

app.MapDelete("/api/Persona/{id}", (int id) =>
{
    var personaABorrar = personas.Find(x => x.Id == id);

    if (personaABorrar != null)
    {
        personas.Remove(personaABorrar);
        return Results.Ok(true);

    }
    else
    {
        return Results.NotFound(false);
    }
});





app.Run();



public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }
}
