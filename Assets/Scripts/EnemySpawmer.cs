using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawmer : MonoBehaviour
{

    public static EnemySpawmer instance; // Singleton instance

    [SerializeField] private Transform spawm1;
    [SerializeField] private Transform spawm2;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speedEnemy1 = 100f;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private int enemy1KillPoints = 1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private float speedEnemy2 = 50f;
    [SerializeField] private float spawnTime2 = 4f;
    [SerializeField] private float spawmDelay = 2f;
    [SerializeField] private int enemy2KillPoints = 3;
    [Space]
    [SerializeField] private float speedMultiplier = 1.5f; // Speed multiplier for enemies
    [SerializeField] private int killPointsMultiplier = 2;

    private float newSpeed1;
    private float newSpeed2;
    private int newEnemy1KillPoints;
    private int newEnemy2KillPoints;

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
        newSpeed1 = speedEnemy1;
        newSpeed2 = speedEnemy2;
        newEnemy1KillPoints = enemy1KillPoints;
        newEnemy2KillPoints = enemy2KillPoints;

        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
        InvokeRepeating("SpawnEnemy2", spawmDelay, spawnTime2);
    }

    private void SpawnEnemy()
    {
        float t = Random.Range(0f, 1f);
        Vector3 spawmPos = Vector3.Lerp(spawm1.position, spawm2.position, t);
        Quaternion spawmRot = Quaternion.LookRotation(Vector3.back, Vector3.up);
        GameObject enemyGO = Instantiate(enemy, spawmPos, spawmRot);
        enemyGO.GetComponent<MovementEnemy1>().SetSpeed(newSpeed1);
        enemyGO.GetComponent<MovementEnemy1>().SetKillPoints(newEnemy1KillPoints); // Set the kill points for the enemy
    }

    private void SpawnEnemy2()
    {
        float t = Random.Range(0f, 1f);
        Vector3 spawmPos2 = Vector3.Lerp(spawm1.position, spawm2.position, t);
        Quaternion spawmRot2 = Quaternion.LookRotation(Vector3.back, Vector3.up);
        GameObject enemyGO2 = Instantiate(enemy2, spawmPos2, spawmRot2);
        enemyGO2.GetComponent<MovementEnemy2>().SetSpeed(newSpeed2);
        enemyGO2.GetComponent<MovementEnemy2>().SetKillPoints(newEnemy2KillPoints); // Set the kill points for the enemy
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

    public void IncreaseEnemySpeed()
    {
        newSpeed1 = speedMultiplier * speedEnemy1; // Increase speed for enemy 1
        newSpeed2 = speedMultiplier * speedEnemy2; // Increase speed for enemy 2
    }

    public void IncreaseKillPoints()
    {
        newEnemy1KillPoints = enemy1KillPoints * killPointsMultiplier; // Increase kill points for enemy 1
        newEnemy2KillPoints = enemy2KillPoints * killPointsMultiplier; // Increase kill points for enemy 2
    }
}
