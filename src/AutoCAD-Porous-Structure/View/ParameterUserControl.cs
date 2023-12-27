namespace View
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Model;

    /// <summary>
    /// Шаблонный элемент управления для ввода параметров.
    /// </summary>
    public partial class ParameterUserControl : UserControl
    {
        /// <summary>
        /// Задний фон поля для ввода значения, оповещающий об ошибке.
        /// </summary>
        private readonly Color _errorColor = Color.Salmon;

        /// <summary>
        /// Стандартный задний фон поля для ввода значения.
        /// </summary>
        private readonly Color _defaultColor = Color.White;

        /// <summary>
        /// Знак разделения целой части от вещественной.
        /// </summary>
        private readonly char _decimalSeparator;

        /// <summary>
        /// Флаг, определяющий наличие ошибки в поле для ввода значения.
        /// </summary>
        private bool _hasError;

        /// <summary>
        /// Конструктор элемента управления.
        /// </summary>
        public ParameterUserControl()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            _decimalSeparator =
                CultureInfo.CurrentCulture.NumberFormat
                .CurrencyDecimalSeparator.First();

            InitializeComponent();
        }

        /// <summary>
        /// Обрабатывает событие изменения данных.
        /// </summary>
        public delegate void ParameterChangedHandler();

        /// <summary>
        /// Событие, извещающее об изменении значения в поле для ввода.
        /// </summary>
        public event ParameterChangedHandler ParameterUserControlChanged;

        /// <summary>
        /// Тип содержимого параметра.
        /// </summary>
        public ParameterType ParameterType { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string ParameterText
        {
            get => ParameterTextBox.Text;
            set => ParameterTextBox.Text = value;
        }

        /// <summary>
        /// Название параметра.
        /// </summary>
        public string ParameterName
        {
            set => ParameterNameLabel.Text = value;
        }

        /// <summary>
        /// Границы значения параметра.
        /// </summary>
        public (string min, string max) ParameterBorders
        {
            set
            {
                var measureUnit = ParameterType switch
                {
                    ParameterType.Porosity => "%",
                    _ => "мм"
                };

                ParameterBordersLabel.Text =
                    string.Join(" ", value.min, "-", value.max, measureUnit);
            }
        }

        /// <summary>
        /// Меняет задний цвет поля для ввода значений, если значение с ошибкой.
        /// </summary>
        public bool HasError
        {
            get => _hasError;
            set
            {
                _hasError = value;
                ParameterTextBox.BackColor =
                    HasError ? _errorColor : _defaultColor;
            }
        }

        /// <summary>
        /// Проверяет вводимый текст.
        /// </summary>
        private void ParameterTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveExtraCommas();
            ParameterUserControlChanged!.Invoke();

            if (ParameterTextBox.Text.Length == 0)
            {
                HasError = true;
            }
        }

        /// <summary>
        /// Проверяет вводимый символ.
        /// </summary>
        private void ParameterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsAllowedChar(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == _decimalSeparator
                && IsCommaNotAllowed())
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Убирает лишние запятые.
        /// </summary>
        private void RemoveExtraCommas()
        {
            var sb = new StringBuilder(ParameterTextBox.Text);
            var commaIndex = sb.ToString().IndexOf(_decimalSeparator);

            if (commaIndex != -1)
            {
                sb.Replace(
                    _decimalSeparator.ToString(),
                    "",
                    commaIndex + 1,
                    sb.Length - commaIndex - 1);
            }

            if (sb.Length > 0 && sb[0] == _decimalSeparator)
            {
                sb.Remove(0, 1);
            }

            ParameterTextBox.Text = sb.ToString();
        }

        /// <summary>
        /// Проверяет допустимость символа для ввода.
        /// </summary>
        /// <param name="inputChar">Проверяемый символ.</param>
        /// <returns>
        /// <see langword="true"/> если символ – это цифра, запятая или управляющий символ;
        /// <see langword="false"/> в остальных случаях.
        /// </returns>
        private bool IsAllowedChar(char inputChar)
            => char.IsControl(inputChar)
            || char.IsDigit(inputChar)
            || inputChar == _decimalSeparator;

        /// <summary>
        /// Проверяет наличие запятой в тексте.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> если в тексте присутствует запятая;
        /// <see langword="false"/> в остальных случаях.
        /// </returns>
        private bool IsCommaNotAllowed()
            => ParameterTextBox.Text.Contains(_decimalSeparator);
    }
}