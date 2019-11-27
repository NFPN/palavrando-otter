using Otter;
using Palavrando.Systems;

namespace Palavrando.Entities
{
    public class CreateBg : Entity
    {
        public CreateBg(UIManager uIManager)
        {
            Image spritemap = new Image(PathFolder.GetDirectory() + @"\Images\bg-room2.png");

            spritemap.ScaleY = 1.3f;
            spritemap.ScaleX = 1.3f;

            //spritemap.CenterOrigin();
            spritemap.CenterOrigin();

            // Add the graphic to the Entity so that it renders.
            AddGraphic(spritemap,Game.Instance.HalfWidth -40, Game.Instance.HalfHeight - 2);
            AddGraphic(uIManager.GameScore);
        }
    }
}
