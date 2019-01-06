using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendMap : MonoBehaviour {
    public GameObject innerwall;
    public GameObject innerwallh;
    public GameObject pick;
    // Use this for initialization
    public GameObject row;
     Row Last;
    Row Next;
    int numbersequence;

    void Awake()
    {
        Last = new Row();
        numbersequence = 0;
        Last.Init();
        Next = new Row(Last, numbersequence);     
        Next.Init();
        completewall();
    }
    void Start()
    {
        
        //row = new GameObject();
        
    }

    void OnTriggerEnter(Collider e)
    {

        if (e.CompareTag("Player"))
        {
            
            //  bg = GameObject.FindGameObjectWithTag("bg1");
            GameObject AnotherRow = Instantiate(row, new Vector3(row.transform.position.x-10,row.transform.position.y, row.transform.position.z), Quaternion.identity) as GameObject;
            transform.position = new Vector3(transform.position.x-10, transform.position.y, transform.position.z);
            row = AnotherRow;
            completewall();
            
        }          
    }

    void completewall()
    {

        Next.Setsets();
        Next.SetHoriwall();
        Next.SetVerwall();
        Last = Next;
        //Debug.Log(Next.setsequence);

        for (int i = 0; i < 7; i++)
        {
            if(Next.horiconn[i]==false)
            {
            Vector3 Offset = new Vector3(-0.149f, 1.27f, 33f-11*i);
            GameObject wall = Instantiate(innerwall, row.transform.position + Offset, Quaternion.identity) as GameObject;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            if (Next.verconn[i] == false)
            {
                Vector3 Offset = new Vector3(-5.18f, 1.27f, 38.7f - 11 * i);
                GameObject wall = Instantiate(innerwallh, row.transform.position + Offset, innerwallh.transform.rotation) as GameObject;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            Vector3 Offset = new Vector3(0.3f, 1.27f, 39.0f - 11 * i);
            GameObject wall = Instantiate(pick, row.transform.position + Offset, pick.transform.rotation) as GameObject;
        }


    }

}  

