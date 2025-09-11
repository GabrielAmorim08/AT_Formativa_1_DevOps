using ATV_Formativa.Web.API.Utils;
using ATV_Formativa.WebAPI.Utils;
using ATV_Formativa.WebAPI.Wrapper;
using ATV_Formativa.WebAPI.Wrapper.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();

builder.Services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddTransient<IDbWrapper>(sp => {
    var factory = sp.GetRequiredService<IDbConnectionFactory>();
    return new DbWrapper(factory, Common.DataBase.ConnDB);
});
builder.Services.AddTransient<IDbWrapperFactory, DbWrapperFactory>();
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATV_Formativa API V1");
    c.RoutePrefix = string.Empty; 
});
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
Common.ConnDB = builder.Configuration.GetConnectionString("ConnDB") ?? string.Empty;

app.Run();
