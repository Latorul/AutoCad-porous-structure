namespace Model
{
    using System;
    using System.Collections.Generic;
    using Autodesk.AutoCAD.Geometry;

    /// <summary>
    /// Класс генератора шума.
    /// </summary>
    public class NoiseGenerator
    {
        /// <summary>
        /// Массив с точками.
        /// </summary>
        private List<Point3d> _noise;

        /// <summary>
        /// Генератор чисел.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Генерирует массив с точками.
        /// </summary>
        public List<Point3d> Generate(PorousParameter parameters)
        {
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
            _noise = new List<Point3d>();

            for (int i = 0; i < spheresCount; i++)
            {
                var point = new Point3d(
                    Random.NextDouble() * size.lenght,
                    Random.NextDouble() * size.width,
                    Random.NextDouble() * size.height);
                _noise.Add(point);
            }
        }
    }
}