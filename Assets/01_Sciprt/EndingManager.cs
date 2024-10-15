using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EndingManager : MonoBehaviour
{
    public static EndingManager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this;
    }

    bool selectCriminal = false;
    bool evidence = true;

    public int EndingCheck()
    {
        string path = GameManager.instance.path + "/����ǰ/";
        if(Directory.Exists(path))
        {
            if(File.Exists(path + "Leo.txt"))
                selectCriminal = true;
            if (!File.Exists(path + "��� ����.txt"))
                evidence = false;
            if (!File.Exists(path + "Leo���� �޽��� ����.txt"))
                evidence = false;
            if (!File.Exists(path + "���� �� ����.png"))
                evidence = false;

            if (selectCriminal == false && evidence == false) return 1;
            if (evidence == false) return 2;
            if (selectCriminal == false) return 3;
            if (Directory.GetFiles(path).Length != 4) return 4;
            return 5;
        }
        else
        {
            Application.Quit();
            Alert.AlertBox("����ǰ�� �������� �ʴ´�...", "Error_Bug", 0x00000004L);
            
            return 0;
        }
    }
}
//string path = Application.dataPath;
//path = path.Remove(path.LastIndexOf("Zack&Layven"));

//if (File.Exists(path + "Zack&You's Ž���繫��.exe"))
//{
//    if (Directory.Exists(path + "Zack&Layven's Ž���繫��_Data"))
//        Directory.Delete(path + "Zack&Layven's Ž���繫��_Data");
//}

//File.Move(path + "Zack&Layven's Ž���繫��.exe", path + "Zack&You" + "'s Ž���繫��.exe");

//if (Directory.Exists(path + "Zack&Layven's Ž���繫��_BurstDebugInformation_DoNotShip"))
//    Directory.Move(path + "Zack&Layven's Ž���繫��_BurstDebugInformation_DoNotShip",
//        path + "Zack&You" + "'s Ž���繫��_BurstDebugInformation_DoNotShip");

//CopyDirectory(path + "Zack&Layven's Ž���繫��_Data", path + "Zack&You's Ž���繫��_Data");

//Application.Quit();