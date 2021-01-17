using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public GameObject fadePanel;
    public float fadeTime;

    private float fadeCounter;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel.SetActive(true);
        fadeCounter = 0;

        Image fadeImage = fadePanel.GetComponent<Image>();
        var color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeCounter >= fadeTime)
        {
            fadePanel.SetActive(false);
        }
        else
        {
            fadeCounter += Time.deltaTime;
            Image fadeImage = fadePanel.GetComponent<Image>();
            var color = fadeImage.color;
            color.a = 1f - fadeCounter / fadeTime;
            fadeImage.color = color;
        }       
    }
}
