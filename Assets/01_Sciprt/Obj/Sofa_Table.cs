using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Sofa_Table : obj
{
    [SerializeField] private Texture2D txt2d;

    private void LoadImg()
    {
        byte[] imgData = txt2d.EncodeToPNG();
        File.WriteAllBytes(GameManager.instance.path + "/사건 장소/집/거실" + "/쇼파 밑 사진.png", imgData);
    }
    public override void ClickEvent()
    {
        if (isUse) return;
        isUse = true;

        LoadImg();
    }
}
