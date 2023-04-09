using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] Renderers;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {

        for(float t = 0; t <1; t+=Time.deltaTime)
        {
            SetColor(new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));

            yield return null;
        }
        SetColor(Color.clear);
    }

    private void SetColor(Color newColor)
    {
        for (int i = 0; i < Renderers.Length; i++)
        {
            for (int m = 0; m < Renderers[i].materials.Length; m++)
            {
                Renderers[i].materials[m].SetColor("_EmissionColor", newColor);
            }
        }
    }
}
