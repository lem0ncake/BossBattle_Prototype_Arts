using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingWindowScript : MonoBehaviour
{
    [SerializeField] GameObject loadingAnimationGO;
    [SerializeField] GameObject successGO;

    void OnEnable()
    {
        loadingAnimationGO.SetActive(true);
        successGO.SetActive(false);
        StartCoroutine(Timer(Random.Range(2f,5f)));
    }

    IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Success();
    }
    void Success()
    {
        loadingAnimationGO.SetActive(false);
        successGO.SetActive(true);
        
        GameController.instance.Attack();
        gameObject.SetActive(false);
    }
}
