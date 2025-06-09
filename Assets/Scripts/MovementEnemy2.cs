using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy2 : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn1;
    [SerializeField] private Transform bulletSpawn2;
    [SerializeField] private float shootDelay = 1f;
    [SerializeField] private float shootTimer = 2f;
    


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
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back * 100f * Time.deltaTime, Space.World); // Temporal hasta que haga el movimiento que lleva este
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Destruye el enemigo al recibir un disparo
        if ((collider.gameObject.CompareTag("Player")) || (collider.gameObject.CompareTag("FinalCamaraBaja")))
        {
            Destroy(gameObject);
        }
    }
}