using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyokaiShooter.Scenes
{
    class SelectChara: asd.Scene
    {
        asd.Font titleFont = asd.Engine.Graphics.CreateDynamicFont("", 32, new asd.Color(52, 210, 235, 255), 0, new asd.Color(255, 255, 255, 255));
        string[] charas = { "../imgs/ika.png", "imgs/tako.png", "imgs/kani.png", "imgs/kai.png" };
        protected override void OnRegistered()
        {
            var titleText = new asd.Layer2D();
            var title = new asd.TextObject2D()
            {
                Text = "Select the charactor",
                Position = new asd.Vector2DF(100, 10),
                Font = titleFont
            };
            titleText.AddObject(title);

            int count = 0;
            foreach(string url in charas)
            {
                var img = new asd.TextureObject2D
                {
                    Texture = asd.Engine.Graphics.CreateTexture2D(url),
                    Position = new asd.Vector2DF(10 + count * 200, 50)
                };
                titleText.AddObject(img);
                count++;
            }

            var button = new Objects.Button
            {
                keyValuePairs = new Dictionary<string, Action>()
                {
                    {"Back", () => {asd.Engine.ChangeScene(new Title()); } }
                },
                buttonPos = new asd.Vector2DF(10, 400)
            };
            AddLayer(button);
            AddLayer(titleText);
        }
    }
}
