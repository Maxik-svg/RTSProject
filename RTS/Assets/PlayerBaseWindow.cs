using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseWindow : MonoBehaviour
{
    public static bool PlayerBaseMenuIsOpen = false;
    public GameObject PlayerBaseUI;
    public void ClosePlayerBaseWindow()
    {
        PlayerBaseUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
