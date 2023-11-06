using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;

namespace Model
{
    public class PorousBuilder
    {
        public void BuildPorousStructure(PorousParameter parameters, Transaction transaction)
        {
            
        }

        private List<ObjectId> CombinePointsToPolyLines(List<ObjectId> points)
        {
            return null;
        }

        private List<ObjectId> CombinePolyLinesToFaces(List<ObjectId> polyLines)
        {
            return null;
        }

        private void CombineFacesToSolid(List<ObjectId> faces)
        {
            
        }
    }
}