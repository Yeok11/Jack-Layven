using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr hwnd, IntPtr text, IntPtr titleName, uint flag);

    public static int flagidx = 0;
    private static long[] flag = { 0x00000030L, 0x00000020L, 0x00000010L, 0x00000040L };

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public static void AlertBox(string text, string cap, long _flag)
    {
        IntPtr textMarshal = Marshal.StringToHGlobalUni(text);
        IntPtr capMarshal = Marshal.StringToHGlobalUni(cap);

        int r = MessageBox(GetActiveWindow(), textMarshal, capMarshal, (uint)(_flag + flag[flagidx % 4]));

        Marshal.FreeHGlobal(textMarshal);
        Marshal.FreeHGlobal(capMarshal);
    }
}
