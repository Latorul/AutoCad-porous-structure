namespace StressTest
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Model;
    using Autodesk.AutoCAD.Runtime;
    using Microsoft.VisualBasic.Devices;

    public class StressTest
    {
        [CommandMethod("Test")]
        public void Test()
        {
            const int maxQuantity = 50;
            const ValueType valueType = ValueType.Average;

            var stopWatch = new Stopwatch();
            var parameters = new PorousParameter();
            SetParameterValues(parameters, valueType);
            var streamWriter = new StreamWriter(@"C:\Users\Artem\Desktop\log.txt", false);

            try
            {
                var count = 0;
                while (true)
                {
                    const double gigabyteInByte = 0.000000000931322574615478515625;

                    stopWatch.Start();
                    var builder = new PorousBuilder();
                    builder.BuildPorousStructure(parameters);
                    stopWatch.Stop();

                    var computerInfo = new ComputerInfo();
                    var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) * gigabyteInByte;

                    streamWriter.WriteLine(
                        $"{++count}\t{stopWatch.Elapsed}\t{usedMemory}");
                    streamWriter.Flush();
                    stopWatch.Reset();
                }
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        private void SetParameterValues(PorousParameter parameters, ValueType valueType)
        {
            foreach (ParameterType parameterType in Enum.GetValues(typeof(ParameterType)))
            {
                var parameter = parameters[parameterType];
                var value = GetTargetValue(parameter, valueType);

                parameters.SetValue(parameterType, value);
            }
        }

        private double GetTargetValue(Parameter parameter, ValueType valueType) =>
            valueType switch
            {
                ValueType.Min => parameter.MinValue,
                ValueType.Max => parameter.MaxValue,
                ValueType.Average => (parameter.MaxValue + parameter.MinValue) / 2
            };
    }
}