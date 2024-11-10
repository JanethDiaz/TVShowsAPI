using TVShowsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ITvShowService, TvShowService>();
builder.Services.AddAutoMapper(typeof(Program));

// Agregar soporte para CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()          
              .AllowAnyMethod()          
              .AllowAnyHeader();         
    });
});

var app = builder.Build();

// Configuración de la API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS
app.UseCors("AllowAllOrigins");  

app.UseAuthorization();
app.MapControllers();
app.Run();
