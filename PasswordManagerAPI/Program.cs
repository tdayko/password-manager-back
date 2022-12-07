using PasswordManagerAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();
app.MapControllers();

app.Run();