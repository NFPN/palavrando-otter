using System.Collections.Generic;

namespace palavrando_otter.Data
{
    public class WordData
    {
        public string HashID { get; set; }
        public List<string> Words { get; set; }

        public WordData(string HashId,List<string> words)
        {
            this.HashID = HashId;

            foreach (var word in words)
            {
                Words.Add(word);
            }
        }
    }

    
}