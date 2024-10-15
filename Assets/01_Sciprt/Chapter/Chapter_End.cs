using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Chapter_End : Chapter
{
    [SerializeField] private EndingManager endManager;
    [SerializeField] private Image layven;

    [SerializeField] private Sprite normalFace;
    [SerializeField] private Sprite normalEndFace;
    [SerializeField] private Sprite hidenEndFace;

    int result = 0;

    public override IEnumerator EventWait(int _value)
    {
        Debug.Log(GameManager.instance.messCnt);
        result = 1 + endManager.EndingCheck();
        Debug.Log(result);
        yield return new WaitForSeconds(4);

        GameManager.instance.messCnt = result;
        GameManager.instance.ActText();
        //�󱼹ٲٱ�
        if (result == 5)
            layven.sprite = hidenEndFace;
        else
            layven.sprite = normalEndFace;

        yield return new WaitForSeconds(5);

        

        if (result == 7)
        {
            Application.Quit();

            PlayerPrefs.SetString("Clear", "true");
            File.WriteAllText(Application.dataPath + "�׳��� ����. To you.txt", 
                "���� Leo�� ���б� ������ ģ�� ���̿���.\n\n������ ���̼� ����� �غ��ϰ� �־���.\n\n" +
                "�°� ���� �̻��� �� �ϴµ� �� ������ �ʿ��ϴٴ� �ž�.\n\n�׸��� �׳��� Leo�� ���� ���ڰ� �ҷ���, " +
                "����� ����� ���� ��⸦ ���ڸ����� �ϰ� �ƾ�.\n\n�ٵ� �ű⼭ Leo�� ���� �ٺ����� �ǰ��� �� �¾Ƽ� " +
                "�ο��� �ž�.\n\n�츰 ���Կ��� �Ѱܳ���, �ϴ� ���� ���� ���� �̾߱� �ϱ�� ����.\n\n" +
                "���� ���� �ͱ����� ���Ҿ�.\n\n�׷��� �ű⼭ ���� �ʹ� ���� �Ծ�����, ���� �ο� �� Ŀ����, " +
                "Leo�� �� �Ӹ��� ȭ������ ġ�����.\n\n�̾�~�󸶳� ������ �� �𸦰�?\n\n�׷���� ����� �Ǿ ����������.\n\n" +
                "���� �ؿ� LEO��� ���� �� �־��µ�, �ʰ� �װ� �߰������.\n\n���� �Ǹ� �ñ����� �ʾ�? " +
                "��� ���� ���� �ʶ� �̷��� ��ȭ�� �� �ִ���.\n\n��, �� �����ʹϱ� ���� �� �������� �ʾҴ����.(���� �ƴ�����)" +
                "\n\n�׷��� ���� �� �ι����� ���� �������� ����.\n\n�׷��� ������ ��Ź�� �ž�~ ><\n\n" +
                "�׷��� �� �����״� �Ⱥ� ������.\n\n�̷� �ĵ� ���� ������ ���̴ϱ�.\n\n�׸��� �繫�ǿ��� " +
                "�װ� �ɾ� �ִ� �ڸ��� ���� �� �ڸ��ŵ�?\n\n���� �̷� ������ ��� �������� ������ �������ϱ� �� �����޾ƶ�.\n\n" +
                "�׸��� �ƽ����� ���� �װ� ���ӿ� �ٽ� �����ص� �÷��̴� �� �ɰ�?\n\n�׾�, �װ� �� �̾߱⸦ Ǯ�����ݾ�.\n\n" +
                "�̰� ��¥ Ʈ�� �����̴ϱ� �⻵��.\n\n�׸��� �ƽ��Ե� �̰� �̿��ð� �ƴ϶���.\n\n..." +
                "\n\n�ƹ�ư, ������ �����༭ ������.\n\n���� �� �����ʹ� �� ��ǻ�Ϳ��� ������ �������� �ž�.\n\n" +
                "�� ���� �����.\n\n - ��� ������ : Layven ���̺�(���� �� �繫���� ����) -\n\n");

            

            Alert.AlertBox("���� " + PlayerPrefs.GetString("Player"), "Layven", 0x00000030L);
        }
        else if(result != 5)
        {
            Application.Quit();
            Alert.AlertBox("�ٽ� �������� �غ��� �ž�.", "Layven", 0x00000030L);
        }
        StopAllCoroutines();
    }

    public override bool Init(string _path)
    {
        BackGroundManager.instance.BG_Office(true);
        layven.gameObject.SetActive(true);
        layven.sprite = normalFace;
        GameManager.instance.messagePanel.gameObject.SetActive(true);
        GameObject.Find("Bg UI").SetActive(false);
        GameManager.isStory = false;
        return true;
    }

    private void CopyDirectory(string _source, string _target)
    {
        if (!Directory.Exists(_source))
        {
            Debug.LogError($"Source directory does not exist: {_source}");
            return;
        }

        // Ÿ�� ���͸��� ������ ����
        if (!Directory.Exists(_target))
        {
            Directory.CreateDirectory(_target);
        }

        // ���� ���͸��� ���� ����
        foreach (var file in Directory.GetFiles(_source))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(_target, fileName);
            File.Copy(file, destFile, true); // true: ���� ���� �����
        }

        // ���� ���͸��� ���� ���͸� ����
        foreach (var subdir in Directory.GetDirectories(_source))
        {
            string dirName = Path.GetFileName(subdir);
            string destSubdir = Path.Combine(_target, dirName);
            CopyDirectory(subdir, destSubdir);
        }
    }
}
