using NuoNuoSdk;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "NuoNuo SDK Sample API", Version = "v1" });
});

// 添加诺诺开放平台SDK
builder.Services.AddNuoNuoSdk(builder.Configuration, "NuoNuo");

// 示例：使用委托配置
// builder.Services.AddNuoNuoSdk(options =>
// {
//     options.AccessToken = "your_access_token";
//     options.Timeout = 15;
//     options.AppKey = "your_app_key";
//     options.AppSecret = "your_app_secret";
//     options.UserTax = "your_user_tax";
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NuoNuo SDK Sample API v1");
        c.RoutePrefix = string.Empty; // 设置Swagger UI为根路径
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
