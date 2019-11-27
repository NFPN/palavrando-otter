using System.Collections.Generic;

namespace PalavrandoSetup.Data
{
    public class PlayerData
    {
        public string HashID { get; set; }
        public string Name { get; set; }
        public List<PlayerWords> Words { get; set; }
    }
}