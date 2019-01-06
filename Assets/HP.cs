using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {
   public  int Health;
	// Use this for initialization
	void Start () {
        Health = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Health == 0)
        { gameObject.SetActive(false); }
	}
}
