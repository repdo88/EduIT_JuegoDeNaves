using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float speed = 50f;
    //[SerializeField] private float lifetime = 5f;

    //private void OnEnable()
    //{
    //    Invoke(nameof(DestroyBullet), lifetime);
    //}

    //private void DestroyBullet()
    //{
    //    Destroy(gameObject);
    //}

    //private void OnDestroy()
    //{
    //    CancelInvoke(nameof(DestroyBullet)); // Cancela el timer si se destruye antes por otra cosa
    //}


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Destruye la bala al impactar al enemigo
        if ((collider.gameObject.CompareTag("Enemy")) || (collider.gameObject.CompareTag("FinalCamaraAlta")))
        {
            Destroy(gameObject);
        }
    }

}
