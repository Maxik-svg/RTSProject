using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Cell;
    public GameObject Canvas;
    //public float GSDuration = 4f; //--------------------------howToUSE?
    PlayerBaseScript playerBaseScript;
    Vector2[,] gameField; //array of all game cells
    int n, m; //Height & width of our game field

    void ChangeGSDurationLong()
    {
        playerBaseScript.GSDuration = 8f;
    }

    void ChangeGSDurationShort()
    {
        playerBaseScript.GSDuration = 2f;
    }

    void ChangeGSDurationStandart()
    {
        playerBaseScript.GSDuration = 4f;
    }

    void Start()
    {
        Instantiate(Canvas);
        playerBaseScript = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<PlayerBaseScript>();
        playerBaseScript.GSDuration = 4f;
        (n, m) = (15, 15);
        CreateGameField(n, m);
    }

    void Update()
    {
        
    }

    void CreateGameField(int n, int m)
    {
        (int N, int M) = ((int)Mathf.Floor(n / 2), (int)Mathf.Floor(m / 2)); //Will be used for changing positions of cells
        gameField = new Vector2[n, m];

        for (int i = 0; i < n; i++) // Creating game field
        {
            for (int j = 0; j < m; j++)
            {
                gameField[i, j] = new Vector2(-M, N);
                Cell.transform.position = gameField[i, j];
                Instantiate(Cell);
                M--;
            }
            N--;
            M = (int)Mathf.Floor(m / 2);
        }
    }

    IEnumerator GS()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            //event?
            yield return new WaitForSeconds(4f);
        }
    }
}
