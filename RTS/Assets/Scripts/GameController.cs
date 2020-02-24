using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;



public class GameController : MonoBehaviour
{
    public GameObject PlayerBase;
    public GameObject EnemyBase;
    public GameObject Cell;
    public GameObject Canvas; // Canvas for adding UI on go
    public static UnityEvent NoResourcesEvent = new UnityEvent();
    public static UnityEvent ToManyUnitsEvent = new UnityEvent();
    public List<SquadScript> PlayerSquads;
    public static List<CellScript> gameField; //list of all game cells

    PlayerBaseScript playerBaseScript;
    int h, w; //Height & width of our game field

    public static float LevelUpPrice(int lvl)
    {
        return lvl * 100f + lvl / 0.985f;
    }

    public void ChangeGSDurationSlow()
    {
        //playerBaseScript.GSDuration = 8f;
        Time.timeScale = 0.5f;
        Debug.Log(playerBaseScript.GSDuration);
    }

    public void ChangeGSDurationFast()
    {
        //playerBaseScript.GSDuration = 2f;
        Time.timeScale = 2f;
        Debug.Log(playerBaseScript.GSDuration);
    }

    public void ChangeGSDurationNormal()
    {
        //playerBaseScript.GSDuration = 4f;
        Time.timeScale = 1f;
        Debug.Log(playerBaseScript.GSDuration);
    }

    void Start()
    {
        //Instantiate(Canvas);

        playerBaseScript = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<PlayerBaseScript>();
        playerBaseScript.GSDuration = 4f;
        (h, w) = (15, 15);
        CreateGameField(h, w);
        RandomPlayerPosition(); //places playerBase to random map point


        //PathFinder pathFinder = new PathFinder(new Vector2(-7, -7), new Vector2(7, 7));
        //List<Vector2> path = pathFinder.GetPath();
        
        
    }

    void Update()
    {
        
    }

    void CreateGameField(int h, int w)
    {
        (int N, int M) = ((int)Mathf.Floor(h / 2), (int)Mathf.Floor(w / 2)); //Will be used for changing positions of cells
        //gameField = new Vector2[n, m];
        //gameField = new GameObject[n, m];
        gameField = new List<CellScript>();

        for (int i = 0; i < h; i++) // Creating game field
        {
            for (int j = 0; j < w; j++)
            {
                //gameField[i, j] = new Vector2(-M, N);
                //Cell.transform.position = gameField[i, j];
                Cell.transform.position = new Vector2(-M, N);
                GameObject newObj = Instantiate(Cell);
                newObj.GetComponent<CellScript>().Position = Cell.transform.position;
                gameField.Add(newObj.GetComponent<CellScript>());
                M--;
            }
            N--;
            M = (int)Mathf.Floor(w / 2);
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

    void RandomPlayerPosition()
    {
        //GameObject player_base = Instantiate(PlayerBase);
        PlayerBase.transform.position = 
            new Vector3(Random.Range(-7, 7), Random.Range(-7, 7), -1);
        //PlayerBase = player_base;
    }

    void RandomEnemies()
    {

    }
}
