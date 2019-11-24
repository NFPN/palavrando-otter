using Firebase.Database;
using Firebase.Database.Query;
using PalavrandoSetup.Data;
using System;
using System.Threading.Tasks;

namespace PalavrandoSetup.Services
{
    internal class RealDatabaseService
    {
        private FirebaseClient FbaseClient { get; set; }

        public RealDatabaseService()
        {
            FbaseClient = new FirebaseClient("https://palavrando-otte2d.firebaseio.com/");
        }

        public async Task<PlayerInstance> GET()
        {
            var register = await FbaseClient
                .Child("PlayerData")
                .OrderByKey()
                .StartAt("search")
                .OnceAsync<PlayerInstance>();

            foreach (var line in register)
            {
                Console.WriteLine($"{line.Key} is {line.Object}");
            }

            return (register as PlayerInstance);
        }

        public async Task Post(PlayerData player)
        {
            var register = await FbaseClient
                .Child("PlayerData")
                .PostAsync(player.Score);
        }

        public async Task PUT()
        {
            await FbaseClient
               .Child("PlayerData")
               .Child("Score")
               .PutAsync(new PlayerData());
        }

        public async Task DELETE()
        {
            await FbaseClient
                  .Child("PlayerData")
                  .DeleteAsync();
        }
    }
}