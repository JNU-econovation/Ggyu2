﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    public bool swit;
    public GameObject Guide;
    void Start()
    {
        if(swit)
        {
            FadeIn(3);
        }
        else
        {
            FadeOut(3);
        }
    }

    public void FadeIn(float fadeOutTime)
    {
        StartCoroutine(CoFadeIn(fadeOutTime));
    }

    public void FadeOut(float fadeOutTime)
    {
        StartCoroutine(CoFadeOut(fadeOutTime));
    }

    // 나타난다
    IEnumerator CoFadeIn(float fadeOutTime)
    {
        Color col = new Color(0, 0, 0, 0);
        Image sr = this.gameObject.GetComponent<Image>();
        sr.color = col;
        Color tempColor = sr.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;

            yield return null;
        }
        sr.color = tempColor;
    }

    // 사라진다
    IEnumerator CoFadeOut(float fadeOutTime)
    {
        Image sr = this.gameObject.GetComponent<Image>();
        Color tempColor = sr.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        gameObject.SetActive(false);
        sr.color = tempColor;
    }
    public void disable()
    {
        Guide.SetActive(true);
        gameObject.SetActive(false);
    }
}

