using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public static class FindNotepadOpen
{
    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern bool GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);


    public static bool NotepadFileOpenNow(string _fileName)
    {
        bool fileOpenNow = false;

        EnumWindows((hWnd, lParam) =>
        {
            if(IsWindowVisible(hWnd))
            {
                StringBuilder windowText = new StringBuilder(256);
                GetWindowText(hWnd, windowText, windowText.Capacity);
                string title = windowText.ToString();

                if(title.Contains(_fileName))
                {
                    fileOpenNow = true;
                    return false;
                }
            }
                return true; // 계속 열거
           
        }, IntPtr.Zero);

        return fileOpenNow;
    }


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    // user32.dll에서 PostMessage를 가져옴 (메시지를 보내기 위한 함수)
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    public static void CloseNotepad(string _windowName)
    {
        IntPtr wnd = FindWindow(null, _windowName + " - 메모장");

        if(wnd != IntPtr.Zero)
            PostMessage(wnd, (uint)0x0010, IntPtr.Zero, IntPtr.Zero);
    }
}

//using System;
//using UnityEngine;
//using System.Diagnostics;
//using Debug = UnityEngine.Debug;

//public class WallPaperOffSystem : MonoBehaviour
//{
//    public static void Close()
//    {
//        Process[] processList = Process.GetProcesses();
//        Process[] processs = Process.GetProcessesByName("wallpaper32");

//        Debug.Log(processs.Length);
//        foreach (Process item in processs)
//        {
//            try
//            {
//                Debug.Log(item.ProcessName);
//                item.Kill();
//            }
//            catch (Exception ex) { }
//            finally
//            {
//                item.Close();
//            }
//        }

//        return;
//        foreach (Process process in processList)
//        {
//            try
//            {
//                if (process.ProcessName.Contains("wallpaper"))
//                {
//                    process.Kill();
//                    process.WaitForExit();
//                    Debug.Log("Wallpaper종료");
//                    return;
//                }
//            }
//            catch (Exception ex) { }
//            finally
//            {
//                process.Close();
//            }
//        }

//        Debug.Log("wallpaper감지 실패");
//    }
//}
