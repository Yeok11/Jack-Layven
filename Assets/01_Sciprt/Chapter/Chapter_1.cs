using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chapter_1 : Chapter
{
    [SerializeField] private Image layven;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite bad;

    public override bool Init(string _path)
    {
        path = _path + "/��� ����";

        FindNotepadOpen.CloseNotepad("��� ����");
        if (Directory.Exists(_path))
        {
            Directory.Delete(_path, true);
        }
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/��� ����.txt", 
            "��� ���� : ���� ���\n" +
            "������\n" +
            "�̸� : ----\n" +
            "���� : 22\n" +
            "��� ��� : ���� �Ž�\n" +
            "��� : ȭ��");
        deletePath = _path;

       return false;
    }

    int p = 0;

    public override IEnumerator EventWait(int _value)
    {
        GameManager.messageStop = true;

        switch (_value)
        {
            case 5:
                layven.gameObject.SetActive(true);
                float a = 0;
                while (a < 1)
                {
                    a += 0.1f;
                    layven.color = new Color(1, 1, 1, a);
                    yield return new WaitForSeconds(0.1f);
                }
                break;

            case 7:
                layven.sprite = bad;
                break;

            case 8:
                while (FindNotepadOpen.NotepadFileOpenNow("��� ����.txt") == false)
                {
                    yield return null;
                }
                p++;
                break;

            case 9:
                layven.sprite = normal;
                break;
        }

        if(p==1)
            GameManager.messageStop = false;

        if (_value != 6)
            GameManager.messageStop = false;
    }
}
