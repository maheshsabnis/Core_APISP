using Core_APISP.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CompanyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<DepartmentRepository>();

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

 

app.MapGet("/departments", async(DepartmentRepository repositry) =>
{
    try
    {
        var records = await repositry.GetAsync();
        return Results.Ok(records);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("get")
.WithOpenApi();

app.MapGet("/departments/{id}", async (DepartmentRepository repositry, int id) =>
{
    try
    {
        var record = await repositry.GetAsync(id);
        return Results.Ok(record);
    }
    catch (Exception ex)
    {
          return Results.BadRequest(ex.Message);    
    }
})
.WithName("getsingle")
.WithOpenApi();


app.MapPost("/departments", async (DepartmentRepository repository, Department dept) => 
{
    try
    {
        await repository.AddAsync(dept);
        return Results.Created($"/departments/{dept.DeptNo}", dept);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/departments/{id}", async (DepartmentRepository repository, int id, Department dept) =>
{
    try
    {
        if (id != dept.DeptNo)
        {
            return Results.BadRequest("DeptNo mismatch");
        }
        await repository.UpdateAsync(dept);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/departments/{id}", async (DepartmentRepository repository, int id) =>
{
    try
    {

        await repository.DeleteAsync(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();

 
