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

        string path = GameManager.instance.path + "/사건 장소/집/거실/";
        File.WriteAllText(path + "피가 튀긴 신문.txt", "오늘의 NEWS\n\t\t\t\t0■월 ■7■\n" +
            "금일 00시 16분 경 가해자 신■■가 온라인 메신■를 이■해 버그 프로그■을 유포하였습니다. 이에 대해 경찰측은...");
        File.WriteAllText(path + "피가 튀긴 오래 된 신문.txt", "■늘의 NEWS\n\t\t\t\t12월25일\n\n" +
            "■복으로 가득한 크리스마스, ■년만에 맞이한 화이트 크리스■■로 도심에는 사람들의 발■이 끊이질 않고 그에 따■ 사건사고 역시 연달...\n" +
            "도심 한가운데에서 ■■이 옷을 벗는■ 하면, 주변 상가에 피해를 입혀 현재...");
    }
}
