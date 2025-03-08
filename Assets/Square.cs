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

    public GameObject restartScreen;

    private float immobilizedTime = 0;
    public float timeToBeImobilized = 2f;


    //Gun Variables 
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform firingPoint; 

    // [Range(0.1f, 1f)]
    // [SerializeField] private float fireRate = 0.5f; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        restartScreen.SetActive(false);
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
        if (immobilizedTime <= 0) {
            MovePlayer(direction);
        }
        else {
            immobilizedTime -= Time.deltaTime;
            rb.linearVelocity = new Vector2(0,0);
        }

        if (Input.GetKey(KeyCode.Space) && immobilizedTime <= 0) {
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
        if (Time.timeScale != 0) {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation); 
        }
    }

    public LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is a bullet
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            if (other.gameObject.tag == "Mine") {
                other.gameObject.GetComponent<Mine>().Explode();
                EndGame();
            }
            else if (other.gameObject.tag == "Squid") {
                Destroy(other.gameObject);
                immobilizedTime = timeToBeImobilized;
            }
        }
    }

    private void EndGame() {
        Time.timeScale = 0.0f;
        restartScreen.SetActive(true);
    }

}
