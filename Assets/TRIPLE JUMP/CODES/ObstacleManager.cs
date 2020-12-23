using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;
    int obstacleNumber;
    public int obstacleMaxInLevel;
    public int obstaclePassed;
    public Transform spawnPoint;
    float spawnDelay;
    public float spawnDelayMax;
    public GameObject[] obstaclePrefab;


    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = 0f;
        GameManager.instance.levelNumber = PlayerPrefs.GetInt(GameManager.instance.levelKey);
        SpawnCountModifier();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startGame && obstacleNumber < obstacleMaxInLevel && !GameManager.instance.dead)
        {
            spawnDelay += Time.deltaTime;
            if (spawnDelay >= spawnDelayMax)
            {
                if (GameManager.instance.levelNumber < 2)
                {
                    GameObject obs = Instantiate(obstaclePrefab[Random.Range(0,2)], spawnPoint.position, spawnPoint.rotation);
                }
                else if(GameManager.instance.levelNumber < 5)
                {
                    GameObject obs = Instantiate(obstaclePrefab[Random.Range(0, 4)], spawnPoint.position, spawnPoint.rotation);
                }
                else
                {
                    GameObject obs = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)], spawnPoint.position, spawnPoint.rotation);
                }           
                obstacleNumber++;
                spawnDelay = 0;
            }
        }
    }
    public void SpawnCountModifier()
    {
        if (GameManager.instance.levelNumber < 2)
        {
            obstacleMaxInLevel = 4;
        }
        else if (GameManager.instance.levelNumber < 5)
        {
            obstacleMaxInLevel = 6;
        }
        else if (GameManager.instance.levelNumber < 10)
        {
            obstacleMaxInLevel = 7;
        }
        else if (GameManager.instance.levelNumber < 15)
        {
            obstacleMaxInLevel = 8;
        }
        else
        {
            obstacleMaxInLevel = 10;
        }
    }
}
