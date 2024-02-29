using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestinationManager : MonoBehaviour
{
    [SerializeField] Text destinationText;
    private string[] destinations = {"���_�޳�","�߹A�j��", "�׻��j��" };
    private string[] des_scene = { "PE class", "japanese class", "english class" };
    private int currentDestinationIndex = 0; // �ثe���ت��a����

    [SerializeField] GameObject PEclass;
    [SerializeField] GameObject JPclass;
    [SerializeField] GameObject ENGclass;

    void Start()
    {
        if (destinations.Length > 0)
        {
            // ��ܲĤ@�ӥت��a
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
        // �p�G�ثe���ت��a���ޤp��ت��a���`�ơA��ܤU�@�ӥت��a
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
        destinationText.text = "�A���U��Ҧ��" + destination;
    }
}
