﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSScript : MonoBehaviour, IUnit
{
    public float atack { get; set; }

    public float speed { get; set; }

    public float defence { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        atack = 3f;
        defence = 1f;
    }
}
