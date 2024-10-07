using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{


    public GameObject floorPrefab;
    public float speed = 1;


    //TODO: Use Game's variable directly!
    // Amount of other active floors! 
    public float activeFloors = 4;

   // public Game game;
    // Start is called before the first frame update
    void Start()
    {
        activeFloors = GameObject.Find("Game").GetComponent<Game>().floorCount;
        //game = 
        //levelGenerator = levelGeneratorObject.GetComponent<LevelGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Use Deltatime!
        // Move towards -z
        this.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

        // Reset if too far away
        if (this.transform.position.z <= -10)
        {
            this.transform.position = new Vector3(0, 0, (activeFloors-1)*10);
        }
        // TODO: Object Pooling. If object.z < -10: object.z = 10
        // Reuse Objects by resetting them
    }

    // Player enters trigger zone and causes new floor to spawn

    public void stop(){
        print("stop");
        speed = 0;
    }
    public void setActiveFloors(int floors){
        activeFloors = floors;
    }

}
