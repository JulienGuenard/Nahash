using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoEnabler : MonoBehaviour
{
    public enum AutoEnableEnum { score, snakeGridTransform, CanPlayerPressDialogNext, time, life };
    public AutoEnableEnum autoEnable;

    private void OnEnable()
    {
        switch (autoEnable)
        {
            case AutoEnableEnum.score: { UIManager.instance.ScoreTxt = GetComponent<TextMeshPro>(); break; }
            case AutoEnableEnum.time: { UIManager.instance.TimeTxt = GetComponent<TextMeshPro>(); break; }
            case AutoEnableEnum.life: { UIManager.instance.LifeTxt = GetComponent<TextMeshPro>(); break; }
            case AutoEnableEnum.snakeGridTransform: { ArenaManager.instance.GridTransform = transform; break; }
            case AutoEnableEnum.CanPlayerPressDialogNext: { DialogManager.instance.CanPlayerPressDialogNext = false; break; }
        }
    }
}
