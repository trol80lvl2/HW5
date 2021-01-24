using NotesApp.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NotesTests
{
    public class NumberGeneratorShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(19)]
        [InlineData(-10)]
        [InlineData(25)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void GeneratePositiveLongInvalidArgument(int length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberGenerator.GeneratePositiveLong(length));
        }
        [Fact]
        public void GeneratePositiveLongCorrectLength()
        {
            Random random = new Random();
            int length = random.Next(1,19);
            long returnedLong = NumberGenerator.GeneratePositiveLong(length);
            Assert.Equal(length, returnedLong.ToString().Length);
        }

    }
}
