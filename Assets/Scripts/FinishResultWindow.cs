using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishResultWindow : MonoBehaviour
{
    [SerializeField] TMP_Text finishResultText;
    public void Show(string name, int reward)
    {
        finishResultText.text = $"In this battle with the boss, {name} won and earned {reward} WAXP";
        gameObject.SetActive(true);
    }
}
