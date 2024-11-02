using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryThrower : MonoBehaviour
{
    public GameObject cherryPrefab;
    public float cooldown = 2f; // Set cooldown to 2 seconds
    private float timer;

    void Start()
    {
        timer = cooldown; // Initialize the timer
    }

    void Update()
    {
        timer -= Time.deltaTime; // Countdown the timer

        // Check if the left mouse button is pressed and the cooldown has elapsed
        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
            ShootCherry();
        }
    }

    void ShootCherry()
    {
        Instantiate(cherryPrefab, transform.position, Quaternion.identity); // Spawn the cherry
        timer = cooldown; // Reset the cooldown timer
    }
}