using PasswordManagerAPI.Data;
using PasswordManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run();