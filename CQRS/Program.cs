using CQRS.CommandHandle;
using CQRS.Data;
using CQRS.Models;
using CQRS.QueryHandle;
using CQRS.Reposiotry;
using CQRS.Repository;
using CQRS.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;

using CQRS.Command;
using CQRS.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Configura o contexto do banco de dados (ProductDbContext)
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adiciona os serviços necessários à injeção de dependências


builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    });


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, Productservice>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<DeleteProductHandler>();
builder.Services.AddScoped<UpdaterProductHandler>();
builder.Services.AddScoped<GetProductByIdHandler>();
builder.Services.AddScoped<GetProductAllHandler>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Configuração do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisições da aplicação
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Ativa o Swagger e a UI do Swagger em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); // Define o endpoint da documentação
    });
}

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
