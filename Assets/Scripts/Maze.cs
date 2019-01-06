using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Row
{
    public int[] setnumber = new int[8];
    public bool[] verconn = new bool[8];
    public bool[] horiconn = new bool[7];        
    Row lastrow;
    public int setsequence;


    public Row(Row last,int numberseq)
    {
        lastrow = last;
        setsequence = numberseq;
    }

    public Row()
    {

    }

    public void Init()
    {
        for (int i = 0; i < 8; i++)
        {
            setnumber[i] = i;
            verconn[i] = false;
            

        }
        for (int i = 0; i < 7; i++)
        {
            horiconn[i] = false;
        }
            setsequence = 0;
    }
    public void Setsets()
    {
        for (int i = 0; i < 8; i++)
        {
            if (lastrow.verconn[i])
            { setnumber[i] = lastrow.setnumber[i]; }
            else
            {
                setnumber[i] = setsequence;
                setsequence += 1;
            }
        }
    }

    public void SetHoriwall()
    {
        for (int i = 0; i < 7; i++)
        {
            horiconn[i] = false;
        }
            for (int i = 1; i < 8; i++)
        {
            if (setnumber[i] != setnumber[i - 1])
            {
                horiconn[i-1]=Randombool();
                if (horiconn[i-1])
                {
                    merge(setnumber[i],setnumber[i - 1]);
                }
            }
        }
    }

    public void SetVerwall()
    {
        verconn[0] = true;
        for (int i= 1; i < 8; i++)
        {
            if (setnumber[i] == setnumber[i - 1])
                verconn[i] = false;
            else
                verconn[i] = true;

        }
    }

    //0 1 2 3 4 5 6 7 
    // 0 1 2 3 4 5 6

    int getRangeNum = 0;
    //每次随机产生的随机数，用于与上次进行比较
    int rangeRadomNum = 0;

    bool Randombool()
    {
        do
        {
            rangeRadomNum = UnityEngine.Random.Range(0, 10);
        }
        while (getRangeNum == rangeRadomNum);
        getRangeNum = rangeRadomNum;

       
        Debug.Log(rangeRadomNum);
        if (rangeRadomNum < 5)
            return true;
        else
            return false;
    }

    void merge(int a,int b)
    {
        for (int i = 0; i < 8; i++)
        {
            if (setnumber[i] == a)
                setnumber[i] = b;
        }
    }
}
