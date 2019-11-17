using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyokaiShooter.Scenes
{
    class Option : asd.Scene
    {
        protected override void OnRegistered()
        {
            var button = new Objects.Button
            {
                keyValuePairs = new Dictionary<string, Action>()
                {
                    {"Back", () => {
                            var title = new Title();
                            asd.Engine.ChangeScene(title);
                        }
                    },
                    {"Quit", () => {asd.Engine.Close(); } }
                },
                buttonPos = new asd.Vector2DF(10, 65)
            };
            AddLayer(button);
        }
    }
}
