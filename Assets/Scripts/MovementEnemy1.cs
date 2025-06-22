using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementEnemy1 : MonoBehaviour
{
    public UnityEvent onShootRecive;
    [SerializeField] private float speed = 20f; // Speed of the movement
    [SerializeField] private LayerMask layerMask; // Layer mask to check for collisions
    [SerializeField] private string bulletLayer = "BulletPlayer"; // Name of the layer for enemies
    [SerializeField] private string playerLayer = "Player"; // Name of the layer for enemies
    private bool isDead = false; // Flag to check if the enemy is dead
    [SerializeField] private int killPoints = 1; // Points to add to the score when the enemy is hit
    [SerializeField] private GameObject explosionPrefab; // Prefab for explosion effect


    // Start is called before the first frame update
    void Start()
    {
        // Fix: Wrap the method call in a lambda to pass it as a UnityAction
        onShootRecive.AddListener(() => ScoreManager.instance.AddScore(killPoints)); // Add the AddScore method to the event listener
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isDead) return; // If the enemy is already dead, do nothing
        if (collider.gameObject.layer == LayerMask.NameToLayer(bulletLayer))
        {
            isDead = true; // Set the enemy as dead
            //print("Enemy hit by bullet!"); // Debug message for enemy hit
            onShootRecive.Invoke(); // Invoca el evento al recibir un disparo
            explode(); // Call the explode method to create explosion effect
            Destroy(gameObject);

        }
        else if (collider.gameObject.layer == LayerMask.NameToLayer(playerLayer))
        {
            Destroy(gameObject);
            explode(); // Call the explode method to create explosion effect

        }

        // Destruye el enemigo al chocar o salir del mapa
        else if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            Destroy(gameObject);

        }
    }

    private void explode()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            Destroy(explosion, ps.main.duration + ps.main.startLifetime.constantMax); // Destroy the explosion effect after 2 seconds
        }
    }


}
