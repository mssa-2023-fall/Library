using DelayerMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole(option => option.FormatterName = "ConsoleFormater");
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.UseDelayer(new DelayOptions { MilliSecond = 1000 });
app.MapControllers();

app.Run();
