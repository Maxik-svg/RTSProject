using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit // is not used, delete???
{
    float atack { get; set; }
    float speed { get; set; } //cells per GS
    float defense { get; set; }
    //char type { get; } // A, S, D
}
