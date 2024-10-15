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
        //얼굴바꾸기
        if (result == 5)
            layven.sprite = hidenEndFace;
        else
            layven.sprite = normalEndFace;

        yield return new WaitForSeconds(5);

        

        if (result == 7)
        {
            Application.Quit();

            PlayerPrefs.SetString("Clear", "true");
            File.WriteAllText(Application.dataPath + "그날의 진실. To you.txt", 
                "나랑 Leo는 중학교 때부터 친구 사이였어.\n\n지금은 둘이서 사업도 준비하고 있었지.\n\n" +
                "걔가 뭔가 이상한 걸 하는데 내 도움이 필요하다는 거야.\n\n그리고 그날은 Leo가 술을 먹자고 불렀고, " +
                "겸사겸사 사업에 관한 얘기를 술자리에서 하게 됐어.\n\n근데 거기서 Leo랑 내가 바보같이 의견이 안 맞아서 " +
                "싸웠던 거야.\n\n우린 가게에서 쫓겨났고, 일단 집에 가서 마저 이야기 하기로 했지.\n\n" +
                "집에 가는 것까지는 좋았어.\n\n그런데 거기서 술을 너무 많이 먹었는지, 서로 싸움만 더 커졌고, " +
                "Leo가 내 머리를 화분으로 치더라고.\n\n이야~얼마나 아픈지 넌 모를걸?\n\n그러고는 사색이 되어서 도망가더라.\n\n" +
                "소파 밑에 LEO라고 적힌 게 있었는데, 너가 그걸 발견해줬네.\n\n이쯤 되면 궁금하지 않아? " +
                "어떻게 죽은 내가 너랑 이렇게 대화할 수 있는지.\n\n뭐, 난 데이터니까 아직 다 지워지지 않았더라고.(이젠 아니지만)" +
                "\n\n그래서 게임 속 인물들은 나를 인지하지 못해.\n\n그래서 너한테 부탁한 거야~ ><\n\n" +
                "그래도 잭 씨한테는 안부 전해줘.\n\n이래 봬도 마음 여리신 분이니까.\n\n그리고 사무실에서 " +
                "네가 앉아 있는 자리는 원래 내 자리거든?\n\n내가 이래 보여도 퇴사 전까지는 열심히 일했으니까 잘 물려받아라.\n\n" +
                "그리고 아쉽지만 이제 네가 게임에 다시 접속해도 플레이는 안 될걸?\n\n그야, 네가 내 이야기를 풀어줬잖아.\n\n" +
                "이게 진짜 트루 엔딩이니까 기뻐해.\n\n그리고 아쉽게도 이건 미연시가 아니란다.\n\n..." +
                "\n\n아무튼, 진실을 밝혀줘서 고마웠어.\n\n이제 내 데이터는 네 컴퓨터에서 완전히 지워졌을 거야.\n\n" +
                "이 편지 빼고는.\n\n - 사건 피해자 : Layven 레이븐(이전 잭 사무소의 조수) -\n\n");

            

            Alert.AlertBox("고마워 " + PlayerPrefs.GetString("Player"), "Layven", 0x00000030L);
        }
        else if(result != 5)
        {
            Application.Quit();
            Alert.AlertBox("다시 차근차근 해보는 거야.", "Layven", 0x00000030L);
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

        // 타겟 디렉터리가 없으면 생성
        if (!Directory.Exists(_target))
        {
            Directory.CreateDirectory(_target);
        }

        // 원본 디렉터리의 파일 복사
        foreach (var file in Directory.GetFiles(_source))
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(_target, fileName);
            File.Copy(file, destFile, true); // true: 기존 파일 덮어쓰기
        }

        // 원본 디렉터리의 하위 디렉터리 복사
        foreach (var subdir in Directory.GetDirectories(_source))
        {
            string dirName = Path.GetFileName(subdir);
            string destSubdir = Path.Combine(_target, dirName);
            CopyDirectory(subdir, destSubdir);
        }
    }
}
