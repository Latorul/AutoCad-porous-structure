namespace View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Model;

    /// <summary>
    /// Форма для ввода параметров.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список со всеми полями для ввода параметров.
        /// </summary>
        private List<ParameterUserControl> _parameterUserControls;

        /// <summary>
        /// Словарь, сопоставляющий типы параметров к их именам.
        /// </summary>
        private Dictionary<ParameterType, string> _parameterTypeName;

        /// <summary>
        /// Словарь с сообщениями об ошибках.
        /// </summary>
        private Dictionary<ParameterType, string> _errors;

        /// <summary>
        /// Конструктор Формы.
        /// </summary>
        public MainForm(PorousParameter parameters)
        {
            Parameters = parameters;
            InitializeComponent();
            InitializeDictionaries();
            InitializeParameterUserControls();
        }

        /// <summary>
        /// Объект со словарём параметров.
        /// </summary>
        private PorousParameter Parameters { get; }

        /// <summary>
        /// Метод для запуска построения объекта в САПР.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> если работа формы завершена корректно;
        /// <see langword="false"/> в остальных случаях.
        /// </returns>
        public bool BuildPorousStructure()
            => ShowDialog() == DialogResult.OK;

        /// <summary>
        /// Инициализирует словарь, сопоставляющий ParameterType к их именам.
        /// </summary>
        private void InitializeDictionaries()
        {
            _parameterTypeName = new Dictionary<ParameterType, string>
            {
                { ParameterType.Length, "Длина" },
                { ParameterType.Width, "Ширина" },
                { ParameterType.Height, "Высота" },
                { ParameterType.Porosity, "Пористость" },
                { ParameterType.PoreSize, "Размер пор" }
            };

            _errors = new Dictionary<ParameterType, string>
            {
                { ParameterType.Length, string.Empty },
                { ParameterType.Width, string.Empty },
                { ParameterType.Height, string.Empty },
                { ParameterType.Porosity, string.Empty },
                { ParameterType.PoreSize, string.Empty }
            };
        }

        /// <summary>
        /// Инициализирует список ParameterUserControl.
        /// </summary>
        private void InitializeParameterUserControls()
        {
            _parameterUserControls = new List<ParameterUserControl>
            {
                LengthParameterUserControl,
                WidthParameterUserControl,
                HeightParameterUserControl,
                PorosityParameterUserControl,
                PoreSizeParameterUserControl
            };

            _parameterUserControls.ForEach(p =>
            {
                p.ParameterUserControlChanged += OnParameterUserControlChanged;
                p.ParameterName = _parameterTypeName[p.ParameterType];
                p.ParameterText = Parameters[p.ParameterType].MaxValue.ToString();
            });
        }

        /// <summary>
        /// Событие обновления элемента управления.
        /// </summary>
        /// <param name="sender">Вызвавший элемент управления.</param>
        private void OnParameterUserControlChanged(ParameterUserControl sender)
        {
            try
            {
                Validate(sender);
            }
            catch
            {
            }
            finally
            {
                foreach (var control in _parameterUserControls)
                {
                    Validate(control);
                }

                UpdateBordersText();
            }
        }

        /// <summary>
        /// Валидирует введённое значение.
        /// </summary>
        /// <param name="parameterUserControl">Изменяемый параметр.</param>
        private void Validate(ParameterUserControl parameterUserControl)
        {
            var parameterType = parameterUserControl.ParameterType;
            try
            {
                parameterUserControl.HasError = false;
                _errors[parameterType] = string.Empty;

                double.TryParse(parameterUserControl.ParameterText, out double value);
                Parameters[parameterType].Value = value;

                Parameters.ValidateDependentParameters();
            }
            catch (ArgumentException e)
            {
                parameterUserControl.HasError = true;
                _errors[parameterType] =
                    $"• {_parameterTypeName[parameterType]}:" +
                    $" {e.Message}";
            }
        }

        /// <summary>
        /// Закрывает форму для построения структуры.
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (_errors.Values.Any(p => p.Length > 0))
            {
                MessageBox.Show(
                    string.Join(
                        Environment.NewLine,
                        _errors.Values.Where(e => e.Length > 0)),
                    "Обнаружены конфликтующие значения параметров",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обновляет текст границ.
        /// </summary>
        private void UpdateBordersText()
        {
            foreach (var parameterUserControl in _parameterUserControls)
            {
                var minValue =
                    Parameters[parameterUserControl.ParameterType]
                    .MinValue.ToString();
                var maxValue =
                    Parameters[parameterUserControl.ParameterType]
                    .MaxValue.ToString();

                parameterUserControl.ParameterBorders = (minValue, maxValue);
            }
        }
    }
}