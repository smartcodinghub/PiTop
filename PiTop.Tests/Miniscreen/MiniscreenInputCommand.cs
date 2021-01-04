using McMaster.Extensions.CommandLineUtils;
using PiTop.Abstractions;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiTop.Tests.Text
{
    [Command("miniscreen-text", "mt", FullName = "miniscreen-text")]
    public class MiniscreenInputCommand
    {
        [Required]
        [Option("-t|--text")]
        public string Text { get; set; }

        protected virtual int OnExecute(CommandLineApplication app)
        {
            using Display display = PiTop4Board.Instance.Display;
            Font font = SystemFonts.Collection.Find("Roboto").CreateFont(20);

            display.Draw((context, _) =>
            {
                context.Clear(Color.Black);

                FontRectangle rect = TextMeasurer.Measure(Text, new RendererOptions(font));

                float x = display.Width / 2 - rect.Width / 2;
                float y = display.Height / 2 - rect.Height / 2;

                context.DrawText(Text, font, Color.White, new PointF(x, y));
            });

            Thread.Sleep(5000);
            return 0;
        }
    }
}
