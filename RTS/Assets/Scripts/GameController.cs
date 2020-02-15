using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Cell;
    public GameObject Canvas;
    Vector2[,] gameField; //array of all game cells
    int n, m; //Height & width of our game field
    
    void Start()
    {
        Instantiate(Canvas);
        (n, m) = (15, 15); 
        (int N, int M) = ((int)Mathf.Floor((n/2)), (int)Mathf.Floor((m / 2))); //Will be used for changing positions of cells
        gameField = new Vector2[n, m];


        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                gameField[i, j] = new Vector2(-M, N);
                Cell.transform.position = gameField[i, j];
                Instantiate(Cell);
                M--;
            }
            N--;
            M = (int)Mathf.Floor((m / 2));
        }
    }
}
