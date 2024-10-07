using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{


    //public static LevelGenerator Instance;
    public GameObject floorPrefab;
    List<GameObject> floors;
    // Start is called before the first frame update
    void Start()
    {

       // Instance = this;

        floors = new List<GameObject>();
        GameObject firstFloor = Instantiate(floorPrefab);
        //GameObject secondFloor = Instantiate(floorPrefab);
        //secondFloor.transform.position = firstFloor.transform.position + new Vector3(0, 0, 10);

        //floors.Add(firstFloor);
        //floors.Add(secondFloor);

        //TODO: Use this:
        // Instantiate(myPrefab,firstFloor.transform.position + new Vector3(0,0,10), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addFloor()
    {
        GameObject nextFloor = Instantiate(floorPrefab);
        // not nullsafe!
        nextFloor.transform.position = floors.Last().transform.position + new Vector3(0, 0, 10);
        // smh 4th+ is spawned inside 
    }
}
