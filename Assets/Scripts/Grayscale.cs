using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grayscale : MonoBehaviour
{ 

    private SpriteRenderer spriteRenderer;

    private float aduration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartGrayscaleRoutine();
    }

    public void StartGrayscaleRoutine()
    {
        StartCoroutine(Grayscaleroutine(aduration, true));
    }

    // Update is called once per frame
    private IEnumerator Grayscaleroutine(float duration, bool isGrayscale)
    {
        float time = 0;

        while(duration>time)
        {
            float durationframe = Time.deltaTime;
            float ratio = time / duration;
            float GrayAmount = ratio;
            SetGrayscale(GrayAmount);
            time += durationframe;
            yield return null;
        }
        SetGrayscale(1);
    }

    public void SetGrayscale(float amount=1)
    {
        spriteRenderer.material.SetFloat("_GrayscaleAmount", amount);
    }
}
