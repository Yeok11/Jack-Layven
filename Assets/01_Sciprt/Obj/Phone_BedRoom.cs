using System.IO;
using UnityEngine;

public class Phone_BedRoom : obj
{
    public override void ClickEvent()
    {
        if (isUse) return;
        isUse = true;
        string path = GameManager.instance.path + "/사건 장소/집/피해자의방/휴대전화";
        Directory.CreateDirectory(path);

        File.WriteAllText(path + "/Rachel과의 메신저 내용.txt",
            "사건 당일 문자 내역\n\n" +
            "Me: ㅑ\n" +
            "Me: ㅑ\n" +
            "Me: ㅑ\n" +
            "Me: 씹음?\n" +
            "Rachel: 뭐\n" +
            "Me: 야 생일 언제냐\n" +
            "Rachel: 왜?\n" +
            "Me: 닥치고 말해봐\n" +
            "Rachel: 0307\n");

        File.WriteAllText(path + "/Leo와의 메신저 내용.txt", 
            "사건 당일 문자 내역\n\n" +
            "Leo: ㅑ\n" +
            "Leo: ㅁㅎ\n" +
            "Me: 잠\n" +
            "Leo: 술 ㄱ\n" +
            "Me: 그 일은 잘 돼감?\n" +
            "Leo: 그게 좀 꼬임\n" +
            "Leo: 오면 자세히 말해줌\n" +
            "Me: ㅇㅇ");
        
        File.WriteAllText(path + "/Vender와의 메신저 내용.txt", "당일 문자 내역이 없습니다.");
        
        File.WriteAllText(path + "/Shy와의 메신저 내용.txt", "Shy: 자고 싶다.");
    }
}
