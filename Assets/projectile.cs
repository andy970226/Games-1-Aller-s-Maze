using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Destroy(gameObject,4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("InnerWall"))
        {
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<HP>().Health -= 1;
            Debug.Log("InnerWall");
            GameObject.Destroy(gameObject, 0.0f);

        }
    }
}
