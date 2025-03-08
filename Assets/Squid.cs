using Unity.VisualScripting;
using UnityEngine;

public class Squid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player; 

    private float speed = 1.0f; 

    private int health = 3;
    private float size = 1.0f;

    private Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            Vector2 direction = (player.transform.position - transform.position).normalized; 
            
            movePlayer(direction); 
        }
    }

    void movePlayer(Vector2 direction) {
        rb.linearVelocity = new Vector2(direction.x, direction.y) * speed; 
    }

    public LayerMask bulletLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is a bullet
        if (((1 << other.gameObject.layer) & bulletLayer) != 0)
        {
            // Optionally, destroy the bullet or deal damage
            Destroy(other.gameObject);  // Destroys the bullet
            TakeDamage();               // Call damage function if you want the enemy to take damage
        }
    }

    void TakeDamage()
    {
        health -= 1;
        size -= 0.2f;
        transform.localScale.Set(size, size, 1.0f);
        if (health <= 0) {
            Destroy(transform.GameObject());
        }
    }
}
