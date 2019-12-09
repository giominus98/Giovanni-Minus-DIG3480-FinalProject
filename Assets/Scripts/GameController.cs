using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards; //Wave 1 variables
    public Vector3 spawnValuesH;
    public int hazardCount;
    public float spawnWaitH;
    public float startWaitH;
    public float waveWaitH;

    public GameObject[] hazards2; //Wave 2 variables
    public Vector3 spawnValuesH2;
    public int hazardCount2;
    public float spawnWaitH2;
    public float startWaitH2;
    public float waveWaitH2;

    public GameObject[] hazards3; //Wave 3 variables
    public Vector3 spawnValuesH3;
    public int hazardCount3;
    public float spawnWaitH3;
    public float startWaitH3;
    public float waveWaitH3;

    public GameObject[] pickups; //Item Wave variables
    public Vector3 spawnValuesP;
    public int pickupCount;
    public float spawnWaitP;
    public float startWaitP;
    public float waveWaitP;

    public Text pointsText; 
    public Text restartText;
    public Text gameOverText;
    public Text youWinText;
    public Text phaseText;

    private int phase;
    private int points;
    private bool restart;
    private bool gameOver;
    public bool youWin; //Set to public so it can be accessed by other scripts

    private GameObject player;
    private GameObject enemy;
    private GameObject effects;
    private GameObject lights;
    private GameObject background;

    private GameObject playerControllerObject;
    private PlayerController playerController;

    void Start()
    {
        playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnPickups());
        phase = 0;
        points = 0;
        UpdatePoints();
        restart = false;
        gameOver = false;
        youWin = false;
        restartText.text = "";
        gameOverText.text = "";
        youWinText.text = "";
        player = GameObject.FindGameObjectWithTag("Player"); //Reference and modify another scripts variable by its tag
        effects = GameObject.FindGameObjectWithTag("Effects");
        lights = GameObject.FindGameObjectWithTag("Lights");
        background = GameObject.FindGameObjectWithTag("Background");
    }


    void Update() //Reloads scene and exits game
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Space Shooter");
            }
        }
        WinCondition(); //Checks win conditions every frame
        NextPhase(); //Checks phase conditions every frame
    }


    IEnumerator SpawnWaves() //Sets up enemy waves 1
    {
        if (points < 100)
        {
            yield return new WaitForSeconds(startWaitH);
            while (true) //Makes this loop infinite, spawning infinite enemies.
            {
                for (int i = 0; i < hazardCount; i++) //Spawn multiple enemies at once
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPositionH = new Vector3(Random.Range(-spawnValuesH.x, spawnValuesH.x), spawnValuesH.y, spawnValuesH.z);
                    Quaternion spawnRotationH = Quaternion.identity;
                    Instantiate(hazard, spawnPositionH, spawnRotationH);
                    yield return new WaitForSeconds(spawnWaitH);
                }
                yield return new WaitForSeconds(waveWaitH);

                if (gameOver) //Restart at Game Over, stops spawns.
                {
                    restartText.text = "Press 'T' for Restart";
                    restart = true;
                    break;
                }

                if (points >= 100)
                {
                    StartCoroutine(SpawnWaves2());
                    break;
                }

            }
        }
    }

    IEnumerator SpawnWaves2() //Sets up enemy waves2
    {
        if (points >= 100 && points < 300)
        {
            yield return new WaitForSeconds(startWaitH2);
            while (true) //Makes this loop infinite, spawning infinite enemies.
            {
                for (int i = 0; i < hazardCount2; i++) //Spawn multiple enemies at once
                {
                    GameObject hazard2 = hazards2[Random.Range(0, hazards2.Length)];
                    Vector3 spawnPositionH2 = new Vector3(Random.Range(-spawnValuesH2.x, spawnValuesH2.x), spawnValuesH2.y, spawnValuesH2.z);
                    Quaternion spawnRotationH2 = Quaternion.identity;
                    Instantiate(hazard2, spawnPositionH2, spawnRotationH2);
                    yield return new WaitForSeconds(spawnWaitH2);
                }
                yield return new WaitForSeconds(waveWaitH2);

                if (gameOver) //Restart at Game Over, stops spawns.
                {
                    restartText.text = "Press 'T' for Restart";
                    restart = true;
                    break;
                }

                if (points >= 300)
                {
                    StartCoroutine(SpawnWaves3());
                    break;
                }
            }
        }
    }

    IEnumerator SpawnWaves3() //Sets up enemy waves 3
    {
        if (points >= 300 && points < 500)
        {
            yield return new WaitForSeconds(startWaitH3);
            while (true) //Makes this loop infinite, spawning infinite enemies.
            {
                for (int i = 0; i < hazardCount3; i++) //Spawn multiple enemies at once
                {
                    GameObject hazard3 = hazards3[Random.Range(0, hazards3.Length)];
                    Vector3 spawnPositionH3 = new Vector3(Random.Range(-spawnValuesH3.x, spawnValuesH3.x), spawnValuesH3.y, spawnValuesH3.z);
                    Quaternion spawnRotationH3 = Quaternion.identity;
                    Instantiate(hazard3, spawnPositionH3, spawnRotationH3);
                    yield return new WaitForSeconds(spawnWaitH3);
                }
                yield return new WaitForSeconds(waveWaitH3);

                if (gameOver) //Restart at Game Over, stops spawns.
                {
                    restartText.text = "Press 'T' for Restart";
                    restart = true;
                    break;
                }

                if (points >= 500)
                {
                    break;
                }
            }
        }
    }


    IEnumerator SpawnPickups() //Sets up pickup waves
    {
        yield return new WaitForSeconds(startWaitP);
        while (true) //Makes this loop infinite, spawning infinite pickupss.
        {
            for (int i = 0; i < pickupCount; i++) //Spawn multiple pickups at once
            {
                GameObject item = pickups[Random.Range(0, pickups.Length)];
                Vector3 spawnPositionP = new Vector3(Random.Range(-spawnValuesP.x, spawnValuesP.x), spawnValuesP.y, spawnValuesP.z);
                Quaternion spawnRotationP = Quaternion.identity;
                Instantiate(item, spawnPositionP, spawnRotationP);
                yield return new WaitForSeconds(spawnWaitP);
            }
            yield return new WaitForSeconds(waveWaitP);

            if (gameOver) //Restart at Game Over, stops spawns.
            {
                break;
            }

            if (youWin) //Restart at Win, stops spawns.
            {
                break;
            }
        }
    }

    void NextPhase() //Counts phases based on point accumulated
    {
        if (points < 100)
        {
            phase = 1;
        }

        if (points >= 100 && points < 300)
        {
            phase = 2;
        }

        if (points >= 300 && points < 500)
        {
            phase = 3;
        }
        phaseText.text = "Phase " + phase;
    }

    public void AddPoints(int newPointsValue) //Adds score
    {
        points += newPointsValue;
        UpdatePoints();
    }

    void UpdatePoints()
    {
        pointsText.text = "Points: " + points;
    }

    public void NewWeapon() //Runs the second weapon script in game controller
    {
        playerController.GetSecondWeapon();
    }


    void WinCondition() //Sets win conditions
    {
        if (points >= 500 && gameOver != true)
        {  
            Destroy(GameObject.FindGameObjectWithTag("Enemy")); //Destroys all remaining objects on screen
            Destroy(GameObject.FindGameObjectWithTag("PickUp"));
            Destroy(GameObject.FindGameObjectWithTag("PowerUp"));

            player.GetComponent<PlayerController>().canMove = false; // Can't shoot
            player.GetComponent<PlayerController>().playerSpeed = 0; // Can't move
            effects.GetComponent<Particles>().celebrationP = true; //Sets Victory Celebration variables
            lights.GetComponent<Lighting>().celebrationL = true;
            background.GetComponent<BG_Scroller>().celebrationBG = true;
        }

        
        if (gameOver == true) //Makes it so you cannot both lose and win.
        {
            youWinText.text = "";
            youWin = false;
        }
    }


    public void YouWin() //Displays win text when player wins
    {
        if (gameOver == false) //Makes it so you cannot both lose and win again.
        {
            FindObjectOfType<Music>().PlayVictory();
            gameOverText.text = "";
            youWinText.text = "You Win! Game Created by Giovanni Minus :)";
            youWin = true;
        }
    }


    public void GameOver() //Displays game over text when player dies
    {
        if (youWin == false) //Makes it so you cannot both lose and win again.
        {
            FindObjectOfType<Music>().PlayDefeat();
            youWinText.text = "";
            gameOverText.text = "Game Over";
            gameOver = true;
        }
    }
}
