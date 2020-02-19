using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillPlayerBaseGrid : MonoBehaviour
{
    public GameObject prefab;
    public int numToCreate;

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    void Populate()
    {
        for (int i = 0; i < numToCreate; i++)
        {
            GameObject newObj = Instantiate(prefab, transform);
            //newObj.Ge
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
