using System;

namespace GyokaiShooter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // ウィンドウサイズ可変，リソース再読み込み有効
            asd.EngineOption engineOption = new asd.EngineOption
            {
                IsWindowResizable = true,
                IsReloadingEnabled = true
            };

            // Altseedを初期化する。
            asd.Engine.Initialize("GyokaiShooter", 640, 480, engineOption);

            var title = new Scenes.Title();
            asd.Engine.ChangeScene(title);

            // Altseedが進行可能かチェックする。
            while (asd.Engine.DoEvents())
            {
                // Altseedを更新する。
                asd.Engine.Update();
            }

            // Altseedを終了する。
            asd.Engine.Terminate();
        }
    }
}