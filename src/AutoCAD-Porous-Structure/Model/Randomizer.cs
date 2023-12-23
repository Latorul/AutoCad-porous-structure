namespace Model
{
    using System;

    /// <summary>
    /// Реальный генератор случайных чисел.
    /// </summary>
    public class Randomizer : IRandomize
    {
        /// <summary>
        /// Экземпляр класса Random, используемый для генерации псевдослучайных чисел.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Генерирует случайное число с плавающей точкой.
        /// </summary>
        /// <returns>Возвращает число от 0 до 1.</returns>
        public double NextDouble()
            => _random.NextDouble();
    }
}
