using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyokaiShooter.Scenes
{
    class Title : asd.Scene
    {
        protected override void OnRegistered()
        {
            AddLayer(new TitleLayer());
            var button = new Objects.Button
            {
                keyValuePairs = new Dictionary<string, Action>()
                {
                    {"Start Game", () => {asd.Engine.ChangeScene(new SelectChara()); } },
                    {"Records", () => {} },
                    {"Option", () => {asd.Engine.ChangeScene(new Scenes.Option()); } },
                    {"Quit", () => {asd.Engine.Close(); } }
                },
                buttonPos = new asd.Vector2DF(10, 65)
            };
            AddLayer(button);
        }
    }

    class TitleLayer : asd.Layer2D
    {
        asd.Font titleFont = asd.Engine.Graphics.CreateDynamicFont("", 32, new asd.Color(52, 210, 235, 255), 0, new asd.Color(255, 255, 255, 255));
        protected override void OnAdded()
        {
            var title = new asd.TextObject2D()
            {
                Font = titleFont,
                Position = new asd.Vector2DF(10, 10),
                Text = "GyokaiShooter"
            };
            AddObject(title);
        }
    }
}
