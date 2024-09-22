using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public TextMeshPro lifeTxt;
    public TextMeshPro questTxtTitle;
    public TextMeshPro questTxtDescription;

    #region References
    public static HeroManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void HeroEnable()
    {
        UIManager.instance.LifeTxt = lifeTxt;
        UIManager.instance.QuestTxtTitle = questTxtTitle;
        UIManager.instance.QuestTxtDescription = questTxtDescription;
    }
    public void HeroDisable()
    {

    }
}
