using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToAsciiNames {
    public class FolderRenamer {
        public FolderRenamer() {
        }

        public FolderRenamer ProcessFolder(string root) {
            DirectoryInfo dirRoot = new DirectoryInfo(root);
            if (dirRoot.Exists) {
                return ProcessFolderImpl(dirRoot);
            }
            return this;
        }

        private FolderRenamer ProcessFolderImpl(DirectoryInfo dirRoot) {
            var dirs = LanguageUtils.IgnoreErrors(() => dirRoot.EnumerateDirectories().ToList(), new List<DirectoryInfo>());
            dirs.Item1.ForEach(x => ProcessFolderImpl(x));
            var files = LanguageUtils.IgnoreErrors(() => dirRoot.EnumerateFiles().ToList(), new List<FileInfo>());
            files.Item1.ForEach(x => ProcessFile(x));

            Serilog.Log.Information($"ProcessFolderImpl : {dirRoot.FullName}");
            return this;
        }

        private void ProcessFile(FileInfo file) {
            var ext = file.Extension;
            var newName = ToAsciiNameConverter.Convert(Path.GetFileNameWithoutExtension(file.Name), "unknown_file");
            if (!string.IsNullOrWhiteSpace(ext)) {
                newName = $"{newName}{ext}";
            }
            // Serilog.Log.Information($"ProcessFile : {file.Name}==> {newName}");
            Serilog.Log.Information($" {newName}");
        }
    }
}