using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ToAsciiNames {
    public static class LibUtil {
        private static readonly Tuple<string, string>[] TurkishCharacterReplaceMap = new Tuple<string, string>[]{
            Tuple.Create(" ","_"),
            Tuple.Create("-","_"),
            Tuple.Create("&","_"),
            Tuple.Create("ı","i"),
            Tuple.Create("ü|ü","u"),
            Tuple.Create("ö|ö","o"),
            Tuple.Create("ğ|ğ","g"),
            Tuple.Create("ş|ş","s"),
            Tuple.Create("ç|ç","c"),
            Tuple.Create("İ|İ","I"),
            Tuple.Create("Ü|Ü","U"),
            Tuple.Create("Ö","O"),
            Tuple.Create("Ö","O"),
            Tuple.Create("Ğ","G"),
            Tuple.Create("Ş|Ş","S"),
            Tuple.Create("Ç|Ç","C")
            };
        private static List<string> _TurkishCharacterReplaceMapFirstChars = null;
        public static readonly CultureInfo TrCulture = CultureInfo.GetCultureInfo("tr");

        private static List<string> TurkishCharacterReplaceMapFirstChars {
            get {
                if (_TurkishCharacterReplaceMapFirstChars == null) {
                    _TurkishCharacterReplaceMapFirstChars = TurkishCharacterReplaceMap.Select(x => x.Item1).ToList();
                }
                return _TurkishCharacterReplaceMapFirstChars;
            }
        }

        public static bool HasAnyTurkishCharactersOrSpace(string value) {
            return !string.IsNullOrEmpty(value) &&
             TurkishCharacterReplaceMapFirstChars.Any(x => value.Contains(x));
        }
        public static string ReplaceTurkishCharactersOrSpace(string value) {
            if (value != null) {
                foreach (var map in TurkishCharacterReplaceMap) {
                    value = Regex.Replace(value, map.Item1, map.Item2);
                    // value = value.Replace(map.Item1, map.Item2);
                }
            }
            return value;
        }




    }

}