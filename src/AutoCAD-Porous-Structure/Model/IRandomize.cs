namespace Model
{
    /// <summary>
    /// Интерфейс для создания случайных чисел.
    /// </summary>
    public interface IRandomize
    {
        /// <summary>
        /// Генерирует случайное число.
        /// </summary>
        /// <returns>Случайное число.</returns>
        double NextDouble();
    }
}
