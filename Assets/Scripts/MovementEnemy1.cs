using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy1 : MonoBehaviour
{
    [SerializeField] private float speed = 20f; // Speed of the movement
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
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Destruye el enemigo al recibir un disparo
        if ((collider.gameObject.CompareTag("Bullet")) || (collider.gameObject.CompareTag("Player")) || (collider.gameObject.CompareTag("FinalCamaraBaja")))
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
