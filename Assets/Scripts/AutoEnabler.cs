using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoEnabler : MonoBehaviour
{
    public enum AutoEnableEnum { score, snakeGridTransform, CanPlayerPressDialogNext };
    public AutoEnableEnum autoEnable;

    private void OnEnable()
    {
        switch (autoEnable)
        {
            case AutoEnableEnum.score: { UIManager.instance.ScoreTxt = GetComponent<TextMeshPro>(); break; }
            case AutoEnableEnum.snakeGridTransform: { ArenaManager.instance.GridTransform = transform; break; }
            case AutoEnableEnum.CanPlayerPressDialogNext: { DialogManager.instance.CanPlayerPressDialogNext = false; break; }
        }
    }
}
