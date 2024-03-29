var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()
));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddSingleton<KnownMetricStore>();
builder.Services.Configure<SparkplugDataAdapterOptions>(configuration.GetSection("SparkplugDataAdapterOptions"));
builder.Services.AddSingleton<SparkplugDataAdapter>();

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(configuration);
builder.Services.AddInfluxDbInfrastructure(configuration);

builder.Services.AddHostedService<SparkplugWorkerService>();

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

app.MapHub<WebSocketHub>("/websockethub");

app.Run();
