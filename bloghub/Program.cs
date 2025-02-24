using bloghub.Context;
using bloghub.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:4200")  // Chỉ cho phép frontend từ http://localhost:4200
            .AllowAnyMethod()  // Cho phép tất cả các phương thức HTTP
            .AllowAnyHeader()  // Cho phép tất cả các header
            .AllowCredentials());  // Nếu cần gửi cookies hoặc token
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDb")));

builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();


var app = builder.Build();

// Sử dụng CORS chính xác trước Authorization
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || !app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


