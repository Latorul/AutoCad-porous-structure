namespace Model
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media.Media3D;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;
    using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

    /// <summary>
    /// Класс для построения структуры.
    /// </summary>
    public class PorousBuilder
    {
        /// <summary>
        /// Строит структуру в файле автокада.
        /// </summary>
        /// <param name="parameters">Параметры.</param>
        public void BuildPorousStructure(PorousParameter parameters)
        {
            var db = Application.DocumentManager.MdiActiveDocument.Database;
            using (var tr = db.TransactionManager.StartTransaction())
            {
                var currentSpace = (BlockTableRecord)tr.GetObject(
                    db.CurrentSpaceId, OpenMode.ForWrite);

                GenerateStructure(parameters, out var box);

                currentSpace.AppendEntity(box);
                tr.AddNewlyCreatedDBObject(box, true);
                tr.Commit();
            }
        }

        /// <summary>
        /// Строит фигуру.
        /// </summary>
        /// <param name="parameters">Границы параметров.</param>
        /// <param name="box">Объект построения.</param>
        private void GenerateStructure(PorousParameter parameters, out Solid3d box)
        {
            var size = parameters.GetSizes();
            var poreSize = parameters[ParameterType.PoreSize].Value;

            var noiseGenerator = new NoiseGenerator(new Randomizer());
            var pointsArray = ConvertPoints(noiseGenerator.Generate(parameters)).ToList();

            var sphere = new Solid3d();
            box = new Solid3d();

            box.CreateBox(size.lenght, size.width, size.height);
            box.TransformBy(
                Matrix3d.Displacement(new Vector3d(
                    size.lenght / 2,
                    size.width / 2,
                    size.height / 2)));

            foreach (var point in pointsArray)
            {
                var delta = noiseGenerator.InverseNormalDistribution();
                if (poreSize + delta <= 0)
                {
                    delta = 0;
                }

                sphere.CreateSphere(poreSize + delta);
                sphere.TransformBy(
                    Matrix3d.Displacement(point - Point3d.Origin));
                box.BooleanOperation(BooleanOperationType.BoolSubtract, sphere);
            }
        }

        /// <summary>
        /// Конвертирует стандартный тип трёхмерной точки в тип Автокада.
        /// </summary>
        /// <param name="points">Список точек стандартного типа.</param>
        /// <returns>Сконвертированные точки.</returns>
        private IEnumerable<Point3d> ConvertPoints(List<Point3D> points)
        {
            return points.Select(point => new Point3d(point.X, point.Y, point.Z));
        }
    }
}