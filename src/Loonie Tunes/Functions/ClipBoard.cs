using System;
using System.Threading;
using System.Windows.Forms;

namespace Loonie_Tunes.Functions
{
    public class ClipBoard
    {
        //Demonstrates SetText, ContainsText, and GetText.
        public void SwapClipboardText(String replacementText)
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                if (replacementText != "")
                {
                    Clipboard.SetText(replacementText, TextDataFormat.Text);
                }
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}
