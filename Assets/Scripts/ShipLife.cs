using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipLife : MonoBehaviour
{
    public static ShipLife instance; // Singleton instance of ShipLife

    [SerializeField] LayerMask layerMask; // Layer mask to check for collisions
    public UnityEvent onHit; // Event to trigger when the ship is hit
    private MeshCollider meshCollider; // Reference to the MeshCollider component
    private Renderer ren; // Reference to the Renderer component
    [SerializeField] private float renderTime = 1f; // Time to render the ship after being hit
    [SerializeField] private float meshTime = 2f; // Time to enable the MeshCollider after being hit
    [SerializeField] private Material originalMaterial; // Original material of the ship
    [SerializeField] private Material transparentMaterial; // Material to apply when the ship is hit
    [SerializeField] private GameObject explosionPrefab; // Prefab for explosion effect

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
            explode(); // Call the explode method to create explosion effect
            onHit.Invoke(); // Trigger the event when the ship is hit
            StartCoroutine(Desactivate(renderTime, meshTime)); // Start the coroutine to deactivate the ship

        }

    }

    private IEnumerator Desactivate(float objectTime, float meshTime)
    {
        ren.enabled = false; // Disable the Renderer
        meshCollider.enabled = false; // Disable the MeshCollider
        yield return new WaitForSeconds(objectTime); // Wait for the specified time
        ren.enabled = true; // Enable the Renderer
        ren.material = transparentMaterial; // Change the material to transparent
        yield return new WaitForSeconds(meshTime); // Wait for the specified time
        meshCollider.enabled = true; // Enable the MeshCollider again
        ren.material = originalMaterial; // Change the material back to the original
    }

    public void killShip()
    {
        this.gameObject.SetActive(false); // Deactivate the ship GameObject
    }

    private void explode()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            Destroy(explosion, ps.main.duration + ps.main.startLifetime.constantMax); // Destroy the explosion effect after 2 seconds
        }
    }

}
