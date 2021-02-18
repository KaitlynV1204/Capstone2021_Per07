using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ATTACH THIS SCRIPT TO THE CANVAS (WHICH WILL BE NECESSARY TO USE BUTTON PREFABS IN LEVELS). ENSURE BUTTONS ARE CHILDED TO CANVAS FROM THE START.

public class Buttons : MonoBehaviour
{

    [SerializeField]
    GameObject optionsPanel;
    bool panelOpen;

    void Start()
    {
        panelOpen = false;
    }

    void Update()
    {
        if(panelOpen == false)
            optionsPanel.SetActive(false);

        if (panelOpen == true)
            optionsPanel.SetActive(true);

        if(Input.GetKeyUp(KeyCode.Escape) && panelOpen == false)
        {
            optionsPanel.SetActive(true);
            panelOpen = true;
        }

        if(Input.GetKeyUp(KeyCode.Escape) && panelOpen == true)
        {
            optionsPanel.SetActive(false);
            panelOpen = false;
        }


    }

    //Play - Goes in menu
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Menu - Goes in each scene
    public void Menu()
    {
        SceneManager.LoadScene(0); //Menu should be the first in the index,
    }

    //Quit - Goes in menu
    public void Quit()
    {
        Application.Quit();
    }

    //Restart - Goes in each scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
