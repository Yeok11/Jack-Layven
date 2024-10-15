using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/MesSO")]
public class MessageBoxSO : ScriptableObject
{
    public List<Mes> messages; 
}


[System.Serializable]
public class Mes
{
    public string readerName = "";
    [TextArea()] public string message = "";
    public bool isQuest = false;
    public bool isNextStage = false;
    public bool closeMes = false;
}