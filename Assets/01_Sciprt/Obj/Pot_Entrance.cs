using System.IO;
using UnityEngine;

public class Pot_Entrance : obj
{
    [SerializeField] private Texture2D texture;

    private void LoadImg()
    {
        byte[] imgData = texture.EncodeToPNG();
        File.WriteAllBytes(GameManager.instance.path + "/사건 장소/집/입구" + "/알 수 없는 메모.png", imgData);
    }

    public override void ClickEvent()
    {
        if (isUse) return;
        isUse = true;

        LoadImg();
    }
}
