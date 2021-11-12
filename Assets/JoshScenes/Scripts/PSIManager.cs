using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PSIElements
{
    public static class PSIManager
    {
        static int OverallPSI;

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
