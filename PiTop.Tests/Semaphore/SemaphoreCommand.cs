using McMaster.Extensions.CommandLineUtils;
using PiTop.MakerArchitecture.Foundation;
using PiTop.MakerArchitecture.Foundation.Components;
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

namespace PiTop.Tests.Semaphore
{
    [HelpOption(Description = "Hi! This is a test project of the pi-top [4]")]
    [Command("semaphore", "s", FullName = "semaphore")]
    public class SemaphoreCommand
    {
        [Required]
        [Option("-c|--count")]
        public int Count { get; set; }

        protected virtual int OnExecute(CommandLineApplication app)
        {
            using FoundationPlate plate = PiTop4Board.Instance.GetOrCreatePlate<FoundationPlate>();

            using Led green = plate.GetOrCreateLed(DigitalPort.D0);
            using Led yellow = plate.GetOrCreateLed(DigitalPort.D1);
            using Led red = plate.GetOrCreateLed(DigitalPort.D2);

            Led[] leds = new[] { green, yellow, red };

            for (int i = 0; i < Count; i++)
            {
                foreach (var led in leds)
                {
                    led.On();
                    Thread.Sleep(1000);
                    led.Off();
                }
            }

            return 0;
        }
    }
}
