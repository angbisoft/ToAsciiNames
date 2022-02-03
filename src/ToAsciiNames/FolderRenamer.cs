using System;
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
            dirRoot.EnumerateDirectories().ToList();
            throw new NotImplementedException();
        }
    }
}