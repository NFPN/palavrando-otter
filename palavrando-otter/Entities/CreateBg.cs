using Otter;
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
            Image spritemap = new Image(@"C:\Users\nico_\Source\Repos\NFPN\palavrando-otter\palavrando-otter\Images\bg-room.png");
            
            //spritemap.CenterOrigin();
            spritemap.CenterOriginZero();

            // Add the graphic to the Entity so that it renders.
            AddGraphic(spritemap);
        }
    }
}
