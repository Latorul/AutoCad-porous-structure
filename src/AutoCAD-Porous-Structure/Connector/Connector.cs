namespace Connector
{
    using Autodesk.AutoCAD.Runtime;
    using Model;
    using View;

    /// <summary>
    /// Класс соединяющий AutoCAD и плагин.
    /// </summary>
    public class Connector
    {
        /// <summary>
        /// Команда, вызываемая из AutoCAD.
        /// </summary>
        [CommandMethod("PORK")]
        public void OpenPorousStructureBuilderForm()
        {
            if (!OpenMainForm(out PorousParameter porousParameter))
            {
                return;
            }

            var builder = new PorousBuilder();
            builder.BuildPorousStructure(porousParameter);
        }

        /// <summary>
        /// Открытие формы для заполнения параметров.
        /// </summary>
        /// <param name="porousParameter">Заполненные параметры.</param>
        /// <returns>
        /// <see langword="true"/> если работа формы завершена корректно;
        /// <see langword="false"/> в остальных случаях.
        /// </returns>
        private bool OpenMainForm(out PorousParameter porousParameter)
        {
            porousParameter = new PorousParameter();
            var mainForm = new MainForm(porousParameter);
            return mainForm.BuildPorousStructure();
        }
    }
}