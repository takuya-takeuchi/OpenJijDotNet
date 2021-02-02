using System.Collections.Generic;

namespace OpenJijDotNet
{
    
    public sealed class Spins :List<Spin>
    {

        #region Constructors

        public Spins(int capacity) :
            base(capacity)
        {
        }

        public Spins(IEnumerable<Spin> collection) :
            base(collection)
        {
        }

        #endregion

    }

}