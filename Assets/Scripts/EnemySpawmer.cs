using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawmer : MonoBehaviour
{

    public static EnemySpawmer instance; // Singleton instance

    [SerializeField] private Transform spawm1;
    [SerializeField] private Transform spawm2;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float spawnTime2 = 4f;
    [SerializeField] private float spawmDelay = 2f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
        InvokeRepeating("SpawnEnemy2", spawmDelay, spawnTime2);
    }

    private void SpawnEnemy()
    {
        float t = Random.Range(0f, 1f);
        Vector3 spawmPos = Vector3.Lerp(spawm1.position, spawm2.position, t);
        Quaternion spawmRot = Quaternion.LookRotation(Vector3.back, Vector3.up);
        Instantiate(enemy, spawmPos, spawmRot);
    }

    private void SpawnEnemy2()
    {
        float t = Random.Range(0f, 1f);
        Vector3 spawmPos2 = Vector3.Lerp(spawm1.position, spawm2.position, t);
        Quaternion spawmRot2 = Quaternion.LookRotation(Vector3.back, Vector3.up);
        Instantiate(enemy2, spawmPos2, spawmRot2);
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

    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("SpawnEnemy2");
    }
}
