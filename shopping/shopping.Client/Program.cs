using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajouter HttpClient nommé pour appeler shopping.API
builder.Services.AddHttpClient("ShoppingApi", client =>
{
    client.BaseAddress = new Uri(configuration["shoppingAPIURL"]);
    //client.BaseAddress = new Uri("http://host.docker.internal:5206/"); // correspond au port d’écoute de l’API
});

//builder.Services.AddScoped<ShoppingApiService>(); // Service personnalisé pour appeler l'API

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
