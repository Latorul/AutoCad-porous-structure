namespace Model
{
    using System;

    /// <summary>
    /// Параметр.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Минимально допустимое значение параметра.
        /// </summary>
        private double _minValue;

        /// <summary>
        /// Значение, введённое пользователем и прошедшее валидацию.
        /// </summary>
        private double _value;

        /// <summary>
        /// Конструктор параметра.
        /// </summary>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        public Parameter(double minValue, double maxValue)
        {
            _minValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Максимально допустимое значение параметра.
        /// </summary>
        public double MaxValue { get; }

        /// <summary>
        /// Минимально допустимое значение параметра.
        /// </summary>
        public double MinValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                Validate(Value);
            }
        }

        /// <summary>
        /// Введённое пользователем значение.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                Validate(value);
                _value = value;
            }
        }

        /// <summary>
        /// Метод проверки значения пользователя на вхождение в допустимые границы.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Введённое значение не соответствует диапазону.</exception>
        private void Validate(double value)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException(
                    "Значение параметра должно быть в диапазоне " +
                    $"от {MinValue} до {MaxValue}.");
            }
        }
    }
}