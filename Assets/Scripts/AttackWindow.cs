using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackWindow : MonoBehaviour
{
    [SerializeField] TMP_Text attackDescription2;
    public void OnDamageChange(string damage)
    {
        attackDescription2.text = $"damage on the boss, for this {damage} WAXP will be withdrawn from your WAX-wallet. Attack?";
        GameController.instance.ChangeAddingReward(int.Parse(damage));
    }
}
