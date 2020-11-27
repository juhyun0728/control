﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    StageManager stgMng;
    // Start is called before the first frame update
    void Start()
    {
        stgMng = StageManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Finish")
        {
            stgMng.isClear = true;
        }
    }
}