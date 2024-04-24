using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.EventSystems;

public class ClickAndButtonRecorder : MonoBehaviour
{
    // List to store clicked GameObject names for each round
    private List<Dictionary<string, string>> roundsData = new List<Dictionary<string, string>>();

    // Counter to keep track of the current round
    private int currentRound = 0;

    void Start()
    {
        //Get the path of the Game data folder
        string path = Path.Combine(Application.persistentDataPath, "onClickData.json");

        //Output the Game data path to the console
        Debug.Log("dataPath : " + path);
    }

    // Function called when a GameObject is clicked
    public void OnMouseDown()
    {
        // Check if the clicked object is not part of UI
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Get the name of the clicked GameObject
            string clickedObjectName = gameObject.name;

            // Create a new dictionary for the current round if it doesn't exist
            if (roundsData.Count <= currentRound)
            {
                roundsData.Add(new Dictionary<string, string>());
            }

            // Add the clicked object name to the current round's dictionary
            roundsData[currentRound].Add("round" + (currentRound + 1), clickedObjectName);

            // Convert roundsData list to JSON format
            string jsonData = JsonUtility.ToJson(new { employees = roundsData }, true);
            Debug.Log("jsonData: " + jsonData);

            string path = Path.Combine(Application.persistentDataPath, "gameData.json");

            // Write JSON data to file
            File.WriteAllText(path, jsonData);

            Debug.Log("Clicked object name: " + clickedObjectName);
        }
    }

    // Function called when the button is clicked
    public void OnButtonClick()
    {
        // Increment the current round
        currentRound++;

        Debug.Log("Current Round: " + (currentRound + 1));
    }
}