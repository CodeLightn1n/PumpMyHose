using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PSIElements
{
    
    public static class PSIManager
    {
        static int OverallPSI;

        /// <summary>
        /// Sets the overall PSI
        /// </summary>
        /// <param name="psi"></param>
        public static void SetOverallPSI(int psi)
        {
            OverallPSI = psi;
        }
        /// <summary>
        /// Adds onto overall psi to subtract make the int negative
        /// </summary>
        /// <param name="psi"></param>
        public static void AddOverallPSi(int psi)
        {
            OverallPSI += psi;
        }
        /// <summary>
        /// Get the overall PSI
        /// </summary>
        /// <returns>the overall PSI</returns>
        public static int GetOverallPSI()
        {
            return OverallPSI;
            
        }
    }
}
