using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmMap : MonoBehaviour
{

    public static SpawmMap instance; // Singleton instance
    [SerializeField] private GameObject mapPrefab; // Prefab to spawn

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewMap()
    {
        Instantiate(mapPrefab, transform.position, transform.rotation);
    }
}
