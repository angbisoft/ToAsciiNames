using System;
using Xunit;

namespace ToAsciiNames.Tests {
    public class LanguageUtilsTests {
        [Fact]
        public void NullInput() {
            Assert.True(LanguageUtils.IgnoreErrors(() => { }).Item1);
            Assert.False(LanguageUtils.IgnoreErrors(() => { throw new Exception("foo"); }).Item1);
            Assert.Equal(25, LanguageUtils.IgnoreErrors(() => { return 5 * 5; }).Item1);
            Assert.Equal(0, LanguageUtils.IgnoreErrors<int>(() => { throw new Exception("bar"); }).Item1);
            var bar = new Exception("bar");
            Assert.Equal(bar, LanguageUtils.IgnoreErrors<int>(() => { throw bar; }).Item2);
        }
    }
}
