using System;
using System.Collections;
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
        List<asd.GeometryObject2D> buttons = new List<asd.GeometryObject2D>();
        int pointer = 0;

        public Dictionary<string, Action> keyValuePairs { get; set; }
        public asd.Vector2DF buttonPos { get; set; }

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
                object2D.AddChild(text, asd.ChildManagementMode.RegistrationToLayer | asd.ChildManagementMode.Disposal, asd.ChildTransformingMode.All);
                buttons.Add(object2D);
                AddObject(object2D);
                counter++;
            }
        }

        protected override void OnUpdated()
        {
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.ButtonState.Push)
            {
                pointer++;
                if (pointer == buttons.Count) pointer = 0;
            }else if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.ButtonState.Push)
            {
                pointer--;
                if (pointer == -1) pointer = buttons.Count - 1;
            }
            foreach(asd.GeometryObject2D object2D in buttons)
            {
                object2D.Color = whi;
            }
            buttons[pointer].Color = coll;
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Enter) == asd.ButtonState.Push)
            {
                string buttonName = "";
                var hoge = buttons[pointer].Children;
                foreach(asd.TextObject2D fuga in hoge)
                {
                    buttonName = fuga.Text;
                }
                keyValuePairs[buttonName]();
            }
        }
    }
}
