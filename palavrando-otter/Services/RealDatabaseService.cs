using Firebase.Database;
using Firebase.Database.Query;
using Palavrando.FakeNameCreator;
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

        public async Task<PlayerWords> GET()
        {
            try
            {
                var register = await FbaseClient
                .Child("PlayerData")
                .OrderByKey()
                .StartAt("search")
                .OnceAsync<PlayerWords>();

                return (register as PlayerWords);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Post(PlayerName player)
        {
            try
            {
                var register = await FbaseClient
                .Child(player.ToString())
                .PostAsync(player);
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
            //Dispose();
            //GC.SuppressFinalize(this);
        }
    }
}