using System;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;

namespace L03
{
    class Program
    {
        private static DriveService _service;
        static void Main(string[] args)
        {
            init();
        }

        static void init() {
            string[] scopes = new string[] {
                DriveService.Scope.Drive,
                DriveService.Scope.DriveFile
            };

            var clientId = "956028601337-c0edrb8aoqdrvuuhmon83j2vf56n3nnc.apps.googleusercontent.com";
            var clientSecret = "z5oJfTgAA2x5GRnhObc4fKqL";

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId ,
                    ClientSecret = clientSecret
                },
                scopes,
                Environment.UserName,
                CancellationToken.None,
                null
            ).Result;

            _service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });
        }
    }
}
