using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Computer_BedRoom : obj
{
    [SerializeField] private Image passwordUI;


    public void EndEvent()
    {
        TMP_InputField tmp = passwordUI.transform.GetChild(0).GetComponent<TMP_InputField>();

        Debug.Log(tmp.text);

        string answer = tmp.text;
        Debug.LogError(answer);
        Debug.LogError(int.Parse(answer));

        if(int.Parse(answer) == 938037)
        {
            // 입구 cctv 기록
            if (isUse)
                File.WriteAllText(GameManager.instance.path + "/사건 장소/집/피해자의방/입구 cctv기록.txt", 
                    "입구 cctv 기록\n\n" +
                    "15:22 - Rachel 입장\n" +
                    "17:31 - Leo, 피해자 입장\n" +
                    "19:14 - Leo 퇴장\n" +
                    "19:25 - Rachel 퇴장\n" +
                    "19:38 - Vender 입장\n");
            isUse = true;
            Close();
        }
        else
        {
            tmp.text = "Fail Password";
        }
    }

    public void Close()
    {
        passwordUI.gameObject.SetActive(false);
    }

    public override void ClickEvent()
    {
        passwordUI.gameObject.SetActive(true);
    }
}
