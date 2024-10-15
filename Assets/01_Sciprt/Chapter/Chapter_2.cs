using System.Collections;
using System.IO;
using UnityEngine;

public enum HOUSE
{
    입구 = 0,
    거실,
    화장실,
    피해자의방,
    동생방,
    부엌,
    복도,
    바깥,
    END
}

public class Chapter_2 : Chapter
{
    private string playerPath = "";
    private string playerFile = "/주인공.pc";
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
            if(File.Exists(path + "/집/" + (HOUSE.입구 + i) + playerFile))
            {
                playerPath = path + "/집/" + (HOUSE.입구 + i) + playerFile;
                playerPos = HOUSE.입구 + i;
                break;
            }
        }
        
        if (File.Exists(path + "/집/" + playerFile))
        {
            playerPath = path + "/집/" + playerFile;
            playerPos = HOUSE.바깥;
        }
    }

    public override bool Init(string _path)
    {
        deletePath = _path;
        path = _path + "/사건 장소";
        GameManager.messageStop = true;

        Directory.CreateDirectory(_path + "/수집품");
        Directory.CreateDirectory(_path + "/용의자 목록");
        File.WriteAllText(_path + "/용의자 목록/Leo.txt", "이름 : Leo\n나이: 22\n성별: 남\n직업: 식당 서빙 알바\n피해자와의 관계: 고등학교 친구\n" +
            "\n기록\n사건이 일어난 날 피해자랑 술을 마신 후 2차로 피해자의 집에 놀기 위해 방문했다 진술.\n" +
            "\n\n특이사항\n없음");

        File.WriteAllText(_path + "/용의자 목록/Rachel.txt", "이름 : Rachel\n나이: 19\n성별: 여\n직업: 고등학생\n피해자와의 관계: 여동생\n" +
            "\n기록\n사건이 일어난 날 계속 방에 있다가 친구를 만나러 갔다고 진술.\n" +
            "용의자가 집을 나설 당시에는 거실에 불이 켜진 것은 발견했지만 확인은 하지 않았다고 함." +
            "\n\n특이사항\nVender와 교제 중임. 정작 피해자는 좋아하지 않음.");

        File.WriteAllText(_path + "/용의자 목록/Vender.txt", "이름 : Vender\n나이: 20\n성별: 남\n직업: 피자 배달원\n피해자와의 관계: 고등학교 후배\n" +
            "\n기록\n사건이 일어난 날 피자 배달을 갔다가 벨을 눌러도 반응이 없어서 거실 창문을 보자 쓰러져 있는 피해자를 보고 신고.\n" +
            "\n\n특이사항\nRachel과 교제 중임. 정작 피해자는 좋아하지 않음.");

        File.WriteAllText(_path + "/용의자 목록/Salin.txt", "이름 : Salin\n나이: 27\n성별: 남\n직업: 좀도둑\n피해자와의 관계: 없음\n" +
            "\n기록\n사건이 일어난 날 피해자의 집을 털고 있었음.\n" +
            "본인은 피해자의 방만 털고 나왔을 뿐 살인과는 관계 없다고 주장" +
            "\n\n특이사항\n절도, 무단 침입 등의 전과 보유.");

        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path + "/집");
            for (int i = 0; i < (int)HOUSE.END - 1; i++)
            {
                Directory.CreateDirectory(path + "/집/" + (HOUSE.입구 + i));
            }

            playerPath = path + "/집/입구" + playerFile;
            File.Create(playerPath).Close();
        }

        Debug.Log(playerPath);
        Debug.Log("생성 성공");

        UpdatePos();

        for (int i = 0; i < bgUI.childCount; i++)
        {
            bgUI.GetChild(i).gameObject.SetActive(false);
        }

        return false;
    }
}
