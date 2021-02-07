using System.Collections.Generic;

namespace OpenJijDotNet
{
    
    public sealed class Nodes :List<Index>
    {

        #region Constructors

        public Nodes(int capacity) :
            base(capacity)
        {
        }

        public Nodes(IEnumerable<Index> collection) :
            base(collection)
        {
        }

        #endregion

    }

}