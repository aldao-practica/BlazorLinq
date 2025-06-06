using BlazorLinq;
using BlazorLinq.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
//builder.Services.AddHttpClient("Api", client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7216/"); // URL del backend
//});

builder.Services.AddHttpClient<IMoviesService, MoviesService>("Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7216/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
