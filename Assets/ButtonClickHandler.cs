using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ButtonClickHandler : MonoBehaviour
{
    private int roundNumber = 1;
    private List<ButtonData> buttonDataList = new List<ButtonData>();

    [System.Serializable]
    public class ButtonData
    {
        public int roundNumber;
        public string buttonName;

        public ButtonData(int roundNumber, string buttonName)
        {
            this.roundNumber = roundNumber;
            this.buttonName = buttonName;
        }
    }

    public void OnIMGClick(string buttonName)
    {
        // Store button data
        buttonDataList.Add(new ButtonData(roundNumber, buttonName));

        // Write to JSON file
        SaveButtonDataToJson();

        Debug.Log("Button name '" + buttonName + "' has been stored for round " + roundNumber);
    }

    public void IncrementRoundNumber()
    {
        roundNumber++;
        Debug.Log("Round number incremented to " + roundNumber);
    }

    private void SaveButtonDataToJson()
    {
        string jsonData = JsonUtility.ToJson(buttonDataList.ToArray(), true);
        File.WriteAllText(Application.persistentDataPath + "/buttonData.json", jsonData);
    }
}
