using Microsoft.Extensions.Options;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRandomService, RandomService>();

builder.Services.Configure<PersonSettings>(builder.Configuration.GetSection(nameof(PersonSettings)));
builder.Services.AddSingleton<IConfigureOptions<PersonSettings>, ConfigurePersonSettingsOptions>();

builder.Services.AddSingleton<IPostConfigureOptions<PersonSettings>, ConfigurePostPersonSettingsOptions>();

builder.Services.PostConfigureAll<PersonSettings>(settings =>
{
    settings.Nick = "Lion";
});

builder.Services.Configure<SlackApiSettings>("Dev", builder.Configuration.GetSection("SlackApi:DevChannel"));
builder.Services.AddSingleton<IConfigureOptions<SlackApiSettings>, ConfigureNameSlackApiSettingsOptions>();


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
