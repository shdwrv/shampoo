using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shampoo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.AddMessageFilter(new AltF4Filter());
            Application.Run(new Form1());
        }

        public class AltF4Filter : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                const int WM_SYSKEYDOWN = 0x0104;
                if (m.Msg == WM_SYSKEYDOWN)
                {
                    bool alt = ((int)m.LParam & 0x20000000) != 0;
                    if (alt && (m.WParam == new IntPtr((int)Keys.F4)))
                        return true; // eat it!                
                }
                return false;
            }
        }
    }
}
