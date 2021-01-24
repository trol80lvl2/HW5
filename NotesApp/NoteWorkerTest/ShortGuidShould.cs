using NotesApp.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NotesTests
{
    public class ShortGuidShould
    {
        [Fact]
        public void FromToShortIdCorrectTransformation()
        {
            Guid guid = new Guid();
            string shortGuid = ShortGuid.ToShortId(guid);
            Guid? longGuid = ShortGuid.FromShortId(shortGuid);
            Assert.Equal(guid,longGuid);
        }
        [Fact]
        public void FromShortIdWithTwoEqualsCorrect()
        {
            Guid guid = new Guid();
            string shortGuid = ShortGuid.ToShortId(guid)+"==";
            Guid? longGuid = ShortGuid.FromShortId(shortGuid);
            Assert.Equal(guid, longGuid);
        }
        [Fact]
        public void FromShortIdStringToGuid()
        {
            Guid guid = Guid.NewGuid();
            string stringGuid = guid.ToString();
            Guid? newGuid = stringGuid.FromShortId();
            Assert.Equal(guid, newGuid);
        }
        [Fact]
        public void UncorrectInputShortGuid()
        {
            Assert.Throws<FormatException>(() => ShortGuid.FromShortId(Guid.NewGuid().ToString().Substring(2)));
        }
        [Fact]
        public void NullShortGuid()
        {
            var expectedResult = ShortGuid.FromShortId(null);
            Assert.Null(expectedResult);
        }
    }
}
