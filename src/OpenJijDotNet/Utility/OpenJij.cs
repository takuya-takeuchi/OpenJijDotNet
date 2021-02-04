using System;
using System.IO;
using System.Linq;
using System.Text;

using OpenJijDotNet.Utilities;

namespace OpenJijDotNet
{

    /// <summary>
    /// Provides the methods of OpenJij.
    /// </summary>
    public static partial class OpenJij
    {

        #region Methods

        public static ClassicalScheduleList MakeClassicalScheduleList(double betaMin,
                                                                      double betaMax,
                                                                      uint oneMcStep,
                                                                      uint numCallUpdater)
        {
            var ret = NativeMethods.utility_schedule_list_make_classical_schedule_list(betaMin,
                                                                                       betaMax,
                                                                                       oneMcStep,
                                                                                       numCallUpdater);
            return new ClassicalScheduleList(ret, true);
        }
        
        #endregion

    }

}