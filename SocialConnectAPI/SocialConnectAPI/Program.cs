using Microsoft.EntityFrameworkCore;
using SocialConnectAPI.Repositorys;
using SocialConnectAPI.Repositorys.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SocialConnectAPI", Version = "v1" });//ovo nam treba da bi videli dokumentaciju
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);  //ovo je da koristi komentare
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddControllers(setup =>
{
    setup.ReturnHttpNotAcceptable = true;//kad neko posalje format koji nije prihvacen vraca error 406 format not acceptable
}).AddXmlDataContractSerializerFormatters();//dodat xml formater da mi mogli raditi sa xml formatom;
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IKorisnikRepository, KorisnikRepository>();
builder.Services.AddScoped<IObjaveRepository, ObjavaRepository>();
builder.Services.AddScoped<IKomentarRepository, KomentarRepository>();

builder.Services.AddDbContext<DatabaseContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DCS")).LogTo(Console.Write, LogLevel.Information);
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
