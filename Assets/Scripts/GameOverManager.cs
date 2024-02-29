using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject bumpIntoEventText;
    private GameObject newTextObject;
    [SerializeField] Text TimeText;

    void Start()
    {
        int isFallIntoWater = PlayerPrefs.GetInt("IsFallIntoWater", 0);
        int isTwoOneDoor = PlayerPrefs.GetInt("IsTwoOneDoor", 0);
        int isHeartZero = PlayerPrefs.GetInt("IsHeartZero", 0);
        int isDrunk = PlayerPrefs.GetInt("IsDrunk", 0);
        int isUnderGround = PlayerPrefs.GetInt("IsUnderGround", 0);
        if (isFallIntoWater == 1)
        {
           
                // Instantiate the Text prefab
                newTextObject = Instantiate(bumpIntoEventText, Vector3.zero, Quaternion.identity);

                // Set the parent of the new text object to be the Canvas (or another UI element)
                newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

                // Access the RectTransform component on the instantiated object
                RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

                // Access the Text component on the instantiated object
                Text newTextComponent = newTextObject.GetComponent<Text>();

                if (newTextTransform != null && newTextComponent != null)
                {
                    // Customize the RectTransform properties
                    newTextTransform.anchoredPosition = new Vector2(0f, -20f);  // Set anchored position
                    newTextTransform.sizeDelta = new Vector2(600f, 150f);  // Set size

                    // Customize the text properties
                    newTextComponent.text = "掉進水裡囉~";
                    newTextComponent.fontSize = 80;
                    newTextComponent.fontStyle = FontStyle.Bold;
                    newTextComponent.color = Color.yellow;
                }


                Debug.Log("掉進水中！");

        }

        else if (isTwoOneDoor == 1)
        {

            // Instantiate the Text prefab
            newTextObject = Instantiate(bumpIntoEventText, Vector3.zero, Quaternion.identity);

            // Set the parent of the new text object to be the Canvas (or another UI element)
            newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

            // Access the RectTransform component on the instantiated object
            RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

            // Access the Text component on the instantiated object
            Text newTextComponent = newTextObject.GetComponent<Text>();

            if (newTextTransform != null && newTextComponent != null)
            {
                // Customize the RectTransform properties
                newTextTransform.anchoredPosition = new Vector2(0f, -20f);  // Set anchored position
                newTextTransform.sizeDelta = new Vector2(800f, 150f);  // Set size

                // Customize the text properties
                newTextComponent.text = "穿過二一門! 退學吧你";
                newTextComponent.fontSize = 60;
                newTextComponent.fontStyle = FontStyle.Bold;
                newTextComponent.color = Color.yellow;
            }


            Debug.Log("穿過二一門！");

        }

        else if(isHeartZero == 1)
        {
            // Instantiate the Text prefab
            newTextObject = Instantiate(bumpIntoEventText, Vector3.zero, Quaternion.identity);

            // Set the parent of the new text object to be the Canvas (or another UI element)
            newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

            // Access the RectTransform component on the instantiated object
            RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

            // Access the Text component on the instantiated object
            Text newTextComponent = newTextObject.GetComponent<Text>();

            if (newTextTransform != null && newTextComponent != null)
            {
                // Customize the RectTransform properties
                newTextTransform.anchoredPosition = new Vector2(0f, -20f);  // Set anchored position
                newTextTransform.sizeDelta = new Vector2(600f, 150f);  // Set size

                // Customize the text properties
                newTextComponent.text = "心心被扣完啦~";
                newTextComponent.fontSize = 80;
                newTextComponent.fontStyle = FontStyle.Bold;
                newTextComponent.color = Color.yellow;
            }


            Debug.Log("心心==0！");

        }

        else if (isDrunk == 1)
        {
            // Instantiate the Text prefab
            newTextObject = Instantiate(bumpIntoEventText, Vector3.zero, Quaternion.identity);

            // Set the parent of the new text object to be the Canvas (or another UI element)
            newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

            // Access the RectTransform component on the instantiated object
            RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

            // Access the Text component on the instantiated object
            Text newTextComponent = newTextObject.GetComponent<Text>();

            if (newTextTransform != null && newTextComponent != null)
            {
                // Customize the RectTransform properties
                newTextTransform.anchoredPosition = new Vector2(0f, -20f);  // Set anchored position
                newTextTransform.sizeDelta = new Vector2(600f, 150f);  // Set size

                // Customize the text properties
                newTextComponent.text = "再喝酒阿!";
                newTextComponent.fontSize = 80;
                newTextComponent.fontStyle = FontStyle.Bold;
                newTextComponent.color = Color.blue;
            }


            Debug.Log("喝酒BAD");

        }

        else if (isUnderGround == 1)
        {
            // Instantiate the Text prefab
            newTextObject = Instantiate(bumpIntoEventText, Vector3.zero, Quaternion.identity);

            // Set the parent of the new text object to be the Canvas (or another UI element)
            newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

            // Access the RectTransform component on the instantiated object
            RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

            // Access the Text component on the instantiated object
            Text newTextComponent = newTextObject.GetComponent<Text>();

            if (newTextTransform != null && newTextComponent != null)
            {
                // Customize the RectTransform properties
                newTextTransform.anchoredPosition = new Vector2(0f, -20f);  // Set anchored position
                newTextTransform.sizeDelta = new Vector2(600f, 150f);  // Set size

                // Customize the text properties
                newTextComponent.text = "走路看路阿!";
                newTextComponent.fontSize = 80;
                newTextComponent.fontStyle = FontStyle.Bold;
                newTextComponent.color = Color.blue;
            }


            Debug.Log("555");

        }
    }



}
