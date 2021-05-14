using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuadTrees.Logic
{
    public interface IQuadTreeIntersectionProcessor
    {
        public void ProcessIntersection(DataPoint intersectedPoint);
    }
}
