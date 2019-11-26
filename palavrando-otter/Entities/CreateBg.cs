﻿using Otter;
using palavrando_otter.Systems;
using System;
using System.IO;

namespace Palavrando.Entities
{
    class CreateBg : Entity
    {
        public CreateBg()
        {
            
            Image spritemap = new Image(PathFolder.getDirectory() + @"\Images\bg-room2.png");

            spritemap.ScaleY = 1.3f;
            spritemap.ScaleX = 1.3f;

            //spritemap.CenterOrigin();
            spritemap.CenterOrigin();

            // Add the graphic to the Entity so that it renders.
            AddGraphic(spritemap,Game.Instance.HalfWidth -40, Game.Instance.HalfHeight - 2);
        }
    }
}