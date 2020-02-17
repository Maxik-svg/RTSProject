using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour, IBaseGO //add atack & defence of units
{
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }

    public IEnumerator GS()
    {
        throw new System.NotImplementedException();
    }

    public void LevelUp()
    {
        Level++;
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
