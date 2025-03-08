using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapPart;

    private GameObject previousPart;
    private GameObject currentPart;
    private GameObject nextPart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousPart = Instantiate(mapPart, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
        currentPart = Instantiate(mapPart, transform.position - new Vector3(0, 30, 0), Quaternion.identity);
        nextPart = Instantiate(mapPart, transform.position - new Vector3(0, 70, 0), Quaternion.identity);

        AddNewPartTrigger(previousPart);
        AddNewPartTrigger(currentPart);
        AddNewPartTrigger(nextPart);

    }

    void AddNewPartTrigger(GameObject part)
    {
        NewPartTrigger trigger = part.AddComponent<NewPartTrigger>();
        trigger.GenerateNewPart += addNewPart; // Subscribe to the event
    }

    void addNewPart() {
        Destroy(previousPart);
        previousPart = currentPart;
        currentPart = nextPart;


        Debug.Log("Adding new part. Position: " + (currentPart.transform.position - new Vector3(0, 40 - 7.0F * Time.deltaTime * 2, 0)));
        // todo: change when know speed of map
        nextPart = Instantiate(mapPart, currentPart.transform.position - new Vector3(0, 40 - 7.0F * Time.deltaTime * 2, 0), Quaternion.identity);
        
        AddNewPartTrigger(nextPart);
    }

    private void OnDestroy()
    {
        if (previousPart != null)
        {
            previousPart.GetComponent<NewPartTrigger>().GenerateNewPart -= addNewPart;
        }
        if (currentPart != null)
        {
            currentPart.GetComponent<NewPartTrigger>().GenerateNewPart -= addNewPart;
        }
        if (nextPart != null)
        {
            nextPart.GetComponent<NewPartTrigger>().GenerateNewPart -= addNewPart;
        }
    }
    

}
