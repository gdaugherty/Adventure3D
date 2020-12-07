using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class GameManager : MonoBehaviour
{
    // Place holders to allow connecting to other objects
    //A reference to the game manager

    public Transform PlayerSpawnPoint;
    public GameObject player;
    public GameObject DeathScreen;
    public GameObject WinScreen;

    public GameObject[] GoldKeySpawnpoints;
    public GameObject[] WhiteKeySpawnpoints;
    public GameObject[] BlackKeySpawnpoints;
    public GameObject[] ChaliceSpawnpoints;
    public GameObject[] SwordSpawnpoints;
    public GameObject[] BridgeSpawnpoints;
    public GameObject[] MagnetSpawnpoints;
    //public GameObject[] DragonSpawnpoints;

    public GameObject[] PickupItems;
    
    //public GameObject YellowDragon;
    //public GameObject GreenDragon;
    //public GameObject RedDragon;

    // Flags that control the state of the game
    private bool isRunning = false;
    private bool isFinished = false;
    public bool isDead = false;
    
    // So that we can access the player's controller from this script
    private FirstPersonController fpsController;
  

    public delegate void DroppedObject();
    public static event DroppedObject dropped;


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
        player.transform.position = PlayerSpawnPoint.position;
        player.transform.rotation = PlayerSpawnPoint.rotation;
    }


    // Runs when the player is killed by a hazard
    public void DeadPlayer()
    {
        isDead = true;
        isRunning = true;
        isFinished = false;
        fpsController.enabled = false;
        dropped?.Invoke();
        PositionPlayer();
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
        PickupItems[0].transform.position = GoldKeySpawnpoints[Random.Range(0, 4)].transform.position;
        PickupItems[1].transform.position = WhiteKeySpawnpoints[Random.Range(0, 4)].transform.position;
        PickupItems[2].transform.position = BlackKeySpawnpoints[Random.Range(0, 4)].transform.position;
        PickupItems[3].transform.position = ChaliceSpawnpoints[Random.Range(0, 4)].transform.position;
        PickupItems[4].transform.position = SwordSpawnpoints[Random.Range(0, 4)].transform.position;
        PickupItems[5].transform.position = BridgeSpawnpoints[Random.Range(0, 4)].transform.position;
        PickupItems[6].transform.position = MagnetSpawnpoints[Random.Range(0, 4)].transform.position;

    }

    private void ResumeGame()
    {
        isDead = false;
        fpsController.enabled = true;
        PositionPlayer();
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
