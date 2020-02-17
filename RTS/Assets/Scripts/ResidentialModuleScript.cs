using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialModuleScript : MonoBehaviour, IBaseGO
{
    public int peopleNum = 200;
    public int peopleLimit = 1000;
    public int peoplePerGS = 100;
    
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }
    

    public IEnumerator GS()
    {
        while (true)
        {
            if (peopleNum + peoplePerGS < peopleLimit)
                peopleNum += peoplePerGS;
            else
                peopleNum = peopleLimit;

            
            print(peopleNum);
            yield return new WaitForSeconds(GSDuration);
        }
    }

    public IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(GSDuration);
        Level++;
        peopleLimit += 200;
        peoplePerGS = Mathf.RoundToInt(peoplePerGS * 1.05f);
    }

    // Start is called before the first frame update
    void Start()
    {
        GSDuration = 4f;
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (CoroutineStarted == false && Time.realtimeSinceStartup >= 4f)
        {
            StartCoroutine(GS());// making game step
            CoroutineStarted = true;
        }

    }
}
