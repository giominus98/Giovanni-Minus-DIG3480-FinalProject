using System.Collections;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject pickupEffect;
    public int pointsValue;

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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PickUp") || other.CompareTag("PowerUp")) //Ignores destroying the boundary and others
        {
            return;
        }

        // Debug.Log(other.name);

        // if (CompareTag("PickUp") && other.CompareTag("Player")) // Creates Player pickup effect
      //  {
            // Instantiate(pickupEffect, other.transform.position, other.transform.rotation);
            // gameController.AddPoints(pointsValue);
            // Destroy(gameObject);
        //}

        if (other.CompareTag("Player")) // Creates player powerup effect
        {
            Instantiate(pickupEffect, other.transform.position, other.transform.rotation);
            gameController.NewWeapon();
            gameController.AddPoints(pointsValue);
            Destroy(gameObject);
        }
    }

   // CompareTag("PowerUp") && o
}
