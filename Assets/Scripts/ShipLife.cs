using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipLife : MonoBehaviour
{
    [SerializeField] LayerMask layerMask; // Layer mask to check for collisions
    public UnityEvent onHit; // Event to trigger when the ship is hit

    private void Start()
    {
        onHit.AddListener(LifeManager.instance.LoseLife); // Add the LoseLife method to the event listener
    }


    private void OnTriggerEnter(Collider collider)
    {
        if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            onHit.Invoke(); // Trigger the event when the ship is hit

        }

    }

}
