﻿using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Light>().intensity -= 0.01f;
	}
}