using System.IO;
using UnityEngine;

public class Phone_BedRoom : obj
{
    public override void ClickEvent()
    {
        if (isUse) return;
        isUse = true;
        string path = GameManager.instance.path + "/��� ���/��/�������ǹ�/�޴���ȭ";
        Directory.CreateDirectory(path);

        File.WriteAllText(path + "/Rachel���� �޽��� ����.txt",
            "��� ���� ���� ����\n\n" +
            "Me: ��\n" +
            "Me: ��\n" +
            "Me: ��\n" +
            "Me: ����?\n" +
            "Rachel: ��\n" +
            "Me: �� ���� ������\n" +
            "Rachel: ��?\n" +
            "Me: ��ġ�� ���غ�\n" +
            "Rachel: 0307\n");

        File.WriteAllText(path + "/Leo���� �޽��� ����.txt", 
            "��� ���� ���� ����\n\n" +
            "Leo: ��\n" +
            "Leo: ����\n" +
            "Me: ��\n" +
            "Leo: �� ��\n" +
            "Me: �� ���� �� �Ű�?\n" +
            "Leo: �װ� �� ����\n" +
            "Leo: ���� �ڼ��� ������\n" +
            "Me: ����");
        
        File.WriteAllText(path + "/Vender���� �޽��� ����.txt", "���� ���� ������ �����ϴ�.");
        
        File.WriteAllText(path + "/Shy���� �޽��� ����.txt", "Shy: �ڰ� �ʹ�.");
    }
}
