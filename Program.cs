using Microsoft.EntityFrameworkCore; // Para DbContext y Entity Framework
using Microsoft.AspNetCore.Identity; // Para Identity
using Npgsql.EntityFrameworkCore.PostgreSQL; // Para usar el proveedor de PostgreSQL
using Gestion_Del_Presupuesto.Data; // Asegúrate de que este `using` apunte a tu contexto de base de datos

var builder = WebApplication.CreateBuilder(args);

// Configurar el servicio de DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar servicios de ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Agregar servicios para controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitar autenticación y autorización
app.UseAuthentication();  // Asegúrate de agregar esto para que Identity funcione
app.UseAuthorization();

// Configurar las rutas predeterminadas de la aplicación
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");  // Cambiamos a la página de Login

app.Run();

