using System;
using System.Drawing;
using Rage;
using Rage.Attributes;
using LemonUI.Elements;

[assembly: Plugin("ClockDayRage", Author = "RelaperCrystal", Description = "Part of RCU(TM) series")]

namespace ClockDayRage
{
    /// <summary>
    /// Declares the entry point of this application.
    /// </summary>
    public static class EntryPoint
    {
        private static ScaledText _fps;

        /// <summary>
        /// Declares the entry point of this plugin.
        /// </summary>
        public static void Main()
        {
            var _text = new ScaledText(new PointF(15, 5), "STARTING CLOCKDAY", 0.30f);
            _fps = new ScaledText(new PointF(85, 5), "STARTING CLOCKDAY", 0.30f);
            var _background = new ScaledRectangle(new PointF(10, 5), new SizeF(85f + 65f + 25f, 25f));
            _background.Color = Color.FromArgb(150, 0, 0, 0);
            
            GameFiber.StartNew(FpsUpdate, "FPS Updating");
            while (true)
            {
                GameFiber.Yield();

                var time = DateTime.Now;
                _text.Text = $"{time.Hour:00}:{time.Minute:00}:{time.Second:00}";
                _text.Draw();
                _fps.Draw();
                _background.Draw();
            }
        }

        private static void FpsUpdate()
        {
            while (true)
            {
                GameFiber.Sleep(1000);
                _fps.Text = (int)Game.FrameRate + " FPS";
            }
        }
    }
}
