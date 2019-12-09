using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource victoryMusic;
    public AudioSource defeatMusic;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.Play(); //Plays background music as soon as its loaded in
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDefeat() // Plays defeat music from defeat condition in game controller
    {
            backgroundMusic.Stop();
            defeatMusic.Play();
    }
    

    public void PlayVictory() // Plays victory music from victory condition in game controller
    {
            backgroundMusic.Stop();
            victoryMusic.Play();
    }
}
