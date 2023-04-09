using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScrin : MonoBehaviour
{
    public Image DamageImege;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect()
    {
        DamageImege.enabled= true;

        for(float t  = 1; t > 0f; t-=Time.deltaTime)
        {
            DamageImege.color = new Color(1, 0 , 0,   t);
            yield return null;
        }

        DamageImege.enabled = false;
    }
}
