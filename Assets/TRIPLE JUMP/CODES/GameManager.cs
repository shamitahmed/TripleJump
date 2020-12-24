using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UDP;

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
        //Instantiate the listener
        IInitListener listener = new InitListener();
        //Use the listener to initialize the UDP stuff
        StoreService.Initialize(listener);

        levelNumber = PlayerPrefs.GetInt(levelKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
