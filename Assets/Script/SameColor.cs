using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameColor : MonoBehaviour {

    GameObject body;
    Color bodyColor;
	// Use this for initialization
	void Start () {
        body = GameObject.Find("Body");
	}
	
	// Update is called once per frame
	void Update () {
        bodyColor = body.GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = bodyColor;
	}
}
