using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_back : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 5f; // Speed of the movement
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
