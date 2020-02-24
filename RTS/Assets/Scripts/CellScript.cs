using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    //public GameObject Window;
    //GameObject Canvas;
    public bool IsBaseCell; // used to chack if cell is valkable (for squads)
    public Vector2 Position;

    /*private void OnMouseDown()
    {
        if (true) //Think of conditions
        {
            GameObject.FindGameObjectWithTag("PlayerSquad").
                GetComponent<SquadScript>().
                TargetPos = this.Position;
        }
    }*/


    // Start is called before the first frame update
    void Start()
    {
        //Canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
