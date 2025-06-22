using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    public UnityEvent onShoot; // Event to trigger when the player shoots
    public static Shooter instance; // Singleton instance
    private bool canShoot = true; // Variable to control if the player can shoot
    private bool coolDown = false; // Variable to control cooldown state
    [SerializeField] private float coolDownTime = 0.5f; // Cooldown time in seconds

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn1;
    [SerializeField] private Transform bulletSpawn2;

    // Start is called before the first frame update
    void Start()
    {
        onShoot.AddListener(() => AudioManager.instance.PlaySound("PlayerShoot"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot) return; // If the player cannot shoot, exit the method
        if (coolDown) return; // If in cooldown, exit the method
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet1 = Instantiate(bullet, bulletSpawn1.position, bulletSpawn1.rotation);
            GameObject bullet2 = Instantiate(bullet, bulletSpawn2.position, bulletSpawn2.rotation);
            StartCoroutine(startCoolDown()); // Start the cooldown coroutine
            onShoot.Invoke(); // Trigger the shoot event
        }
    }

    private IEnumerator startCoolDown()
    {
        coolDown = true; // Set cooldown state to true
        yield return new WaitForSeconds(coolDownTime); // Wait for the cooldown time
        coolDown = false; // Set cooldown state to false
    }

    public void SetCanShoot()
    {
        StartCoroutine(stopShooting()); // Start the coroutine to stop shooting
    }

    private IEnumerator stopShooting()
    {
        //print("stop shooting"); // Debug message
        canShoot = false; // Disable shooting
        yield return new WaitForSeconds(3f); // Wait for 0.5 seconds
        canShoot = true; // Enable shooting again
    }
}
