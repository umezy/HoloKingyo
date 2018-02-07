using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
//using VRStandardAssets.Utils;

public class ColorChanger : MonoBehaviour, IFocusable
{
    IEnumerator routine;

    public void OnFocusEnter()
    {
        //GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        Debug.Log("OnFocusEnter");
        routine = ChangeColor();
        StartCoroutine(routine);

    }

    public void OnFocusExit()
    {
        //GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        Debug.Log("OnFocusExit");
        StopCoroutine(routine);

    }

    //IEnumerator ChangeColor(Color toColor, float duration)
    IEnumerator ChangeColor()
    {
        //Color fromColor = Camera.main.camera.backgroundColor;
        Color toColor = Color.red;
        float duration = 2.5f;

        Color fromColor = GetComponent<Renderer>().material.color;
        float startTime = Time.time;
        float endTime = Time.time + duration;
        float marginR = toColor.r - fromColor.r;
        float marginG = toColor.g - fromColor.g;
        float marginB = toColor.b - fromColor.b;

        while (Time.time < endTime)
        {
            fromColor.r = fromColor.r + (Time.deltaTime / duration) * marginR;
            fromColor.g = fromColor.g + (Time.deltaTime / duration) * marginG;
            fromColor.b = fromColor.b + (Time.deltaTime / duration) * marginB;
            GetComponent<Renderer>().material.color = fromColor;
            yield return 0;
        }

        GetComponent<Renderer>().material.color = toColor;
        yield break;
    }

    //IEnumerator ChangeCameraColor()
    //{
    //    //while (true)
    //    //{
    //    //    yield return StartCoroutine(ChangeColor(Color.red, 3f));
    //    //    yield return StartCoroutine(ChangeColor(Color.blue, 3f));
    //    //    //yield return StartCoroutine(ChangeColor(Color.blue, 1f));
    //    //}
    //    yield return StartCoroutine(ChangeColor(Color.red, 20f));
    //    yield break;
    //}

}
