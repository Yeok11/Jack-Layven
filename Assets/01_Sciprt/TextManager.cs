using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;


    public void UpdateMessage(Mes _mes)
    {
        StopAllCoroutines();
        _mes.message =  _mes.message.Replace("You", PlayerPrefs.GetString("Player"));
        _mes.readerName = _mes.readerName.Replace("You", PlayerPrefs.GetString("Player"));

        nameText.text = _mes.readerName;
        StartCoroutine(OutputMes(_mes));
    }

    private IEnumerator OutputMes(Mes _mes)
    {
        if(_mes.closeMes)
            GameManager.messageStop = true;

        string mes = "";
        messageText.text = mes;
        yield return new WaitForSeconds(0.7f);

        for (int i = 0; i < _mes.message.Length; i++)
        {
            mes += _mes.message[i];
            yield return new WaitForSeconds(0.05f);
            messageText.text = mes;
        }

        yield return new WaitForSeconds(0.2f);
        if (_mes.closeMes)
        {
            messageText.transform.parent.gameObject.SetActive(false);
            if(GameManager.instance.chapterNum == 2)
            {
                GameManager.instance.chapter.GetComponent<Chapter_2>().UpdatePos();
                GameManager.isStory = false;
                GameManager.messageStop = false;
            }
            
            if(GameManager.instance.chapter.gameObject.name.Contains("Behind"))
            {
                Application.Quit();
            }
        }

        if(!_mes.isQuest)
            GameManager.messageStop = false;
    }
}
