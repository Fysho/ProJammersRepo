using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneCommands : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Starting the game!");
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);

    }

}
