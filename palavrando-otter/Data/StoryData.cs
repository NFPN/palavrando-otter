namespace palavrando_otter.Data
{
    public class StoryData
    {
        public string PlayerHashID { get; set; }
        public string HashID { get; set; }
        public string Story { get; set; }

        public StoryData(string playerHashId, string hashId,string story)
        {
            PlayerHashID = playerHashId;
            HashID = hashId;
            Story = story;
        }
    }
}