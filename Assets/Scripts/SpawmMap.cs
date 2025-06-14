using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmMap : MonoBehaviour
{

    public static SpawmMap instance; // Singleton instance
    public GameObject mapPrefab; // Prefab to spawn

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Assign the instance
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }


    public void NewMap()
    {
        //Instantiate(mapPrefab, transform.position, transform.rotation);
        Instantiate(mapPrefab, new Vector3(0f,0f,610f), transform.rotation);
    }
}
