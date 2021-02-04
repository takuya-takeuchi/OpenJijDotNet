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

        #endregion

    }

}