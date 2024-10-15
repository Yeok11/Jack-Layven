using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PLACE
{
    OFFICE,
    END
}

public class BackGroundManager : MonoBehaviour
{
    #region singleTon
    public static BackGroundManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] internal List<Sprite> sprites;
    [SerializeField] private Sprite office_Morning;
    [SerializeField] private Sprite office_Night;
    [SerializeField] private Image bg;

    public static int bgNum = 0;

    public void BG_Office(bool isMorning)
    {
        bg.sprite = isMorning ? office_Morning : office_Night;
    }

    public void BGChangeToInt(int _num)
    {
        if (_num < 0 || _num >= sprites.Count) return;

        bg.sprite = sprites[_num];
        bgNum = _num;
    }
}
