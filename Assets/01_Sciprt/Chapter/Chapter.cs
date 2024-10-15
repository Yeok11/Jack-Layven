using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public abstract class Chapter : MonoBehaviour
{
    protected string path;
    protected string deletePath;
    public MessageBoxSO chapterContexts;

    public virtual bool Init(string _path)
    {
        return true;
    }

    public virtual IEnumerator EventWait(int _value) { yield return null; }

    public void OnDestroy()
    {
        if (Directory.Exists(deletePath))
        {
            Directory.Delete(deletePath, true);
        }
        FindNotepadOpen.CloseNotepad("사건 보고서");
    }
}
