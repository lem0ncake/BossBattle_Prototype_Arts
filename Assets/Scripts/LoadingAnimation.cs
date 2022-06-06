using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField] TMP_Text loadingAnimationTMP_Text;
    void OnEnable()
    {
        StartCoroutine(Animation());
    }
    private void OnDisable()
    {
        StopCoroutine(Animation());
    }
    IEnumerator Animation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);

            if (loadingAnimationTMP_Text.text.Length < 3)
                loadingAnimationTMP_Text.text += '.';
            else
                loadingAnimationTMP_Text.text = "";
        }
    }
}
