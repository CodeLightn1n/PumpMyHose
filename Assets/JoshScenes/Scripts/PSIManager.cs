using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PSIElements
{
    
    public static class PSIManager
    {
        static int OverallPSI;

        static float battlefeild;

       
        public static void function()
        {
            Debug.Log("You smell bazza");
        }
        /// <summary>
        /// Sets the PSI that everything will share
        /// </summary>
        /// <param name="psi"></param>
        public static void SetOverallPSI(int psi)
        {
            OverallPSI = psi;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the overall PSI</returns>
        public static int GetOverallPSI()
        {
            return OverallPSI;
            
        }
    }
}
