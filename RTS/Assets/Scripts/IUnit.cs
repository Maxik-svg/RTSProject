using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    float atack { get; set; }
    float speed { get; set; } //cells per GS
    float defence { get; set; }
    //char type { get; } // A, S, D
}
