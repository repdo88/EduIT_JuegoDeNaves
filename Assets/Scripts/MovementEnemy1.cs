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
    private bool isDead = false; // Flag to check if the enemy is dead
    //[SerializeField] private float lifetime = 8f;

    //private void OnEnable()
    //{
    //    Invoke(nameof(DestroyEnemy), lifetime);
    //}

    //private void DestroyEnemy()
    //{
    //    Destroy(gameObject);
    //}

    //private void OnDestroy()
    //{
    //    CancelInvoke(nameof(DestroyEnemy)); // Cancela el timer si se destruye antes por otra cosa
    //}


    // Start is called before the first frame update
    void Start()
    {
        onShootRecive.AddListener(ScoreManager.instance.AddScore); // Add the AddScore method to the event listener
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
            Destroy(gameObject);
            
        }

        // Destruye el enemigo al chocar o salir del mapa
        //if ((collider.gameObject.CompareTag("Bullet")) || (collider.gameObject.CompareTag("Player")) || (collider.gameObject.CompareTag("FinalCamaraBaja")))
        else if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //     //Destruye el enemigo al colisionar con el jugador
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
