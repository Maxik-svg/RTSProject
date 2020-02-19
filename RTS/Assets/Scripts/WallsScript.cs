using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour, IBaseGO //add atack & defense of units
{
    BarracksScript barracks;
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }

    public IEnumerator GS()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(GSDuration);
        Level++;
        barracks.WallsDefenseBonus += 0.05f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        barracks = this.GetComponent<BarracksScript>();
        barracks.WallsDefenseBonus += 0.05f; //basic wall defense bonus
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
