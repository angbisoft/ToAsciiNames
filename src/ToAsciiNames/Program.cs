using System;
using Serilog;

namespace ToAsciiNames {
    class Program {
        static void Main(string[] args) {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            var root = args.Length > 0 ? args[0] : "/Volumes/ssdCommon/temp/mp3y";
            Console.WriteLine($"ToAsciiNames {root}");
            new FolderRenamer().ProcessFolder(root);
        }
    }
}
