using System;
using System.Threading;
using PiTop;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;

namespace PiTop.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            using var display = PiTop4Board.Instance.Display;

            var font = SystemFonts.Collection.Find("Roboto").CreateFont(20);

            display.Draw((context, _) => {

                context.Clear(Color.Black);

                FontRectangle rect = TextMeasurer.Measure("¡Ardilla!", new RendererOptions(font));

                float x = display.Width / 2 - rect.Width / 2;
                float y = display.Height / 2 - rect.Height / 2;

                context.DrawText("¡Ardilla!", font, Color.White, new PointF(x, y));
            });

            Thread.Sleep(5000);
        }
    }
}
