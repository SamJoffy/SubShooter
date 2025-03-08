using UnityEngine;

public class Mine : MonoBehaviour
{
    public LayerMask bulletLayer;

    public void Explode() {
        // explode
        Debug.Log("Explode");
    }


    // destroy bullets when hit
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is a bullet
        if (((1 << other.gameObject.layer) & bulletLayer) != 0)
        {
            // Optionally, destroy the bullet or deal damage
            Destroy(other.gameObject);  // Destroys the bullet
        }
    }
}
