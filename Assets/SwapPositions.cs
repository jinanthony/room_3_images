using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPositions : MonoBehaviour
{
    public GameObject[] gameObjects; // Array to store the GameObjects
    public KeyCode swapKey = KeyCode.Space; // Key to trigger the swapping
    public UnityEngine.UI.Button swapButton; // Button to trigger the swapping

    void InitializeSwapButton(){
        if(swapButton != null){
            swapButton.onClick.AddListener(Swap);
        }
        else{
            Debug.LogWarning("Swap Button is not assigned.");
        }
    }

    void Start()
    {
        InitializeSwapButton(); // Assigning Swap method to the button click event
    }

    void Swap()
    {
        Debug.LogWarning("Swap Button is in.");

        List<Vector3> positions = new List<Vector3>(); // List to store positions of GameObjects
        foreach (GameObject obj in gameObjects)
        {
            positions.Add(obj.transform.position); // Adding current positions to the list
        }

        // Shuffle the positions randomly
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 temp = positions[i];
            int randomIndex = Random.Range(i, positions.Count);
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp; 
        }

        // Assign new positions to the GameObjects
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].transform.position = positions[i];
        }
    }
}

