using UnityEngine;

/*
This class is for the submarine of the game. Even though it is named Square
*/
public class Square : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb; 


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
         UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        //Implements the rotation of the sub

        UnityEngine.Vector2 direction =  new UnityEngine.Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction; 
        


        //Implements the movement of the Sub 
        UnityEngine.Vector3 target = new UnityEngine.Vector3(mousePos.x, transform.position.y, transform.position.z);
        this.transform.position = UnityEngine.Vector3.Lerp(this.transform.position,target, 5f*Time.deltaTime); 

        if (Input.GetMouseButtonDown(0)) {
            Shoot(); 
        }

        if (Input.GetKey(KeyCode.Space)) {
            this.transform.position += UnityEngine.Vector3.down*10.0f*Time.deltaTime; 
        } else {
            this.transform.position -= UnityEngine.Vector3.down*1.0f*Time.deltaTime; 
        }
        
    }

    private void Shoot() {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation); 
    }


}
