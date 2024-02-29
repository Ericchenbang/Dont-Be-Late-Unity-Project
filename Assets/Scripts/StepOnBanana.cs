using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepOnBanana : MonoBehaviour
{

    private bool isBananaEffectActive = false;
    private float bananaEffectDuration = 10f;

    [SerializeField] GameObject bananaText;
    private GameObject newTextObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Banana"))
        {
            Destroy(other.gameObject);
            isBananaEffectActive = true;
            StartCoroutine(DisableBananaEffect());

            // Instantiate the Text prefab
            newTextObject = Instantiate(bananaText, Vector3.zero, Quaternion.identity);

            // Set the parent of the new text object to be the Canvas (or another UI element)
            newTextObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

            // Access the RectTransform component on the instantiated object
            RectTransform newTextTransform = newTextObject.GetComponent<RectTransform>();

            // Access the Text component on the instantiated object
            Text newTextComponent = newTextObject.GetComponent<Text>();

            if (newTextTransform != null && newTextComponent != null)
            {
                // Customize the RectTransform properties
                newTextTransform.anchoredPosition = new Vector2(0f, -460f);  // Set anchored position
                newTextTransform.sizeDelta = new Vector2(600f, 150f);  // Set size

                // Customize the text properties
                newTextComponent.text = "You slipped on a banana! Wait 10 sec to recovery!";
                newTextComponent.fontSize = 45;
                newTextComponent.fontStyle = FontStyle.Bold;
                newTextComponent.color = Color.red;
            }
            else
            {
                Debug.LogError("Text component not found on the instantiated object.");
            }
        }
    }

    IEnumerator DisableBananaEffect()
    {
        yield return new WaitForSeconds(bananaEffectDuration);
        isBananaEffectActive = false;
        //bananaEffectTimer = 0f;
        Destroy(newTextObject);
    }

    public bool IsBananaEffectActive()
    {
        return isBananaEffectActive;
    }
}
