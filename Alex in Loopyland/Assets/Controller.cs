using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Capstone;

public class Controller : MonoBehaviour
{
    public Transform transform;
    // Varaibles to save
    private float xx;
    private float yy; 
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // CLICK P TO SAVE YOUR COORDINATES
        if(Input.GetKeyDown(KeyCode.P)){
            // Instead of my name, insert your name that goes after \\ Users 
            // SHould just create a file
            // I'll be working on debuugging in loading. 
            // CLICK P TO save 
            Save inputData = new Save("C:\\Users\\Arath Penca\\Desktop\\Testing.txt");
    
            inputData.setElement("Coorid", "x", transform.position.x);
            inputData.setElement("Coorid", "y", transform.position.y);
            inputData.Close();
        }


        // CLICK U TO TELEPORT TO SAVED COORDINATES
        if(Input.GetKeyDown(KeyCode.U)){
            Load outputData = new Load("C:\\Users\\Arath Penca\\Desktop\\Testing.txt");

            float xx = outputData.getElement("Coorid", "x", 3.0f);
            float yy = outputData.getElement("Coorid", "y", 5.0f);
            Debug.Log(xx);
            Debug.Log(yy);
            transform.position = new Vector3(xx, yy, transform.position.z);
        }
    }
}
