using ApiProdutos.Business;
using ApiProdutos.Context;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using EvolveDb;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
                    options.UseNpgsql(connection));

builder.Services.AddScoped(typeof(IDigitacaoValidation<>), typeof(DigitacaoValidation<>));
builder.Services.AddScoped<ArmazemBusiness>();
builder.Services.AddScoped<CategoriaBusiness>();
builder.Services.AddScoped<ContratoBusiness>();
builder.Services.AddScoped<FornecedorBusiness>();
builder.Services.AddScoped<ItemArmazemBusiness>();
builder.Services.AddScoped<ItemContratoBusiness>();
builder.Services.AddScoped<ProdutoBusiness>();
builder.Services.AddScoped<SubcategoriaBusiness>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    MigrateDatabase(connection);
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDatabase(string? connection)
{
    try
    {
        var evolveConnection = new Npgsql.NpgsqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string>() { "db/migrations", "db/datasets" },
            IsEraseDisabled = true
        };
        evolve.Repair();
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Migra��o de banco de dados mal-sucedida", ex);
        throw;
    }
}