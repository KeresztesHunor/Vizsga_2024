
namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<AppDbContext, AppDbContext>();
            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(policy => {
                    policy
                        .WithOrigins(
                            "http://localhost:5500",
                            "http://127.0.0.1:5500"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    ;
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
