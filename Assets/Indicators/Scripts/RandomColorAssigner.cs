﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomColorAssigner : MonoBehaviour
{
    public bool ChangeTargetColor = true;

    // Use this for initialization
	void Start ()
    {
        //  Get a new random color
        Color newColor = new Color(UnityEngine.Random.Range(0f, 1f), Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));

        //  Change color of the target gameobject.
        if (ChangeTargetColor)
            GetComponent<Renderer>().material.color = newColor;

        StartCoroutine(ChangeColor(newColor));
    }

    //  Using ienumerator because the indicator panel may not have been created yet thus we need to keep checking. Will stop when color is finally changed.
    IEnumerator ChangeColor(Color newColor)
    {
        //  Change color of all the indicator panel items
        IndicatorPanel IPanel = GetComponent<IndicatorTarget>().IndicatorPanel;

        while (IPanel == null)
        {
            IPanel = GetComponent<IndicatorTarget>().IndicatorPanel;
            yield return null;
        }

        Image[] images = IPanel.GetComponentsInChildren<Image>(true);
        for (int i = 0; i < images.Length; i++)
            images[i].color = newColor;

        Text[] texts = IPanel.GetComponentsInChildren<Text>(true);
        for (int i = 0; i < texts.Length; i++)
            texts[i].color = newColor;
    }
}