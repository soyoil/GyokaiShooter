using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyokaiShooter.Objects
{
    public class Button : asd.Layer2D
    {
        asd.Color coll = new asd.Color(10, 10, 200, 255);
        asd.Color whi = new asd.Color(255, 255, 255, 255);
        asd.Font menuFont = asd.Engine.Graphics.CreateDynamicFont("", 24, new asd.Color(255, 154, 33, 255), 1, new asd.Color(255, 255, 255, 255));
        asd.GeometryObject2D cursor = new asd.GeometryObject2D();

        public static Dictionary<string, Action> keyValuePairs { get; set; }
        public static asd.Vector2DF buttonPos { get; set; }

        protected override void OnAdded()
        {
            int counter = 0;
            foreach(KeyValuePair<string, Action> keyValuePair in keyValuePairs)
            {
                var text = new asd.TextObject2D()
                {
                    Font = menuFont,
                    Position = new asd.Vector2DF(buttonPos.X + 10, buttonPos.Y + 30*counter),
                    Text = keyValuePair.Key
                };
                var object2D = new asd.GeometryObject2D()
                {
                    Color = whi
                };
                object2D.Shape = new asd.RectangleShape()
                {
                    DrawingArea = new asd.RectF(buttonPos.X, buttonPos.Y + 30*counter + 7, 200, 24),
                };
                AddObject(object2D);
                AddObject(text);
                counter++;
            }

            var cursorShape = new asd.CircleShape()
            {
                OuterDiameter = 1
            };
            cursor.Shape = cursorShape;
            cursor.Color = new asd.Color(255, 0, 255, 0);
            AddObject(cursor);
        }

        protected override void OnUpdated()
        {
            cursor.Position = asd.Engine.Mouse.Position;
            
        }
    }
}
