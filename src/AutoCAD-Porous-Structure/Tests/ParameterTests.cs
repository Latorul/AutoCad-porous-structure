namespace Tests
{
    using System;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class ParameterTests
    {
        [Test(Description = "Проверка конструктора с допустимыми значениями.")]
        public void Constructor_ValidValues_InitializedCorrectly()
        {
            // Arrange
            const double minValue = 5;
            const double maxValue = 10;

            // Act
            var parameter = new Parameter(minValue, maxValue);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(parameter.MinValue, Is.EqualTo(minValue));
                Assert.That(parameter.MaxValue, Is.EqualTo(maxValue));
            });
        }

        [Test(Description = "Проверка выбрасывания исключения при изменении границ.")]
        public void MinValue_SetGreaterThanCurrentValue_ThrowsArgumentException()
        {
            // Arrange
            const double minValue = 5;
            const double maxValue = 15;
            const double newMinValue = 13;
            var parameter = new Parameter(minValue, maxValue)
            {
                Value = 10
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
                // Act
                parameter.MinValue = newMinValue,
                "Должно выбрасывать исключение при присвоении в MinValue " +
                "значения больше, чем Value.");
        }

        [Test(Description = "Проверка обновления MinValue " +
            "без выбрасывания исключения.")]
        public void MinValue_SetMinValueLessThanCurrent_NoExceptionThrown()
        {
            // Arrange
            const double minValue = 5;
            const double maxValue = 15;
            const double newMinValue = 7;
            var parameter = new Parameter(minValue, maxValue)
            {
                Value = 10
            };

            // Assert
            Assert.DoesNotThrow(() =>
                    // Act
                    parameter.MinValue = newMinValue,
                "Не должно выбрасывать исключение при присвоении в MinValue " +
                "значения меньше, чем Value.");
        }

        [Test(Description = "Проверка присвоения значения, входящего в границы.")]
        public void Value_SetValidValue_NoExceptionThrown()
        {
            // Arrange
            const double minValue = 5;
            const double maxValue = 15;
            const double value = 10;
            var parameter = new Parameter(minValue, maxValue);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() =>
                        // Act
                        parameter.Value = value,
                    "Не должно выбрасывать исключение при присвоении в MinValue " +
                    "значения меньше, чем Value.");
                Assert.That(parameter.Value, Is.EqualTo(value));
            });
        }

        [Test(Description = "Проверка выбрасывания исключения " +
            "при присвоении значения больше максимального.")]
        public void Value_SetGreaterThanMaxValue_ThrowsArgumentException()
        {

            // Arrange
            const double minValue = 5;
            const double maxValue = 15;
            const double value = 20;
            var parameter = new Parameter(minValue, maxValue);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() =>
                        // Act
                        parameter.Value = value,
                    "Должно выбрасывать исключение при присвоении в Value " +
                    "значения больше MaxValue.");
            });
        }

        [Test(Description = "Проверка выбрасывания исключения " +
            "при присвоении значения меньше минимального.")]
        public void Value_SetBelowMinValue_ThrowsArgumentException()
        {
            // Arrange
            const double minValue = 5;
            const double maxValue = 15;
            const double value = 1;
            var parameter = new Parameter(minValue, maxValue);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() =>
                        // Act
                        parameter.Value = value,
                    "Должно выбрасывать исключение при присвоении в Value " +
                    "значения меньше MinValue.");
            });
        }
    }
}