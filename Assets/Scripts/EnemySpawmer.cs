using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawmer : MonoBehaviour
{

    [SerializeField] private Transform spawm1;
    [SerializeField] private Transform spawm2;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    private void SpawnEnemy()
    {
        float t = Random.Range(0f, 1f);
        Vector3 spawmPos = Vector3.Lerp(spawm1.position, spawm2.position, t);
        Quaternion spawmRot = Quaternion.LookRotation(Vector3.back, Vector3.up);
        Instantiate(enemy, spawmPos, spawmRot);
    }

    private void OnDrawGizmosSelected()
    {
        if (spawm1 != null && spawm2 != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(spawm1.position, spawm2.position);
            Gizmos.DrawSphere(spawm1.position, 0.1f);
            Gizmos.DrawSphere(spawm2.position, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
