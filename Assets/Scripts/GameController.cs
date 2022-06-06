using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    //Unity objects
    [SerializeField] TMP_Text remainingTimeTMP_Text;
    [SerializeField] TMP_Text rewardTimeTMP_Text;
    [SerializeField] TMP_Text addRewardTimeTMP_Text;
    [SerializeField] Transform logsContent;
    [SerializeField] AttackResultWindow attackResultWindow;
    [SerializeField] FinishResultWindow finishResultWindow;

    //Prefabs
    [SerializeField] GameObject logStringPrefab;

    //Constants
    const int TIME_TO_ATTACK = 30;
    int TIME_TO_ATTACK_DEBUG = TIME_TO_ATTACK;

    //Service vars
    int reward = 1000;
    int remainingTime = TIME_TO_ATTACK;
    int addingReward = 1;
    string lastUser = "";


    private void Start()
    {
        instance = this;
        StartCoroutine(Timer());
    }
    public void StartNewGame()
    {
        reward = 1000;
        remainingTime = TIME_TO_ATTACK_DEBUG;
        addingReward = 1;
        lastUser = "";

        remainingTimeTMP_Text.text = (remainingTime / 60).ToString("00") + ":" + (remainingTime % 60).ToString("00");
        rewardTimeTMP_Text.text = reward.ToString();

        foreach (Transform t in logsContent)
            Destroy(t.gameObject);

        StartCoroutine(Timer());
    }
    public void ChangeAddingReward(int ar)
    {
        addingReward = ar;
    }
    public void Attack()
    {
        remainingTime = TIME_TO_ATTACK_DEBUG;
        remainingTimeTMP_Text.text = (remainingTime / 60).ToString("00") + ":" + (remainingTime % 60).ToString("00");

        reward += addingReward;
        rewardTimeTMP_Text.text = reward.ToString();
        addRewardTimeTMP_Text.text = "+" + addingReward;
        addRewardTimeTMP_Text.GetComponent<Animation>().Play();

        string time = DateTime.Now.ToLongTimeString();
        string user = Randomizer.GenerateName();
        lastUser = user;
        AddLog(user, time, addingReward);
        attackResultWindow.Show(user, time, addingReward);
    }
    public void ChangeTimeToAttackDebug(string time)
    {
        if (time.Length == 0)
            return;
        TIME_TO_ATTACK_DEBUG = int.Parse(time);
        remainingTime = TIME_TO_ATTACK_DEBUG;
    }
    void AddLog(string user, string time, int damage)
    {
        Instantiate(logStringPrefab, logsContent).GetComponent<LogString>().SetLog(user, time, damage.ToString()).transform.SetAsFirstSibling();
    }
    IEnumerator Timer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
            remainingTimeTMP_Text.text = (remainingTime / 60).ToString("00") + ":" + (remainingTime % 60).ToString("00");
        }
        finishResultWindow.Show(lastUser, reward);
    }
}
public class Randomizer
{
    static List<string> names = new List<string>() { "Xterranc", "Yolan", "Xeno", "Quitoma", "Azaran", "Neksan", "Darl", "Kalupit", "Zekielle", "Tali", "Dmitry", "Sergey", "Pavel" };
    public static string GenerateName()
    {
        return names[UnityEngine.Random.Range(0, names.Count)] + ".wax";
    }
}
