﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject rocketPrefab;
    public AudioSource audio;
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            audio.Play();
            foreach (Collider c in GetComponentsInChildren<Collider>())
            {
                c.isTrigger = true;
             }
            GameObject g = (GameObject)Instantiate(rocketPrefab,
                                                   transform.position,
                                                   transform.parent.rotation);
            float force = g.GetComponent<Rocket>().speed;
            g.GetComponent<Rigidbody>().AddForce(g.transform.forward * force);
        }
    }
}