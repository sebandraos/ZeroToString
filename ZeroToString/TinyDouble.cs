using System;
using System.Diagnostics;
using Xunit;

namespace ZeroToString
{
    public class TinyDouble
    {
        const double negativeValue = -1E-16;
        const double positiveValue = 1E-16;

        /// <summary>Rounds a <c>double</c> <paramref name="value"/> to ensure that the same rounding is used consistently.</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static double Round(double value) => Math.Round(value, 9);

        /// <summary>Tests whether <paramref name="value"/> rounds to 0 (zero).</summary>
        /// <param name="value">Value on which to test the rounding.</param>
        [Theory]
        [InlineData(negativeValue)]
        [InlineData(positiveValue)]
        public void RoundsToZero(double value)
        {
            var rounded = Round(value);
            Assert.Equal(0, rounded);
        }

        /// <summary>Tests whether the sign of <paramref name="value"/> when it rounds to 0 (zero) is 0 (zero).</summary>
        /// <param name="value">Value on which to test the sign.</param>
        [Theory]
        [InlineData(negativeValue)]
        [InlineData(positiveValue)]
        public void RoundedSignIsZero(double value)
        {
            var rounded = Round(value);
            Assert.Equal(0, rounded);

            var sign = Math.Sign(rounded);
            Assert.Equal(0, sign);
        }

        /// <summary>Tests whether the string representation of <paramref name="value"/> when it rounds to 0 (zero) is 0 (zero).</summary>
        /// <param name="value">Value on which to test the rendering.</param>
        [Theory]
        [InlineData(negativeValue)]
        [InlineData(positiveValue)]
        public void RoundedToStringIsZero(double value)
        {
            var rounded = Round(value);
            Assert.Equal(0, rounded);

            var rendered = rounded.ToString();
            Assert.Equal("0", rendered);
        }

        /// <summary>Tests whether the string representation of <paramref name="value"/> when it rounds to 0 (zero) through <see cref="object.ToString"/> is 0 (zero).</summary>
        /// <param name="value">Value on which to test the rendering.</param>
        [Theory]
        [InlineData(negativeValue)]
        [InlineData(positiveValue)]
        public void ToStringIsZero(double value)
        {
            var rendered = value.ToString("0.######");
            Assert.Equal("0", rendered);
        }

        /// <summary>Renders the bits of a <c>double</c>.</summary>
        /// <param name="value">Value to render.</param>
        private static void DoubleToLongBits(double value)
        {
            long longValue;
            longValue = BitConverter.DoubleToInt64Bits(value);

            // Display the resulting long in hexadecimal.
            Debug.WriteLine(formatter, value, longValue);
        }
        const string formatter = "{0,25:E16}{1,23:X16}";

    }
}
