using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseGO //interface for all game objects attached to base
{
    float GSDuration { get; set; }
    int Level { get; set; }
    bool CoroutineStarted { get; set; }
    void LevelUp();
    IEnumerator GS();//coroutine
}
