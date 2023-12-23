namespace Tests
{
    using Model;

    /// <summary>
    /// Псевдо генератор случайных чисел.
    /// </summary>
    internal class FakeRandomizer : IRandomize
    {
        /// <summary>
        /// Возвращает псевдо случайное число.
        /// </summary>
        /// <returns>1,2.</returns>
        public double NextDouble()
            => 0.5d;
    }
}
