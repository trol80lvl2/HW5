using NotesApp.Tools;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NotesTests
{
    public class StringGeneratorShould
    {
        [Fact]
        public void GenerateEmptyNumbersString()
        {
            string expectedResult = StringGenerator.GenerateNumbersString(0, false);
            Assert.Equal(expectedResult, String.Empty);
        }
        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        public void GenerateNumbersStringExceptions(int length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringGenerator.GenerateNumbersString(length, false));
        }
        [Fact]
        public void GenerateStringWithoudLeadingZero()
        {
            string expectedString = StringGenerator.GenerateNumbersString(10, false);
            Assert.False(expectedString.StartsWith('0'));
        }
        [Fact]
        public void GenerateStringReturnsRightlength()
        {
            Random random = new Random();
            int length = random.Next(1,100);
            string expectedString = StringGenerator.GenerateNumbersString(length, true);
            Assert.Equal(length, expectedString.Length);
        }
        [Fact]
        public void GenerateStringReturnsNumericValue()
        {
            Random random = new Random();
            int length = random.Next(1, 10);
            string expectedString = StringGenerator.GenerateNumbersString(length, false);
            Assert.True(decimal.TryParse(expectedString,out decimal result));
        }

    }
}
