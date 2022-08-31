using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroText : MonoBehaviour
{
    public float charDelay = 0.05f;
    string fullText;
    string currentText;

    public GameObject button;
    public GameObject skip;
    // Start is called before the first frame update
    void Start()
    {
        fullText = GetComponent<Text>().text;
        StartCoroutine("TextEffect");
    }


    private IEnumerator TextEffect()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(charDelay);

            if (i == fullText.Length - 1)
            {
                button.SetActive(true);
                skip.SetActive(false);
            }
        }

        
    }
}
