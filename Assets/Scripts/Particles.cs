using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour
{
    private ParticleSystem ps;
   //  public float hSliderValue = 1.0F;
    public bool celebrationP;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        celebrationP = false;
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = 5.0F;

        if (celebrationP == true) //Sets particle speed for winning
        {
            main.simulationSpeed = 100.0F;
        }
    }
}
