using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyokaiShooter
{
    class Title : asd.Scene
    {
        protected override void OnRegistered()
        {
            var backGround = new TitleBackground();
            AddLayer(backGround);
        }

    }

    class TitleBackground : asd.Layer2D
    {
        protected override void OnAdded()
        {
            var font = asd.Engine.Graphics.CreateDynamicFont("", 32, new asd.Color(255, 255, 255, 255), 1, new asd.Color(255, 255, 255, 255));
            var obj = new asd.TextObject2D
            {
                Font = font,
                Position = new asd.Vector2DF(0, 0),
                Text = "title"
            };
            AddObject(obj);
        }
    }
}
