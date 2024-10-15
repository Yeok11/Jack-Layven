using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool messageStop = false;
    public static bool isStory = true;
    public static GameManager instance;

    [SerializeField] internal Chapter chapter;
    [SerializeField] private Transform chapterParent;
    [SerializeField] private TextManager tm;
    [SerializeField] internal Image messagePanel;

    [HideInInspector] public string path;

    [SerializeField] internal int messCnt = 0;
    public int chapterNum;
    [SerializeField] private GameObject layven;

    [Header("SceneChange")]
    [SerializeField] private RectTransform blackScene_L;
    [SerializeField] private RectTransform blackScene_R;

    [Header("playerPrefab")]
    [SerializeField] private TMP_InputField nameFiled;


    private void Awake()
    {
        #region 싱글톤
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        #endregion

        path = Application.dataPath;
        path += "\\GAME";
        Directory.CreateDirectory(path);
        Application.runInBackground = true;
    }

    public void SetName(string _name)
    {
        PlayerPrefs.SetString("Player", _name);
        Application.Quit();
        Alert.AlertBox("게임을 다시 시작하세요.", "Error", 0);
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("Player") == "")
        {
            blackScene_L.sizeDelta = new Vector2(700, blackScene_L.rect.height);
            blackScene_R.sizeDelta = new Vector2(700, blackScene_R.rect.height);
            nameFiled.gameObject.SetActive(true);
            nameFiled.text = ""; 
        }
        else
        {
            BackGroundManager.instance.BG_Office(true);
            ChangeChapter();
        }
    }

    public void ChangeChapter()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeChapterPri());
    }

    private IEnumerator ChangeChapterPri()
    {
        layven.gameObject.SetActive(false);

        blackScene_L.sizeDelta = new Vector2(0, blackScene_L.rect.height);
        blackScene_R.sizeDelta = new Vector2(0, blackScene_R.rect.height);

        if (!messagePanel.gameObject.activeSelf)
            messagePanel.gameObject.SetActive(true);

        int xSize = 0;
        
        if (chapterNum != 0)
        {
            while (xSize < 700)
            {
                yield return new WaitForSeconds(0.008f);
                xSize += 8;
                blackScene_L.sizeDelta = new Vector2(xSize, blackScene_L.rect.height);
                blackScene_R.sizeDelta = new Vector2(xSize, blackScene_R.rect.height);
            }
        }

        blackScene_L.sizeDelta = new Vector2(700, blackScene_L.rect.height);
        blackScene_R.sizeDelta = new Vector2(700, blackScene_R.rect.height);
        xSize = 700;

        isStory = true;
        
        ++chapterNum;
        if (PlayerPrefs.GetString("Clear") == "true")
            chapter = chapterParent.Find("Chapter_Behind").GetComponent<Chapter>();
        else
            chapter = chapterParent.GetChild(chapterNum - 1).GetComponent<Chapter>();

        messCnt = 0;

        yield return new WaitForSeconds(2.7f);
        bool result = chapter.Init(path);
        ActText();

        while (xSize > 0)
        {
            yield return new WaitForSeconds(0.008f);
            xSize -= 8;
            blackScene_L.sizeDelta = new Vector2(xSize, blackScene_L.rect.height);
            blackScene_R.sizeDelta = new Vector2(xSize, blackScene_R.rect.height);
        }

        messageStop = result;

        StartCoroutine(Delay(0.8f));
    }


    public void CharacterText(Mes _mes)
    {
        if (!messagePanel.gameObject.activeSelf)
            messagePanel.gameObject.SetActive(true);

        tm.UpdateMessage(_mes);

        if (_mes.isNextStage)
        {
            messageStop = true;
            ChangeChapter();
        };
    }

    public void ActText()
    {
        tm.UpdateMessage(chapter.chapterContexts.messages[messCnt]);

        if (chapter.chapterContexts.messages[messCnt].isQuest)
        {
            //StopCoroutine(chapter.EventWait(messCnt));
            StartCoroutine(chapter.EventWait(messCnt));
        }

        if (chapter.chapterContexts.messages[messCnt].isNextStage)
        {
            ChangeChapter();
        }
        else
        {
            ++messCnt;
        }
    }

    private bool updateDelay = false;

    private IEnumerator Delay(float _sec)
    {
        updateDelay = true;
        yield return new WaitForSeconds(_sec);
        updateDelay = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && messageStop == false && isStory && !updateDelay)
        {
            messageStop = true;
            StartCoroutine(Delay(0.3f));
            ActText();
        }
    }
}
