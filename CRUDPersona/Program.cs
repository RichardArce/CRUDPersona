using CRUDPersonaBLL.Servicios.Persona;
using CRUDPersonaDAL;
using CRUDPersonaDAL.Repositorios.Persona;
using CRUDPersonaObjetos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Configurar la cadena de conexión a la base de datos y que lo tome el contexto de Entity Framework Core
builder.Services.AddDbContext<ProyectoPersonaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyeccion dependencia del repositorio
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();

//Inyeccion dependencia del servicio
builder.Services.AddScoped<IPersonaServicio, PersonaServicio>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(MapeoClases));








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Persona}/{action=Index}/{id?}");

app.Run();
