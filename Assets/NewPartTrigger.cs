using UnityEngine;
using System;

public class NewPartTrigger : MonoBehaviour
{
    public Vector2 boxCastSize = new Vector2(1f, 1f);  // Size of the box
    public Vector2 boxCastDirection = Vector2.up;      // Direction of the cast (upward in this case)
    public float castDistance = 5f;                    // Cast distance (set this to an appropriate value)
    public LayerMask collisionLayer;                   // Filter layer mask to detect only certain objects

    public event Action GenerateNewPart;               // The event to notify when the action is triggered

    private bool canHit = true;                        // Whether the BoxCast can hit or not
    private float timeSinceHit = 0.0f;                 // Time since last hit for cooldown

    void Update()
    {
        if (canHit)
        {
            castCheck();  // Perform the BoxCast
        }
        else if (timeSinceHit > 2.0f) // After 2 seconds, reset the cooldown
        {
            canHit = true;
        }
        else
        {
            timeSinceHit += Time.deltaTime; // Increment the time since last hit
        }
    }

    void castCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, boxCastDirection, castDistance, collisionLayer);

        if (hit.collider != null)
        {
            Debug.Log("Hit player or valid object: " + hit.collider.name);
            canHit = false;
            timeSinceHit = 0f;  // Reset the cooldown timer
            GenerateNewPart?.Invoke();  // Trigger the event
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)boxCastDirection * castDistance, new Vector3(boxCastSize.x, boxCastSize.y, 1));
    }
}