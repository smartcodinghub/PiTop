using System;
using System.Threading;
using McMaster.Extensions.CommandLineUtils;
using PiTop;
using PiTop.Tests.Semaphore;
using PiTop.Tests.Text;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;

namespace PiTop.Tests
{
    [Subcommand(typeof(MiniscreenInputCommand), typeof(SemaphoreCommand))]
    public class Program
    {
        static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }
    }
}
