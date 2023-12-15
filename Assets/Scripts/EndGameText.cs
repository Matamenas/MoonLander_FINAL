using UnityEngine;
using TMPro;
using System.Collections;

public class SelfWritingText : MonoBehaviour
{
    public float typingSpeed = 0.05f; 
    public string fullText = "Text Here";

    private TextMeshProUGUI displayText;
    private string currentText = "";

    void Start()
    {
        displayText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            displayText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
