using Microsoft.EntityFrameworkCore;
using Pedidos.API.Extensoes;
using Pedidos.Infraestrutura.Context;
using Pedidos.Infraestrutura.Mapeamentos;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PedidoDbContexto>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("PedidoContext")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.RegistrarDependencias();
var app = builder.Build();
app.Services.Migrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
