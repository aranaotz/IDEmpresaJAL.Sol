using IDEmpresaJAL.DAL.Data;
using IDEmpresaJAL.IoC.IRepository;
using IDEmpresaJAL.IoC.Repository;
using Microsoft.EntityFrameworkCore;
using IDEmpresaJAL.BLL.IRepository;
using IDEmpresaJAL.BLL.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//logica para el loggeo
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Acceso/Acceso/Login"; // formulario de login
        option.ExpireTimeSpan= TimeSpan.FromMinutes(20); //minutos que dura  la sesion
    });


var connectionString = builder.Configuration.GetConnectionString("cnn") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//agregar contenedor de tabajo al contenedor IoC de inyecccion de dependencias
builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();

builder.Services.AddScoped<IUtilidadesRepository, UtilidadesRepository>();


var app = builder.Build();

app.UseStatusCodePagesWithRedirects("~/Acceso/Acceso/Error/{0}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Gestion/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//agregado para que pueda iniciar sesion
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Acceso}/{controller=Acceso}/{action=Login}/{id?}");

app.Run();
