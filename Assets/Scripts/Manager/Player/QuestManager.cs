using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Compass compass;

    [SerializeField] private QuestObj questCurrent;  public QuestObj QuestCurrent
    { 
        get { return questCurrent; } 
        set 
        { 
            questCurrent = value;
            compass.townNext = TownManager.instance.TownFind(value.townNext);
            if (UIManager.instance.QuestTxtTitle != null) UIManager.instance.QuestTxtTitle.text = questCurrent.questName;
            if (UIManager.instance.QuestTxtDescription != null) UIManager.instance.QuestTxtDescription.text = questCurrent.description + "<br><br>" + questCurrent.descriptionSub;
        }
    }

    #region References
    public static QuestManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void QuestCheckItem()
    {
        if (questCurrent.itemNeededList.Count == 0) return;
        foreach (ItemObj itm in ItemManager.instance.ItemListGet)
        {
            if (itm == questCurrent.itemNeededList[0]) { QuestNext(); return; }
        }
    }
    public void QuestCheckEvent()
    {
        if (questCurrent.eventNeededList.Count == 0) return;
        if (EventManager.instance.EventCurrent == questCurrent.eventNeededList[0]) { QuestNext(); return; }
    }

    private void QuestNext()
    {
        if (questCurrent.nextQuestList.Count == 0) return;
        QuestCurrent = questCurrent.nextQuestList[0];
    }
}
