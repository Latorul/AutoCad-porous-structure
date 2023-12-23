namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media.Media3D;
    using Model;
    using NUnit.Framework;

    [TestFixture]
    public class NoiseGeneratorTests
    {
        [Test(Description = "Проверяет Наличие точек при создании шума.")]
        public void Generator_SetEmptyParameters_GetFilledList()
        {
            // Arrange
            var noiseGenerator = new NoiseGenerator(new FakeRandomizer());
            var parameters = new PorousParameter();
            var pointsCount = GetPointsCount(parameters);
            var expected = new Point3D(
                0.5 * parameters[ParameterType.Length].Value,
                0.5 * parameters[ParameterType.Width].Value,
                0.5 * parameters[ParameterType.Height].Value);

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

        private int GetPointsCount(PorousParameter parameters)
        {
            (double lenght, double width, double height) size = (
                parameters[ParameterType.Length].Value,
                parameters[ParameterType.Width].Value,
                parameters[ParameterType.Height].Value);

            var volume = size.lenght * size.width * size.height;
            var sphereVolume = 4d / 3d * Math.PI * Math.Pow(parameters[ParameterType.PoreSize].Value, 3);
            return (int)(volume * parameters[ParameterType.Porosity].Value * 0.01 / sphereVolume);
        }
    }
}
