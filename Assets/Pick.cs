using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            other.gameObject.SetActive(false);
            GameObject.Find("FirstPersonCharacter").GetComponent<Shoot>().Ammo+=1;
            GameObject.Find("FirstPersonCharacter").SendMessage("SetCountText");

        }
    }
}
