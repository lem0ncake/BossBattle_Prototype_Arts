using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogString : MonoBehaviour
{
    [SerializeField] TMP_Text userTMP_Text;
    [SerializeField] TMP_Text timeTMP_Text;
    [SerializeField] TMP_Text damageTMP_Text;

    public LogString SetLog(string userText, string timeText, string damageText)
    {
        userTMP_Text.text = userText;
        timeTMP_Text.text = timeText;
        damageTMP_Text.text = damageText;
        return this;
    }
}
