using FirstApp.Ioc.Configuration;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x =>
{
    x.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    x.SerializerSettings.Formatting= Newtonsoft.Json.Formatting.Indented;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExtention(builder.Configuration);
builder.Services.AddSwaggerGenNewtonsoftSupport();
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
