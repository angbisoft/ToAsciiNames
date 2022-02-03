using System;

namespace ToAsciiNames {
    class Program {
        static void Main(string[] args) {
            var root = args.Length > 0 ? args[0] : "/Volumes/ssdCommon/temp/mp3y";
            Console.WriteLine($"ToAsciiNames {root}");
            new FolderRenamer().ProcessFolder(root);
        }
    }
}
