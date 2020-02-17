using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseGO
{
    float GSDuration { get; set; }
    int Level { get; set; }
    bool CoroutineStarted { get; set; }
    void LevelUp();
    IEnumerator GS();//coroutine
}
