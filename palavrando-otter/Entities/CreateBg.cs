using Otter;

namespace Palavrando.Entities
{
    class CreateBg : Entity
    {
        public CreateBg()
        {
            Image spritemap = new Image(@"C:\Vs\Natanael\REPOS\palavrando-otter\palavrando-otter\Images\bg-room.png");

            //spritemap.CenterOrigin();
            spritemap.CenterOriginZero();

            // Add the graphic to the Entity so that it renders.
            AddGraphic(spritemap);
        }
    }
}