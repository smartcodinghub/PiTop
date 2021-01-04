using McMaster.Extensions.CommandLineUtils;
using PiTop.MakerArchitecture.Foundation;
using PiTop.MakerArchitecture.Foundation.Components;
using PiTop.MakerArchitecture.Foundation.Sensors;
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

namespace PiTop.Tests.SemaphorePotentiometer
{
    [HelpOption(Description = "Hi! This is a castor test project of the pi-top [4]")]
    [Command("semaphore-potentiometer", "sp", FullName = "semaphore-potentiometer")]
    public class SemaphorePotentiometerCommand
    {
        protected virtual int OnExecute(CommandLineApplication app)
        {
            using FoundationPlate plate = PiTop4Board.Instance.GetOrCreatePlate<FoundationPlate>();

            using Led green = plate.GetOrCreateLed(DigitalPort.D0);
            using Led yellow = plate.GetOrCreateLed(DigitalPort.D1);
            using Led red = plate.GetOrCreateLed(DigitalPort.D2);

            Led[] semaphore = new[] { green, yellow, red };

            using Potentiometer potentiometer = plate.GetOrCreatePotentiometer(AnaloguePort.A0);

            potentiometer.Connect();

            int currentPosition = -1;
            Led current = green;
            while (true)
            {
                // 2.9999 instead of 3 so when the Position is 1 it doesn't return 3 and still returns 2 (red light)
                int newPosition = (int)(potentiometer.Position * 2.9999);
                if (newPosition != currentPosition)
                {
                    current.Off();
                    current = semaphore[newPosition];
                    currentPosition = newPosition;
                    current.On();
                }

                Thread.Sleep(100);
            }

            return 0;
        }
    }
}
