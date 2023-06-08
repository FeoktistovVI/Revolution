using Microsoft.EntityFrameworkCore;
using Revolution.Data;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Services;
using Revolution.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddDbContext < AplicationContext > (options => options.UseNpgsql("Host=localhost;Port=5432;Database=revolution;Username=postgres;Password=1"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7275",
                    "http://www.contoso.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Revolution.Service Injected



#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(x => { x.SerializeAsV2 = true; });
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //x.RoutePrefix = "atashol";
    });

}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
