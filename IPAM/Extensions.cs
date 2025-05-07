using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM; 
internal static class Extensions {
    public static void Clear(this Control.ControlCollection controls, bool dispose) {
        for (int ix = controls.Count - 1; ix >= 0; --ix) {
            if (dispose) controls[ix].Dispose();
            else controls.RemoveAt(ix);
        }
    }

    public static bool IsEmpty(this string s) => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
}

