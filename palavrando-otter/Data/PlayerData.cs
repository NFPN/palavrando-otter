using System.Collections.Generic;

namespace PalavrandoSetup.Data
{
    public class PlayerData
    {
        public string HashID { get; set; }
        public string Name { get; set; }
        public List<PlayerWords> Words { get; set; }

        public PlayerData(string hashId, string name,List<PlayerWords> words)
        {
            HashID = hashId;
            Name = name;

            foreach (var word in words)
            {
                Words.Add(word);
            }
        }
        public PlayerData()
        {

        }
    }
}