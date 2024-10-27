using FormulaOne.BAL.Handlers.DriverHandlers;
using FormulaOne.BAL.Services.Implementation;
using FormulaOne.BAL.Services.Interfaces;
using FormulaOne.DAL.Data;
using FormulaOne.DAL.Repositories.Impelementations;
using FormulaOne.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace FormulaOne.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDriverService, DriverService>();
            builder.Services.AddScoped<IAchievementService, AchievementService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //inject MediatR in DI
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetAllQueryHandler).Assembly));

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
}
