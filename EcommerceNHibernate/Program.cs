using EcommerceNHibernate.Aplication.Service;
using EcommerceNHibernate.Domain.Interfaces;
using EcommerceNHibernate.Persistance;
using EcommerceNHibernate.Persistance.Repository;
using EcommerceNHibernate.Persistance.UnitOfWork;
using NHibernate;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var configuration = builder.Configuration;

var sessionFactory = NHibernateConfiguration.CreateSessionFactory(configuration);
builder.Services.AddSingleton(sessionFactory);
builder.Services.AddTransient<ISession>(provider =>
{
    var sessionFactory = provider.GetRequiredService<ISessionFactory>();
    return sessionFactory.OpenSession();
});



var app = builder.Build();
app.Use(async (context, next) =>
{
    var session = app.Services.GetRequiredService<ISession>();
    context.Items["NHibernateSession"] = session;
    await next();
});


app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();



app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.Run();
