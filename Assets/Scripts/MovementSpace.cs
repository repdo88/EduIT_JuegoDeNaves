using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement_back : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 50f; // Speed of the movement
    [SerializeField] LayerMask layerMask; // Layer mask to check for collisions
    public UnityEvent onDesapear; // Event to trigger when the object disappears
    void Start()
    {
        onDesapear.AddListener(SpawmMap.instance.NewMap); // Add the NewMap method to the event listener
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.gameObject.CompareTag("Finish"))
        if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            onDesapear.Invoke();
            Destroy(gameObject);
        }
    }
}
