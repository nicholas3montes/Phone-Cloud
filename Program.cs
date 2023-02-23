using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phone_Cloud.Data;
using Phone_Cloud.Repositories;
using Phone_Cloud.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<DbUserContext>(
                options => options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=inicial1234"));

        builder.Services.AddScoped<IUserRepository, UserRepository>();

        var app = builder.Build();



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
    }
}