using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    public GameObject Window;
    // Start is called before the first frame update
    public void Close()
    {
        Window.SetActive(false);
    }
}
