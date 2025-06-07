using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn1;
    [SerializeField] private Transform bulletSpawn2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet1 = Instantiate(bullet, bulletSpawn1.position, bulletSpawn1.rotation);
            GameObject bullet2 = Instantiate(bullet, bulletSpawn2.position, bulletSpawn2.rotation);
        }
    }
}
