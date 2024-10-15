using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zack_Entrance : Character
{
    [SerializeField] private Image textPanel;
    [SerializeField] private Mes question;
    [SerializeField] private Mes no;
    [SerializeField] private Mes yes;
    [SerializeField] private TextManager txtM;

    private bool quest = false;

    protected override void Tell()
    {
        textPanel.gameObject.SetActive(true);
        GameManager.instance.CharacterText(question);
        quest = true;
    }

    protected override void Update()
    {
        if (!quest)
            base.Update();
        else
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                GameManager.instance.CharacterText(yes);
                quest = false;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                GameManager.instance.CharacterText(no);
                quest = false;
            }
        }
    }
}
