namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media.Media3D;

    /// <summary>
    /// Класс генератора шума.
    /// </summary>
    public class NoiseGenerator
    {
        /// <summary>
        /// Генератор чисел.
        /// </summary>
        private readonly IRandomize _randomizer;

        /// <summary>
        /// Массив с точками.
        /// </summary>
        private List<Point3D> _noise;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="randomizer">Генератор случайных чисел.</param>
        public NoiseGenerator(IRandomize randomizer)
        {
            _randomizer = randomizer;
        }

        /// <summary>
        /// Генерирует массив с точками.
        /// </summary>
        public List<Point3D> Generate(PorousParameter parameters)
        {
            if (parameters == null)
            {
                return new List<Point3D>();
            }

            (double lenght, double width, double height) size = (
                parameters[ParameterType.Length].Value,
                parameters[ParameterType.Width].Value,
                parameters[ParameterType.Height].Value);

            var volume = size.lenght * size.width * size.height;
            var sphereVolume = 4d / 3d * Math.PI * Math.Pow(parameters[ParameterType.PoreSize].Value, 3);
            var spheresCount = (int)(volume * parameters[ParameterType.Porosity].Value * 0.01 / sphereVolume);

            GenerateNoise(size, spheresCount);

            return _noise;
        }

        /// <summary>
        /// Заполняет массив случайными значениями.
        /// </summary>
        private void GenerateNoise((double lenght, double width, double height) size, int spheresCount)
        {
            _noise = new List<Point3D>();

            for (int i = 0; i < spheresCount; i++)
            {
                var point = new Point3D(
                    _randomizer.NextDouble() * size.lenght,
                    _randomizer.NextDouble() * size.width,
                    _randomizer.NextDouble() * size.height);
                _noise.Add(point);
            }
        }
    }
}