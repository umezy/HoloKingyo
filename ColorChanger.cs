using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using VRStandardAssets.Utils;

public class ColorChanger : MonoBehaviour, IFocusable
{

    public void OnFocusEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        Debug.Log("OnFocusEnter");
    }

    public void OnFocusExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        Debug.Log("OnFocusExit");
    }
}
