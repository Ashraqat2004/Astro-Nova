using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HideTextAfterTime : MonoBehaviour
{
    public GameObject textObject; // Assign your Text GameObject here
    public float delay = 3f; // Time in seconds before the text disappears

    void Start()
    {
        if (textObject != null)
        {
            // Start the coroutine to hide the text
            StartCoroutine(HideText());
        }
        else
        {
            Debug.LogError("Text Object is not assigned in the Inspector.");
        }
    }

    private IEnumerator HideText()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Disable the text object
        textObject.SetActive(false);
    }
}
