using UnityEngine;
using System;

public class NewPartTrigger : MonoBehaviour
{
    // Set the size of the BoxCast (this will be the width and height of the box)
    public Vector2 boxCastSize = new Vector2(1f, 1f);
    
    // Set the direction of the BoxCast (usually forward or in a specific direction)
    public Vector2 boxCastDirection = Vector2.right;

    // Distance to cast the box
    public float castDistance = 1f;

    // Layer mask to filter out which objects to check for collisions (you can leave it as default if no filtering needed)
    public LayerMask collisionLayer;

    public event Action GenerateNewPart;

    private bool canHit = true;
    private double timeSinceHit = 0.0;

    void Start()
    {
        collisionLayer = UnityEngine.LayerMask.NameToLayer("Player");
    }

    void Update()
    {
        if (canHit) {
            BoxCastCheck();
        }
        else if (timeSinceHit > 2.0) {
            canHit = true;
        }
        else {
            timeSinceHit += Time.deltaTime;
        }
    }

    void BoxCastCheck()
    {
        // Perform the BoxCast using Physics2D.BoxCast
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, boxCastDirection, castDistance, collisionLayer);

        // Check if the BoxCast hit something
        if (hit.collider != null)
        {
            // Check if the object hit has the "Player" tag
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Hit player");
                GenerateNewPart?.Invoke();
                canHit = false;
                timeSinceHit = 0.0;
            }
        }
    }

    // Optional: Visualize the BoxCast in the Scene view (for debugging purposes)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)boxCastDirection * castDistance, new Vector3(boxCastSize.x, boxCastSize.y, 1));
    }

}
