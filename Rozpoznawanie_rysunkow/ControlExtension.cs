using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rozpoznawanie_rysunkow
{
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
        public static void InvokeIfRequired<T>(this Control control, Action<T> action, T parameter)
        {
            if (control.InvokeRequired)
                control.Invoke(action, parameter);
            else
                action(parameter);
        }
    }
}
