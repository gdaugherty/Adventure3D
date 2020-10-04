using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class GameManager : MonoBehaviour
{
    // Place holders to allow connecting to other objects
    //A reference to the game manager

    public Transform spawnPoint;
    public GameObject player;
    public GameObject DeathScreen;
    public GameObject WinScreen;

    public GameObject[] GoldKeySpawnpoints = null;
    public GameObject[] WhiteKeySpawnpoints = null;
    public GameObject[] BlackKeySpawnpoints = null;
    public GameObject[] ChaliceSpawnpoints = null;
    public GameObject[] SwordSpawnpoints = null;

    public GameObject GoldKey;
    public GameObject WhiteKey;
    public GameObject BlackKey;
    public GameObject Chalice;
    public GameObject Sword;

    // Flags that control the state of the game
    private bool isRunning = false;
    private bool isFinished = false;
    private bool isDead = false;
    private GameObject CarriedObject;

    // So that we can access the player's controller from this script
    private FirstPersonController fpsController;


    // Use this for initialization
    void Start()
    {
        // Finds the First Person Controller script on the Player
        fpsController = player.GetComponent<FirstPersonController>();

        // Disables controls at the start.
        fpsController.enabled = false;
        PositionPlayer();
        SpawnObjects();

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //Runs when the player needs to be positioned back at the spawn point
    public void PositionPlayer()
    {
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
    }

    // Runs when the player is killed by a hazard
    public void DeadPlayer()
    {
        isDead = true;
        isRunning = true;
        isFinished = false;
        fpsController.enabled = false;
        CarriedObject = GameObject.Find("Sword");
        CarriedObject.transform.parent = null;
        CarriedObject = GameObject.Find("GoldKey");
        CarriedObject.transform.parent = null;
        CarriedObject = GameObject.Find("BlackKey");
        CarriedObject.transform.parent = null;
        CarriedObject = GameObject.Find("WhiteKey");
        CarriedObject.transform.parent = null;
        CarriedObject = GameObject.Find("Bridge");
        CarriedObject.transform.parent = null;
        CarriedObject = GameObject.Find("Magnet");
        CarriedObject.transform.parent = null;
        CarriedObject = GameObject.Find("Chalice");
        CarriedObject.transform.parent = null;
    }

    //This resets to game back to the way it started
    private void StartGame()
    {
        isRunning = true;
        isFinished = false;
        isDead = false;

        fpsController.enabled = true;
        
    }

    private void SpawnObjects()
    {
        GoldKey.transform.position = GoldKeySpawnpoints[Random.Range(0, 4)].transform.position;
        WhiteKey.transform.position = WhiteKeySpawnpoints[Random.Range(0, 4)].transform.position;
        BlackKey.transform.position = BlackKeySpawnpoints[Random.Range(0, 4)].transform.position;
        Chalice.transform.position = ChaliceSpawnpoints[Random.Range(0, 4)].transform.position;
        Sword.transform.position = SwordSpawnpoints[Random.Range(0, 4)].transform.position;
    }

    private void ResumeGame()
    {
        //isRunning = true;
        //isFinished = false;
        isDead = false;

        PositionPlayer();
        fpsController.enabled = true;
        
    }
            
    
    // Runs when the player enters the finish zone
    public void FinishedGame()
    {
        isRunning = false;
        isFinished = true;
        fpsController.enabled = false;
    }
    
    //This section creates the Graphical User Interface (GUI)
    void OnGUI()
    {        
        
        if (!isRunning)
        {
            if (isFinished)
            {
                WinScreen.SetActive(true);
            }
            else
            {
                StartGame();                
            }

        }

        if (isDead)
        {            
            DeathScreen.SetActive(true);
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DeathScreen.SetActive(false);
                ResumeGame();               
            }
        }
        
    }
}
