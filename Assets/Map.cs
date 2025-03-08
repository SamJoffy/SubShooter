using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapPart;
    public GameObject player;

    private GameObject previousPart;
    private GameObject currentPart;
    private GameObject nextPart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousPart = Instantiate(mapPart, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
        currentPart = Instantiate(mapPart, transform.position - new Vector3(0, 30, 0), Quaternion.identity);
        nextPart = Instantiate(mapPart, transform.position - new Vector3(0, 70, 0), Quaternion.identity);

        AddNewPartTrigger(previousPart.transform.GetChild(2).gameObject);
        AddNewPartTrigger(currentPart.transform.GetChild(2).gameObject);
        AddNewPartTrigger(nextPart.transform.GetChild(2).gameObject);
        
        previousPart.GetComponent<MapPart>().Player = player;
        currentPart.GetComponent<MapPart>().Player = player;
        nextPart.GetComponent<MapPart>().Player = player;

    }

    void AddNewPartTrigger(GameObject part)
    {
        NewPartTrigger trigger = part.GetComponent<NewPartTrigger>();
        trigger.GenerateNewPart += addNewPart; // Subscribe to the event
    }

    void addNewPart() {
        Destroy(previousPart);
        previousPart = currentPart;
        currentPart = nextPart;

        // todo: change when know speed of map
        nextPart = Instantiate(mapPart, currentPart.transform.position - new Vector3(0, 40 - 7.0F * Time.deltaTime * 2, 0), Quaternion.identity);
        
        AddNewPartTrigger(nextPart.transform.GetChild(2).gameObject);
        nextPart.GetComponent<MapPart>().Player = player;
    }

    private void OnDestroy()
    {
        if (previousPart != null)
        {
            previousPart.transform.GetChild(2).gameObject.GetComponent<NewPartTrigger>().GenerateNewPart -= addNewPart;
        }
        if (currentPart != null)
        {
            currentPart.transform.GetChild(2).gameObject.GetComponent<NewPartTrigger>().GenerateNewPart -= addNewPart;
        }
        if (nextPart != null)
        {
            nextPart.transform.GetChild(2).gameObject.GetComponent<NewPartTrigger>().GenerateNewPart -= addNewPart;
        }
    }
    

}
