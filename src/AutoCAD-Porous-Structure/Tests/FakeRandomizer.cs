namespace Tests
{
    using Model;

    /// <summary>
    /// Псевдо генератор случайных чисел.
    /// </summary>
    internal class FakeRandomizer : IRandomize
    {
        /// <summary>
        /// Псевдослучайное число.
        /// </summary>
        public static readonly double FakeRandomNumber = 0.8d;

        /// <summary>
        /// Возвращает псевдо случайное число.
        /// </summary>
        /// <returns>1,2.</returns>
        public double NextDouble()
            => FakeRandomNumber;
    }
}
