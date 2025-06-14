using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipLife : MonoBehaviour
{
    [SerializeField] LayerMask layerMask; // Layer mask to check for collisions
    public UnityEvent onHit; // Event to trigger when the ship is hit
    private MeshCollider meshCollider; // Reference to the MeshCollider component
    private Renderer ren; // Reference to the Renderer component

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>(); // Get the MeshCollider component
        ren = GetComponent<Renderer>(); // Get the Renderer component
        onHit.AddListener(LifeManager.instance.LoseLife); // Add the LoseLife method to the event listener
        //onHit.AddListener(ShipMovement.instance.RestartShip); // Add the ResetPosition method to the event listener
    }


    private void OnTriggerEnter(Collider collider)
    {
        if ((layerMask.value & (1 << collider.transform.gameObject.layer)) > 0)
        {
            onHit.Invoke(); // Trigger the event when the ship is hit
            StartCoroutine(Desactivate(1f, 1f)); // Start the coroutine to deactivate the ship

        }

    }

    private IEnumerator Desactivate(float objectTime, float meshTime)
    {
        ren.enabled = false; // Disable the Renderer
        meshCollider.enabled = false; // Disable the MeshCollider
        yield return new WaitForSeconds(objectTime); // Wait for the specified time
        ren.enabled = true; // Enable the Renderer
        yield return new WaitForSeconds(meshTime); // Wait for the specified time
        meshCollider.enabled = true; // Enable the MeshCollider again
    }

}
