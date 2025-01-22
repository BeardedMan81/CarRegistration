using CarRegistration.Server.Services;
using CarRegistration.Server.Hubs; // Import the SignalR Hub namespace

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:52931") // Allow your Angular app's origin
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Needed for SignalR
    });
});

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddSingleton<CarDataService>();
builder.Services.AddHostedService<CarRegistrationCheckerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Use CORS middleware
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add SignalR hub mapping
app.MapHub<CarHub>("/carHub"); // Map the CarHub for SignalR

app.MapFallbackToFile("/index.html");

app.Run();
