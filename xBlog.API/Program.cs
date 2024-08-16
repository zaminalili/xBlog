using Microsoft.EntityFrameworkCore;
using xBlog.API.Data;
using xBlog.API.Mapping;
using xBlog.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ****
//
// database connection
builder.Services.AddDbContext<xBlogDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("xBlogConnectionString")));

// config repositories
builder.Services.AddScoped<ICategoryRepository, SqlCategoryRepository>();
builder.Services.AddScoped<IUserRepository, SqlUserRepository>();
builder.Services.AddScoped<IBlogRepository, SqlBlogRepository>();

// automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

//
// ****


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
