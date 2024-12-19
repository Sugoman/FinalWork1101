using Library.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddDbContext<FragrantWorldContext>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Fragrant World API",
        Version = "v1",
        Description = "API предназанченное для редактирования, добавления и удаления строк в БД",
        Contact = new OpenApiContact
        {
            Name = "Александр",
            Url = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley")

        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.RoutePrefix = string.Empty;
        c.InjectStylesheet("/swagger-ui/custom.css"); // Пример добавления кастомных стилей
    });
}


app.MapControllers();

app.Run();