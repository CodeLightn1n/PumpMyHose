using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PSIElements
{
    
    public static class PSIManager
    {
        static int OverallPSI;

        static float battlefeild;

        /// <summary>
        /// Sets the PSI that everything will share
        /// </summary>
        /// <param name="psi"></param>
        public static void SetOverallPSI(int psi)
        {
            OverallPSI = psi;
        }
        public static int GetOverallPSI()
        {
            return OverallPSI;
            
        }
    }
}
