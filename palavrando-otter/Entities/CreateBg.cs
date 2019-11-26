using Otter;
using Palavrando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palavrando_otter.Entities
{
    class CreateBg : Entity
    {
        public CreateBg()
        {
            Image spritemap = new Image(@"C:\Users\nicolas.ssoares\Documents\GitPortable\GitHubDesktopPortable\Data\GitHub\palavrando-otter\palavrando-otter\Images\bg-room2.png");

            spritemap.ScaleY = 1.3f;
            spritemap.ScaleX = 1.3f;

            //spritemap.CenterOrigin();
            spritemap.CenterOrigin();

            // Add the graphic to the Entity so that it renders.
            AddGraphic(spritemap,Game.Instance.HalfWidth -40, Game.Instance.HalfHeight - 2);
        }
    }
}
