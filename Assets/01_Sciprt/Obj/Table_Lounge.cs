using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Table_Lounge : obj
{
    public override void ClickEvent()
    {
        if (isUse) return;
        isUse = true;

        string path = GameManager.instance.path + "/��� ���/��/�Ž�/";
        File.WriteAllText(path + "�ǰ� Ƣ�� �Ź�.txt", "������ NEWS\n\t\t\t\t0��� ��7��\n" +
            "���� 00�� 16�� �� ������ �š�ᰡ �¶��� �޽šḦ �̡��� ���� ���αס��� �����Ͽ����ϴ�. �̿� ���� ��������...");
        File.WriteAllText(path + "�ǰ� Ƣ�� ���� �� �Ź�.txt", "����� NEWS\n\t\t\t\t12��25��\n\n" +
            "�ẹ���� ������ ũ��������, ��⸸�� ������ ȭ��Ʈ ũ�������� ���ɿ��� ������� �ߡ��� ������ �ʰ� �׿� ���� ��ǻ�� ���� ����...\n" +
            "���� �Ѱ������ ����� ���� ���¡� �ϸ�, �ֺ� �󰡿� ���ظ� ���� ����...");
    }
}
