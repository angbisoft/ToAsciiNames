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
            Serilog.Log.Information($"ProcessFolderImpl : {dirRoot.FullName}");
            return this;
        }
    }
}