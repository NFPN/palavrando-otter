using Firebase.Database;
using Firebase.Database.Query;
using PalavrandoSetup.Data;
using System.Threading.Tasks;

namespace PalavrandoSetup.Services
{
    class RealDatabaseService
    {
        private FirebaseClient FbaseClient { get; set; }

        public RealDatabaseService()
        {
            FbaseClient = new FirebaseClient("https://senacbaset5.firebaseio.com/");
        }

        public async Task<ScoreData> GET()
        {
            var register = await FbaseClient
                .Child("Score")
                .OrderByKey()
                .StartAt("search")
                .OnceAsync<ScoreData>();

            return (register as ScoreData);
        }

        public async Task Post(PlayerData player)
        {
            var register = await FbaseClient
                .Child("Placar")
                .PostAsync(player.Score);
        }
    }
}