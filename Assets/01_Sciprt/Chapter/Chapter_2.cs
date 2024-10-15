using System.Collections;
using System.IO;
using UnityEngine;

public enum HOUSE
{
    �Ա� = 0,
    �Ž�,
    ȭ���,
    �������ǹ�,
    ������,
    �ξ�,
    ����,
    �ٱ�,
    END
}

public class Chapter_2 : Chapter
{
    private string playerPath = "";
    private string playerFile = "/���ΰ�.pc";
    private HOUSE playerPos;
    [SerializeField] private Transform bgUI;

    public override IEnumerator EventWait(int _value)
    {
        GameManager.messageStop = true;

        Debug.Log("on");
        while (true)
        {
            if(GameManager.instance.chapter != this)
            {
                break;
            }

            yield return null;
            if (playerPath != "")
            {
                if (!File.Exists(playerPath))
                {
                    Debug.Log("player not find");
                    FindPlayerPos();
                    UpdatePos();
                }
            }
            else
            {
                Debug.Log("player path : None");
            }
        }

        GameManager.messageStop = false;
    }

    public void UpdatePos()
    {
        for (int i = 0; i < bgUI.childCount; i++)
        {
            bgUI.GetChild(i).gameObject.SetActive(false);
        }

        string bgName = BackGroundManager.instance.sprites[(int)playerPos].ToString();
        bgName = bgName.Remove(bgName.IndexOf(' '));
        Debug.Log(bgName);

        if (bgUI.Find(bgName) != null)
        {
            bgUI.Find(bgName).gameObject.SetActive(true);
        }
        BackGroundManager.instance.BGChangeToInt((int)playerPos);
    }

    private void FindPlayerPos()
    {
        if(File.Exists(playerPath) == false)
            playerPath = "";

        for (int i = 0; i < (int)HOUSE.END - 1; ++i)
        {
            if(File.Exists(path + "/��/" + (HOUSE.�Ա� + i) + playerFile))
            {
                playerPath = path + "/��/" + (HOUSE.�Ա� + i) + playerFile;
                playerPos = HOUSE.�Ա� + i;
                break;
            }
        }
        
        if (File.Exists(path + "/��/" + playerFile))
        {
            playerPath = path + "/��/" + playerFile;
            playerPos = HOUSE.�ٱ�;
        }
    }

    public override bool Init(string _path)
    {
        deletePath = _path;
        path = _path + "/��� ���";
        GameManager.messageStop = true;

        Directory.CreateDirectory(_path + "/����ǰ");
        Directory.CreateDirectory(_path + "/������ ���");
        File.WriteAllText(_path + "/������ ���/Leo.txt", "�̸� : Leo\n����: 22\n����: ��\n����: �Ĵ� ���� �˹�\n�����ڿ��� ����: ����б� ģ��\n" +
            "\n���\n����� �Ͼ �� �����ڶ� ���� ���� �� 2���� �������� ���� ��� ���� �湮�ߴ� ����.\n" +
            "\n\nƯ�̻���\n����");

        File.WriteAllText(_path + "/������ ���/Rachel.txt", "�̸� : Rachel\n����: 19\n����: ��\n����: ����л�\n�����ڿ��� ����: ������\n" +
            "\n���\n����� �Ͼ �� ��� �濡 �ִٰ� ģ���� ������ ���ٰ� ����.\n" +
            "�����ڰ� ���� ���� ��ÿ��� �Žǿ� ���� ���� ���� �߰������� Ȯ���� ���� �ʾҴٰ� ��." +
            "\n\nƯ�̻���\nVender�� ���� ����. ���� �����ڴ� �������� ����.");

        File.WriteAllText(_path + "/������ ���/Vender.txt", "�̸� : Vender\n����: 20\n����: ��\n����: ���� ��޿�\n�����ڿ��� ����: ����б� �Ĺ�\n" +
            "\n���\n����� �Ͼ �� ���� ����� ���ٰ� ���� ������ ������ ��� �Ž� â���� ���� ������ �ִ� �����ڸ� ���� �Ű�.\n" +
            "\n\nƯ�̻���\nRachel�� ���� ����. ���� �����ڴ� �������� ����.");

        File.WriteAllText(_path + "/������ ���/Salin.txt", "�̸� : Salin\n����: 27\n����: ��\n����: ������\n�����ڿ��� ����: ����\n" +
            "\n���\n����� �Ͼ �� �������� ���� �а� �־���.\n" +
            "������ �������� �游 �а� ������ �� ���ΰ��� ���� ���ٰ� ����" +
            "\n\nƯ�̻���\n����, ���� ħ�� ���� ���� ����.");

        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path + "/��");
            for (int i = 0; i < (int)HOUSE.END - 1; i++)
            {
                Directory.CreateDirectory(path + "/��/" + (HOUSE.�Ա� + i));
            }

            playerPath = path + "/��/�Ա�" + playerFile;
            File.Create(playerPath).Close();
        }

        Debug.Log(playerPath);
        Debug.Log("���� ����");

        UpdatePos();

        for (int i = 0; i < bgUI.childCount; i++)
        {
            bgUI.GetChild(i).gameObject.SetActive(false);
        }

        return false;
    }
}
