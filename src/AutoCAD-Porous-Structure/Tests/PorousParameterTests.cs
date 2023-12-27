namespace Tests
{
    using System;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class PorousParameterTests
    {
        [Test(Description = "Проверка конструктора с допустимыми значениями.")]
        public void Constructor_ValidValues_InitializedCorrectly()
        {
            // Arrange
            var parameters = new PorousParameter();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(parameters[ParameterType.Length], Is.Not.Null);
                Assert.That(parameters[ParameterType.Width], Is.Not.Null);
                Assert.That(parameters[ParameterType.Height], Is.Not.Null);
                Assert.That(parameters[ParameterType.Porosity], Is.Not.Null);
                Assert.That(parameters[ParameterType.PoreSize], Is.Not.Null);
            });
        }

        [Test(Description = "Проверка перегрузки оператора индексации.")]
        public void Indexer_SetValue_GetSameValue()
        {
            // Arrange
            const double value = 2;
            var parameters = new PorousParameter();

            // Act
            parameters[ParameterType.Length].Value = value;
            parameters[ParameterType.Width].Value = value;
            parameters[ParameterType.Height].Value = value;
            parameters[ParameterType.Porosity].Value = value;
            parameters[ParameterType.PoreSize].Value = value;

            // Assert
            Assert.Multiple(() =>
            {
                foreach (ParameterType parameterType
                in Enum.GetValues(typeof(ParameterType)))
                {
                    Assert.That(parameters[parameterType].Value, Is.EqualTo(value));
                }
            });
        }

        [TestCase(ParameterType.Length, ParameterType.Width, ParameterType.Height,
            Description = "Проверка главного параметра длина.")]
        [TestCase(ParameterType.Width, ParameterType.Length, ParameterType.Height,
            Description = "Проверка главного параметра ширина.")]
        [TestCase(ParameterType.Height, ParameterType.Width, ParameterType.Length,
            Description = "Проверка главного параметра высота.")]
        public void Validator_SetUnresolvedValues_ThrowsArgumentException(
            ParameterType independentType,
            ParameterType firstDependentType,
            ParameterType secondDependentType)
        {
            // Arrange
            var parameters = new PorousParameter();
            parameters.SetValue(independentType, 0.001);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() =>
                    {
                        // Act
                        parameters[firstDependentType].Value = 0.001;
                    },
                    "Должно выбросить исключение о " +
                    "невозможности присвоить значение меньше 1.");
                Assert.Throws<ArgumentException>(() =>
                    {
                        // Act
                        parameters[secondDependentType].Value = 0.001;
                    },
                    "Должно выбросить исключение о " +
                    "невозможности присвоить значение меньше 1.");
            });
        }

        [Test(Description = "Проверка валидации с корректными параметрами.")]
        [Combinatorial]
        public void Validator_SetCorrectValues_NoExceptionThrown(
            [Values(1, 25, 35)] double length,
            [Values(1, 25, 35)] double width,
            [Values(1, 25, 35)] double height,
            [Values(0, 25, 50)] double porosity,
            [Values(1, 2.5, 5)] double poreSize)
        {
            // Arrange
            var parameters = new PorousParameter();

            // Act
            parameters.SetValue(ParameterType.Length, length);
            parameters.SetValue(ParameterType.Width, width);
            parameters.SetValue(ParameterType.Height, height);
            parameters.SetValue(ParameterType.Porosity, porosity);
            parameters.SetValue(ParameterType.PoreSize, poreSize);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(parameters[ParameterType.Length].Value,
                    Is.EqualTo(length));
                Assert.That(parameters[ParameterType.Width].Value,
                    Is.EqualTo(width));
                Assert.That(parameters[ParameterType.Height].Value,
                    Is.EqualTo(height));
                Assert.That(parameters[ParameterType.Porosity].Value,
                    Is.EqualTo(porosity));
                Assert.That(parameters[ParameterType.PoreSize].Value,
                    Is.EqualTo(poreSize));
            });
        }
    }
}
