namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Содержит все параметры.
    /// </summary>
    public class PorousParameter
    {
        /// <summary>
        /// Минимальное значение зависимых параметров.
        /// </summary>
        private readonly double _minDependentValue = 1;

        /// <summary>
        /// Минимальное значение независимого параметра.
        /// </summary>
        private readonly double _minIndependentValue = 0.001;

        /// <summary>
        /// Словарь со всеми параметрами.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public PorousParameter()
        {
            DependentParametersList = new List<ParameterType>
            {
                ParameterType.Length,
                ParameterType.Width,
                ParameterType.Height
            };

            _parameters = new Dictionary<ParameterType, Parameter>
            {
                {
                    ParameterType.Length, new Parameter(_minIndependentValue, 35)
                    {
                        Value = 35
                    }
                },
                {
                    ParameterType.Width, new Parameter(_minIndependentValue, 35)
                    {
                        Value = 35
                    }
                },
                {
                    ParameterType.Height, new Parameter(_minIndependentValue, 35)
                    {
                        Value = 35
                    }
                },
                {
                    ParameterType.Porosity, new Parameter(0, 50)
                    {
                        Value = 50
                    }
                },
                {
                    ParameterType.PoreSize, new Parameter(1, 5)
                    {
                        Value = 5
                    }
                }
            };
        }

        /// <summary>
        /// Список типов зависимых параметров.
        /// </summary>
        private List<ParameterType> DependentParametersList { get; }

        /// <summary>
        /// Перегрузка оператора для получения доступа к словарю параметров.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter this[ParameterType type] => _parameters[type];

        /// <summary>
        /// Устанавливает значение параметру.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <param name="value">Новое значение параметра.</param>
        public void SetValue(ParameterType type, double value)
        {
            this[type].Value = value;
            ValidateDependentParameters();
        }

        /// <summary>
        /// Достаёт размеры из параметров.
        /// </summary>
        /// <returns>Кортеж с длиной, шириной и высотой.</returns>
        public (double lenght, double width, double height) GetSizes()
            => (this[ParameterType.Length].Value,
                this[ParameterType.Width].Value,
                this[ParameterType.Height].Value);

        /// <summary>
        /// Проверяет значения между собой на соответствие граничным условиям.
        /// </summary>
        /// <exception cref="AggregateException">
        /// Обнаружены конфликтующие значения параметров.</exception>
        private void ValidateDependentParameters()
        {
            var dependentParameters = _parameters
                .Where(parameter => IsDependentParameterType(parameter.Key));

            try
            {
                var independentParameterType =
                    dependentParameters.Single(c =>
                    c.Value.Value < _minDependentValue).Key;

                UpdateBorders(independentParameterType);
            }
            catch (InvalidOperationException)
            {
                ResetBorders();
            }
        }

        /// <summary>
        /// Сбрасывает значения границ зависимых параметров.
        /// </summary>
        private void ResetBorders()
        {
            foreach (var parameter
                in _parameters.Where(p => IsDependentParameterType(p.Key)))
            {
                parameter.Value.MinValue = _minIndependentValue;
            }
        }

        /// <summary>
        /// Устанавливает меньшие границы для зависимых параметров.
        /// </summary>
        /// <param name="independentParameterType">Главный параметр.</param>
        private void UpdateBorders(ParameterType independentParameterType)
        {
            foreach (var parameter in _parameters
                .Where(p => IsDependentParameterType(p.Key)
                && p.Key != independentParameterType))
            {
                parameter.Value.MinValue = _minDependentValue;
            }
        }

        /// <summary>
        /// Определяет, является ли тип параметра зависимым.
        /// </summary>
        /// <param name="type">Проверяемый тип.</param>
        /// <returns>
        /// <see langword="true"/> если параметр является зависимым;
        /// <see langword="false"/> в остальных случаях.
        /// </returns>
        private bool IsDependentParameterType(ParameterType type)
            => DependentParametersList.Any(t => t == type);
    }
}