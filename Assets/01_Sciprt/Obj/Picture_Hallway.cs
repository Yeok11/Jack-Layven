using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Picture_Hallway : obj
{
    [SerializeField] private GameObject dirPassword;
    [SerializeField] private TextMeshProUGUI sign;

    private int[] dir = { 0, 0, 0, 0 }; //동서남북 ewsn

    public override void ClickEvent()
    {
        ResetValue();
        sign.text = dir[0].ToString() + dir[1].ToString() + dir[2].ToString() + dir[3].ToString();
        dirPassword.SetActive(true);
    }

    public void Check()
    {
        //news = 1225북동서남
        //2251 동서남북
        if(dir[0] == 2 && dir[1] == 2 && dir[2] == 5 && dir[3] == 1)
        {
            if (isUse) return;
            isUse = true;
            
            File.WriteAllText(GameManager.instance.path + "/사건 장소/집/복도/사업 서류.txt", "(피해자와 Leo가 준비하던 사업에 관한 서류이다.)");

            Close();
        }
        else
        {
            ResetValue();
        }
    }

    private void ResetValue()
    {
        dir = new int[4] { 0, 0, 0, 0 };
        sign.text = dir[0].ToString() + dir[1].ToString() + dir[2].ToString() + dir[3].ToString();
    }

    public void Close()
    {
        dirPassword.SetActive(false);
    }

    public void DirButton(string _dir)
    {
        switch (_dir)
        {
            case "e":
                if (++dir[0] == 10) dir[0] = 0;
                break;
            case "w":
                if (++dir[1] == 10) dir[1] = 0;
                break;
            case "s":
                if (++dir[2] == 10) dir[2] = 0;
                break;
            case "n":
                if (++dir[3] == 10) dir[3] = 0;
                break;
        }
        sign.text = dir[0].ToString() + dir[1].ToString() + dir[2].ToString() + dir[3].ToString();
    }
}
