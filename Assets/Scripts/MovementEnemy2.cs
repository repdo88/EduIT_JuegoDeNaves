using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovementEnemy2 : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn1;
    [SerializeField] private Transform bulletSpawn2;
    [SerializeField] private float shootDelay = 1f;
    [SerializeField] private float shootTimer = 2f;
    [Header("Collision Settings")]
    [SerializeField] LayerMask layerMask; // LayerMask to filter collisions
    [Header("Movement Settings")]
    [SerializeField] private float speedZ = 100f; // Speed of the enemy movement
    [SerializeField] private float speedX = 5f; // Speed of the enemy movement in X direction
    private float minX = -38f; // Minimum X position
    private float maxX = 41f; // Maximum X position
    private float xDirection; // Direction of movement in X axis



    private void OnEnable()
    {
        InvokeRepeating("Shoot", shootDelay, shootTimer);
    }
    private void OnDisable()
    {
        CancelInvoke("Shoot");
    }

    private void Shoot()
    {
        GameObject bullet1 = Instantiate(bullet, bulletSpawn1.position, bulletSpawn1.rotation);
        GameObject bullet2 = Instantiate(bullet, bulletSpawn2.position, bulletSpawn2.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        xDirection = Random.value < 0.5f ? -1f : 1f; // Randomly set the direction of movement in X axis
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.z -= speedZ * Time.deltaTime; // Move the enemy in Z axis

        pos.x += xDirection * speedX * Time.deltaTime; // Move the enemy in X axis

        if (pos.x >= maxX)
        {
            pos.x = maxX; // Clamp the position to the maximum X value
            xDirection = -1f; // Change direction to left
        }
        else if (pos.x <= minX)
        {
            pos.x = minX; // Clamp the position to the minimum X value
            xDirection = 1f; // Change direction to right
        }

        transform.position = pos; // Update the enemy position
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Destruye la bala al impactar al enemigo
        if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
    }
}