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

            var size = parameters.GetSizes();
            var spheresCount = CalculateSpheresCount(parameters);
            GenerateNoise(size, spheresCount);

            return _noise;
        }

        /// <summary>
        /// Создаёт вещественное число по закону обратного нормального распределения.
        /// </summary>
        /// <returns>Число от -1 до 1.</returns>
        public double InverseNormalDistribution()
            => (GetUniformDistribution() -
                (GetUniformDistribution() * GetUniformDistribution())) / 2;

        /// <summary>
        /// Вычисляет количество отверстий.
        /// </summary>
        /// <param name="parameters">Параметры.</param>
        /// <returns>Количество отверстий.</returns>
        private int CalculateSpheresCount(PorousParameter parameters)
        {
            var volume =
                parameters[ParameterType.Length].Value
                * parameters[ParameterType.Width].Value
                * parameters[ParameterType.Width].Value;

            var sphereVolume =
                4d / 3d
                * Math.PI
                * Math.Pow(parameters[ParameterType.PoreSize].Value, 3);

            var spheresCount =
                (int)Math.Ceiling(
                    volume * parameters[ParameterType.Porosity].Value * 0.01
                    / sphereVolume);

            return spheresCount;
        }

        /// <summary>
        /// Заполняет массив случайными значениями.
        /// </summary>
        private void GenerateNoise(
            (double lenght, double width, double height) size,
            int spheresCount)
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

        /// <summary>
        /// Создаёт вещественное число по закону равномерного распределения.
        /// </summary>
        /// <returns>Число от -1 до 1.</returns>
        private double GetUniformDistribution()
            => (_randomizer.NextDouble() * 2) - 1;
    }
}