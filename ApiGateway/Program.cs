var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// YARP
// add json file
builder.Configuration.AddJsonFile("yarp.json", false, true);

// for sample
// read more https://microsoft.github.io/reverse-proxy/articles/getting-started.html
// go to address /api/order/product/GetProducts
// go to address /api/user/customer/GetCustomers
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("Yarp"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// YARP
app.MapReverseProxy();

app.Run();