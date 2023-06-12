using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddScoped<IArea, AreaService>();
builder.Services.AddScoped<IEvents, EventsService>();
builder.Services.AddScoped<IEventsResult,EventsResultService>();
builder.Services.AddScoped<IGrades,GradesService>();
builder.Services.AddScoped<IParents,ParentsService>();
builder.Services.AddScoped<ISchool,SchoolService>();
builder.Services.AddScoped<IStudent,StudentService>();
builder.Services.AddScoped<ISubject,SubjectService>();

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
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.LoginPath = new PathString("/auth/login");
        });
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
