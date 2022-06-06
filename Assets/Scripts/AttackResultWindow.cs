using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackResultWindow : MonoBehaviour
{
    [SerializeField] TMP_Text attackResultText;
    public void Show(string name, string time, int damage)
    {
        attackResultText.text = $"WOW! At {time} you ({name}) caused {damage} damage to THE BOSS!";
        gameObject.SetActive(true);
    }
}
