using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Repositories;

namespace TodoApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar um Builder de uma Web Application (Web Application é complexa -> Então usados o padrão
            //  Builder)
            var builder = WebApplication.CreateBuilder();

            // Configurar serviços (Injeção de Dependência)
            builder.Services.AddControllers();
            builder.Services.AddScoped<ITodoRepository, TodoRepository>();
            builder.Services.AddDbContext<TodoDbContext>();

            // Constroi a aplicação (builder.Build())
            var app = builder.Build();

            app.MapControllers();

            // Roda aplicação
            app.Run();
        }
    }
}
