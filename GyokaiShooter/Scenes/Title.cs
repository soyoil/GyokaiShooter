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
            var button = new Objects.Button
            {
                keyValuePairs = new Dictionary<string, Action>()
                {
                    {"Start Game", () => {} },
                    {"Records", () => {} },
                    {"Option", () => {} },
                    {"Quit", () => {asd.Engine.Close(); } }
                },
                buttonPos = new asd.Vector2DF(10, 65)
            };
            AddLayer(button);
        }
    }

    class TitleTexts : asd.Layer2D
    {
        protected override void OnAdded()
        {
            var titleFont = asd.Engine.Graphics.CreateDynamicFont("", 32, new asd.Color(255, 255, 255, 255), 1, new asd.Color(255, 255, 255, 255));
            var obj = new asd.TextObject2D
            {
                Font = titleFont,
                Position = new asd.Vector2DF(10, 0),
                Text = "GyokaiShooter"
            };
            AddObject(obj);

            var menuFont = asd.Engine.Graphics.CreateDynamicFont("", 24, new asd.Color(255, 154, 33, 255), 1, new asd.Color(255, 255, 255, 255));
            var game = new asd.TextObject2D
            {
                Font = menuFont,
                Position = new asd.Vector2DF(10, 65),
                Text = "Start Game"
            };
            AddObject(game);
            var records = new asd.TextObject2D
            {
                Font = menuFont,
                Position = new asd.Vector2DF(10, 95),
                Text = "Records"
            };
            AddObject(records);
            var option = new asd.TextObject2D
            {
                Font = menuFont,
                Position = new asd.Vector2DF(10, 125),
                Text = "Option"
            };
            AddObject(option);
            var quit = new asd.TextObject2D
            {
                Font = menuFont,
                Position = new asd.Vector2DF(10, 155),
                Text = "Quit"
            };
            AddObject(quit);
        }
    }

    class TitleCols : asd.Layer2D
    {
        private asd.GeometryObject2D cursor = new asd.GeometryObject2D();
        private asd.CircleShape csha = new asd.CircleShape();
        private asd.GeometryObject2D gstart = new asd.GeometryObject2D();
        private asd.GeometryObject2D grecord = new asd.GeometryObject2D();
        private asd.GeometryObject2D goption = new asd.GeometryObject2D();
        private asd.GeometryObject2D gquit = new asd.GeometryObject2D();
        protected override void OnAdded()
        {
            var buttons = new Dictionary<string, Action>()
            {
                {"Start Game", () => {} },
                {"Records", () => {} },
                {"Option", () => {} },
                {"Quit", () => {asd.Engine.Close(); } }
            };

            gstart.Shape = new asd.RectangleShape
            {
                DrawingArea = new asd.RectF(0, 72, 200, 24)
            };
            AddObject(gstart);
            grecord.Shape = new asd.RectangleShape
            {
                DrawingArea = new asd.RectF(0, 102, 200, 24)
            };
            AddObject(grecord);
            goption.Shape = new asd.RectangleShape
            {
                DrawingArea = new asd.RectF(0, 132, 200, 24)
            };
            AddObject(goption);
            gquit.Shape = new asd.RectangleShape
            {
                DrawingArea = new asd.RectF(0, 164, 200, 24)
            };
            AddObject(gquit);

            csha.OuterDiameter = 2;
            cursor.Shape = csha;
            cursor.Color = new asd.Color(255, 0, 255, 0);
            AddObject(cursor);
        }

        protected override void OnUpdated()
        {
            csha.Position = asd.Engine.Mouse.Position;
            var coll = new asd.Color(10, 10, 200, 255);
            var whi = new asd.Color(255, 255, 255, 255);
            gstart.Color = whi;
            grecord.Color = whi;
            goption.Color = whi;
            gquit.Color = whi;
            if (csha.GetIsCollidedWith(gstart.Shape))
            {
                gstart.Color = coll;
            }
            else if (csha.GetIsCollidedWith(grecord.Shape))
            {
                grecord.Color = coll;
            }
            else if (csha.GetIsCollidedWith(goption.Shape))
            {
                goption.Color = coll;
            }
            else if (csha.GetIsCollidedWith(gquit.Shape))
            {
                gquit.Color = coll;
                if(asd.Engine.Mouse.LeftButton.ButtonState == asd.ButtonState.Push)
                {
                    asd.Engine.Close();
                }
            }
        }
    }
}
