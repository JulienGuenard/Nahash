using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TextMeshPro scoreTxt; public TextMeshPro ScoreTxt
    {
        get { return scoreTxt; }
        set 
        { 
            scoreTxt = value;
            scoreTxt.text = "Score : " + ScoreManager.instance.Score.ToString();
        }
    } 
    TextMeshPro timeTxt; public TextMeshPro TimeTxt
    {
        get { return timeTxt; }
        set 
        { 
            timeTxt = value;
            timeTxt.text = "Time : " + TimerManager.instance.TimerTimeLeft.ToString();
        }
    } 
    TextMeshPro lifeTxt; public TextMeshPro LifeTxt
    {
        get { return lifeTxt; }
        set 
        { 
            lifeTxt = value;
            PlayerManager.instance.LifeCurrent += 0;
        }
    }
    TextMeshPro questTxtTitle; public TextMeshPro QuestTxtTitle
    {
        get { return questTxtTitle; }
        set
        {
            questTxtTitle = value;
            questTxtTitle.text = QuestManager.instance.QuestCurrent.questName;
        }
    }
    TextMeshPro questTxtDescription; public TextMeshPro QuestTxtDescription
    {
        get { return questTxtDescription; }
        set
        {
            questTxtDescription = value;
            questTxtDescription.text = QuestManager.instance.QuestCurrent.description;
        }
    }


    TextMeshPro dialogTxt; public TextMeshPro DialogTxt
    {
        get { return dialogTxt; }
        set
        {
            dialogTxt = value;
            dialogTxt.text = " ";
        }
    } 

    [SerializeField] GameObject enterTownBtn; public GameObject EnterTownBtn
    {
        get { return enterTownBtn; }
        set { enterTownBtn = value; }
    }
    public List<ItemData> inventorySlotList;

    #region References
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
}
