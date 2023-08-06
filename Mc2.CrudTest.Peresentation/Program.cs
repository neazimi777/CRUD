using Mc2.CrudTest.DomainService;
using Mc2.CrudTest.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureDomainServiceServices();

var app = builder.Build();
//ConfigureServices(builder);
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

///builder.Services.ConfigurePresentationServices();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


