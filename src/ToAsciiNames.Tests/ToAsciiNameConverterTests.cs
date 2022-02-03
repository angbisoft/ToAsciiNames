using System;
using Xunit;

namespace ToAsciiNames.Tests {
    public class ToAsciiNameConverterTests {
        [Theory]
        [InlineData("Erol_Evgin_Emel_Sayin_Iste_Oyle_Bir_Sey_Official_Audio_128kbit_AAC", "Erol Evgin & Emel Sayın - İşte Öyle Bir Şey (Official Audio) (128kbit_AAC)-")]
        public void Convert(string expected, string input) {
            Assert.Equal(expected, ToAsciiNameConverter.Convert(input, "defaultName"));
        }
    }
}
