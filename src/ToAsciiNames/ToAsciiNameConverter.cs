using System;
using System.Text.RegularExpressions;

namespace ToAsciiNames {
    public class ToAsciiNameConverter {
        public static string Convert(string name, string defaultName) {
            if (string.IsNullOrWhiteSpace(name)) {
                return defaultName;
            }
            var result = ConvertImpl(name);
            if (string.IsNullOrWhiteSpace(result)) {
                result = defaultName;
            }
            return result;
        }

        private static string ConvertImpl(string name) {
            string result = Regex.Replace(name, @"[&\-\s'()\[\]!\.@#“”]+", "_");
            result = Regex.Replace(result, @"[_]+", "_");
            string found = LibUtil.ReplaceTurkishCharactersOrSpace(result);
            if (found.EndsWith("_")) {
                return found[0..^1];
            }
            return found;
        }
    }
}