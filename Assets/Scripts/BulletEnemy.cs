using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    [SerializeField] float speed = 200f;
    [SerializeField] private LayerMask layerMask; // Layer mask to check for collisions

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
        // Destruye la bala al impactar al enemigo
        //if ((collider.gameObject.CompareTag("Player")) || (collider.gameObject.CompareTag("FinalCamaraBaja")))
        if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
    }
}
