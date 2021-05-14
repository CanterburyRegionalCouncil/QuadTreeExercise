using System;

namespace FunWithQuadTrees.Logic
{
    public class DataException : Exception
    {
        private const long _serialVersionUID = 1L;

        public DataException(string description, Exception e) :
            base(description, e)
        {
        }

        public DataException(string format) :
                base(format)
        {

        }

        public DataException(Exception e) :
                base(string.Empty, e)
        {

        }
    }
}
