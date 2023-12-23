namespace Model
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media.Media3D;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;

    /// <summary>
    /// Класс для построения структуры.
    /// </summary>
    public class PorousBuilder
    {
        /// <summary>
        /// aesgd.
        /// </summary>
        public void BuildPorousStructure(PorousParameter parameters)
        {
            Database db = Application.DocumentManager.MdiActiveDocument.Database;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                var currentSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                GenerateStructure(parameters, out Solid3d box);

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
            (double lenght, double width, double height) size = (
                parameters[ParameterType.Length].Value,
                parameters[ParameterType.Width].Value,
                parameters[ParameterType.Height].Value);
            var poreSize = parameters[ParameterType.PoreSize].Value;

            var noiseGenerator = new NoiseGenerator(new Randomizer());
            var pointsArray = ConvertPoints(noiseGenerator.Generate(parameters)).ToList();

            var sphere = new Solid3d();
            box = new Solid3d();

            box.CreateBox(size.lenght, size.width, size.height);
            box.TransformBy(
                Matrix3d.Displacement(new Vector3d(size.lenght / 2, size.width / 2, size.height / 2)));

            for (int i = 0; i < pointsArray.Count; i++)
            {
                sphere.CreateSphere(poreSize);
                sphere.TransformBy(
                    Matrix3d.Displacement(pointsArray[i] - Point3d.Origin));
                box.BooleanOperation(BooleanOperationType.BoolSubtract, sphere);
            }
        }

        private IEnumerable<Point3d> ConvertPoints(List<Point3D> points)
        {
            return points.Select(point => new Point3d(point.X, point.Y, point.Z));
        }
    }
}