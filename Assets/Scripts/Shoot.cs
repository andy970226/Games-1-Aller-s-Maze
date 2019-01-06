using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public float range;
    public  float ProjectileSpeed = 20;
    public GameObject ejector;
    public Rigidbody projectile;

    public int Ammo;
    public Text countText;
    public Text winText;
    // Use this for initialization
    void Start () {
        Ammo = 100;
        SetCountText();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F)) { ShootProjectiles();
            Ammo -= 1;
            SetCountText();
        }


    }

    void ShootProjectiles() {
        Rigidbody clone = Instantiate(projectile,ejector.transform.position,ejector .transform .rotation) as Rigidbody;
        //Vector3 fwd = transform.TransformDirection(Vector3.forward) * range;

        clone.velocity = ProjectileSpeed * transform.forward;
        //RaycastHit hit;
        //Debug.DrawRay(transform.position, fwd, Color.magenta);

        //if (Physics.Raycast(transform.position, fwd, out hit, range))
        //{ Debug.Log("shoot"); }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            other.gameObject.SetActive(false);
            Ammo = Ammo + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + Ammo.ToString();
        
    }
}
