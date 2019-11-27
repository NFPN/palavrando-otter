using Firebase.Database;
using Firebase.Database.Query;
using PalavrandoSetup.Data;
using System;
using System.Threading.Tasks;

namespace PalavrandoSetup.Services
{
    public class RealDatabaseService : IDisposable
    {
        private FirebaseClient FbaseClient { get; set; }

        public RealDatabaseService()
        {
            FbaseClient = new FirebaseClient("https://palavrando-otte2d.firebaseio.com/");
        }

        public async Task<PlayerInstance> GET()
        {
            try
            {
                var register = await FbaseClient
                .Child("PlayerData")
                .OrderByKey()
                .StartAt("search")
                .OnceAsync<PlayerInstance>();

                return (register as PlayerInstance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Post(PlayerData player)
        {
            try
            {
                var register = await FbaseClient
                .Child("PlayerData")
                .PostAsync(player.Score);

                var register2 = await FbaseClient
                    .Child("PlayerInstance")
                    .PostAsync(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public void Dispose()
        {
            Dispose();
        }
    }
}