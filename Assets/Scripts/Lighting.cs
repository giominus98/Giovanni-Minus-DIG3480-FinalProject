using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour
{
    // Interpolate light color between two colors back and forth
    private float lightIntensity = 20.0f;
    private bool lightsOn;
    float duration = 1.0f;
    Color color0 = Color.cyan;
    Color color1 = Color.blue;

    Light lt;

    public bool celebrationL;
    private GameController gameController;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        lt = GetComponent<Light>();
        celebrationL = false;
    }

    void Update()
    {
        // set light color

        if (celebrationL == true) //Sets lighting for winning
        {
            lightsOn = true;
            gameController.YouWin(); //Runs win function... way over here :P

        }

        if (lightsOn)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(color0, color1, t);
            lt.intensity = lightIntensity;
        }

    }
}