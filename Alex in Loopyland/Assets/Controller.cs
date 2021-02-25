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
    }
}
