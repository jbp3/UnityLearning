﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform target;
    public float distance = 15;

    void Start()
    {

    }

    void Update()
    {
        if (target)
        {
            Vector3 pos = target.position;
            pos -= Vector3.forward * distance;
            transform.position = pos;
            transform.LookAt(target);
        }
    }


}
