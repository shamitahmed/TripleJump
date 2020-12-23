using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool startGame;
    public bool dead;
    public bool escape;
    public string levelKey = "levelkey";
    public int levelNumber;
    public string totalFailedKey = "totalFailedKey";
    public int totalFailNumber;
    public GameObject escapeRocket;
    public GameObject hitfx;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelNumber = PlayerPrefs.GetInt(levelKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
