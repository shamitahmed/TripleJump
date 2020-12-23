using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;
    public int levelID;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startGame && obstacleNumber < obstacleMaxInLevel)
        {
            spawnDelay += Time.deltaTime;
            if (spawnDelay >= spawnDelayMax)
            {
                GameObject obs = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)], spawnPoint.position, spawnPoint.rotation);
                obstacleNumber++;
                spawnDelay = 0;
            }
        }
    }
}
