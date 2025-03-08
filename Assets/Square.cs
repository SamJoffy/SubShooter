using UnityEngine;

/*
This class is for the submarine of the game. Even though it is named Square
*/
public class Square : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb; 
    public float moveSpeed = 5.0f;
    public float floatSpeed = 4.0f;


    //Gun Variables 
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform firingPoint; 

    // [Range(0.1f, 1f)]
    // [SerializeField] private float fireRate = 0.5f; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        

        // Set z to 0 because we're working in 2D
        mousePosition.z = 0;

        // Calculate the direction from the player to the mouse
        Vector2 direction = (mousePosition - transform.position).normalized;
        transform.up = direction; 

        // Apply velocity towards the mouse
        MovePlayer(direction);

        if (Input.GetKey(KeyCode.Space)) {
            this.transform.position += UnityEngine.Vector3.down*10.0f*Time.deltaTime; 
        } else {
            this.transform.position -= UnityEngine.Vector3.down*1.0f*Time.deltaTime; 
        }

        if (Input.GetMouseButtonDown(0)) {
             Shoot(); 
         }
        
    }

    void MovePlayer(Vector2 direction)
    {
        // Set the velocity of the Rigidbody2D to move the player
        rb.linearVelocity = new Vector2(direction.x, floatSpeed * -Time.deltaTime) * moveSpeed;
    }

    private void Shoot() {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation); 
    }


}
