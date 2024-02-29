using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestinationManager : MonoBehaviour
{
    [SerializeField] Text destinationText;
    private string[] destinations = {"光復操場","唯農大樓", "修齊大樓" };
    private string[] des_scene = { "PE class", "japanese class", "english class" };
    private int currentDestinationIndex = 0; // 目前的目的地索引

    [SerializeField] GameObject PEclass;
    [SerializeField] GameObject JPclass;
    [SerializeField] GameObject ENGclass;

    void Start()
    {
        if (destinations.Length > 0)
        {
            // 顯示第一個目的地
            ShowDestinationText(destinations[0]);
        }
        else
        {
            Debug.LogError("No destinations set!");
        }
    }

    void OnEnable()
    {
        DestinationTrigger.OnDestinationReached += ShowNextDestination;
        Debug.Log("Subscribed to OnDestinationReached event");
    }

    void OnDisable()
    {
        DestinationTrigger.OnDestinationReached -= ShowNextDestination;
    }

    void ShowNextDestination()
    {
        // 如果目前的目的地索引小於目的地的總數，顯示下一個目的地
        if (currentDestinationIndex < destinations.Length)
        {
            Debug.Log("Current Destination Index: " + currentDestinationIndex);

            
            if (currentDestinationIndex == 0)
            {
                PEclass.SetActive(true);
            }
            else if (currentDestinationIndex == 1)
            {
                JPclass.SetActive(true);
            }
            else if (currentDestinationIndex == 2)
            {
                ENGclass.SetActive(true);
            }

            currentDestinationIndex++;
            Debug.Log("Next Destination: " + destinations[currentDestinationIndex]);

            ShowDestinationText(destinations[currentDestinationIndex]);
            

  
        }
        else
        {
            //SceneManager.LoadScene("WinScene");
        }
    }

    void ShowDestinationText(string destination)
    {
        destinationText.text = "你的下堂課位於" + destination;
    }
}
