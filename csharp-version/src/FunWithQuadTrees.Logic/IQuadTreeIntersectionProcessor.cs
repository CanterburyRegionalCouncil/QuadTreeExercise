using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuadTrees.Logic
{
    /// <summary>
    /// Processes the a data point against a <see cref="QuadTree"/> to determine if the point intersects
    /// </summary>
    public interface IQuadTreeIntersectionProcessor
    {
        public void ProcessIntersection(DataPoint intersectedPoint);
    }
}
