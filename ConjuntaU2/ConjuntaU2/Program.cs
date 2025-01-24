using ConjuntaU2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // O la base de datos que estés usando

// Otros servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de la solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();