using CloudStorage.Application.UseCases.Users.UploadProfilePic;
using CloudStorage_Rocketseat.Domain.Storage;
using CloudStorage_Rocketseat.Infraestructure.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUploadProfilePicUseCase, UploadProfilePicUseCase>();
builder.Services.AddScoped<IStorageService>(options =>
{
    var clientId = builder.Configuration.GetValue<string>("CloudStorage: ClientId");
    var clientSecret = builder.Configuration.GetValue<string>("CloudStorage: ClientSecret");

    var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new ClientSecrets
        {
            ClientId = clientId,
            ClientSecret = clientSecret
        },
        Scopes = [Google.Apis.Drive.v3.DriveService.Scope.Drive],
        DataStore = new FileDataStore("GoogleDriveTest") //Nome do seu projeto no Google Cloud
    });
    
    return new GoogleDriveStorageService(apiCodeFlow);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
