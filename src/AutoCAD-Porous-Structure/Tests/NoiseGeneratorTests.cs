namespace Tests
{
    using System.Collections.Generic;
    using System.Windows.Media.Media3D;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class NoiseGeneratorTests
    {
        [Test(Description = "Проверяет наличие точек при создании шума.")]
        public void Generator_SetEmptyParameters_GetFilledList()
        {
            // Arrange
            var pointsCount = 41;
            var parameters = new PorousParameter();
            var noiseGenerator = new NoiseGenerator(new FakeRandomizer());
            var expected = new Point3D(
                FakeRandomizer.FakeRandomNumber * parameters[ParameterType.Length].Value,
                FakeRandomizer.FakeRandomNumber * parameters[ParameterType.Width].Value,
                FakeRandomizer.FakeRandomNumber * parameters[ParameterType.Height].Value);

            // Act
            var points = noiseGenerator.Generate(parameters);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(points, Is.Not.Null);
                Assert.That(points, Has.No.Empty);
                Assert.That(points.Count, Is.EqualTo(pointsCount));
                foreach (var point in points)
                {
                    Assert.That(point.X, Is.EqualTo(expected.X));
                    Assert.That(point.Y, Is.EqualTo(expected.Y));
                    Assert.That(point.Z, Is.EqualTo(expected.Z));
                }
            });
        }

        [Test(Description = "Проверяет отсутствие точек при подаче пустого " +
             "или не подразумевающего точек параметры.")]
        public void Generator_SetEmptyParameters_GetEmptyList(
            [ValueSource(nameof(GetEmptyParameters))] PorousParameter parameters)
        {
            // Arrange
            var noiseGenerator = new NoiseGenerator(new FakeRandomizer());

            // Act
            var points = noiseGenerator.Generate(parameters);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(points, Is.Not.Null);
                Assert.That(points, Is.Empty);
            });
        }

        [Test(Description = "Проверяет функцию обратного нормального распределения.")]
        public void Generator_InverseNormalDistribution_GetCorrectValue()
        {
            // Arrange
            var expected = 0.12d;
            var noiseGenerator = new NoiseGenerator(new FakeRandomizer());

            // Act
            var actual = noiseGenerator.InverseNormalDistribution();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Создаёт пустые параметры.
        /// </summary>
        /// <returns>Варианты параметров.</returns>
        private static IEnumerable<PorousParameter> GetEmptyParameters()
        {
            yield return null;
            yield return new PorousParameter
            {
                [ParameterType.Porosity] =
                {
                    Value = 0
                }
            };
        }
    }
}
