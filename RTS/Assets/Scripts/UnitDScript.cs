using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDScript : MonoBehaviour, IUnit
{
    public float atack { get; set; }

    public float speed { get; set; }

    public float defence { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        atack = 2f;
        defence = 4f;
    }
}
