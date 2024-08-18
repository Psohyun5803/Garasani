using UnityEngine;
using TMPro;
using System.Collections;

public class textani : MonoBehaviour
{
    
        public TMP_Text tmpText;
        public float delay = 0.1f;
        private string fullText;
        private string currentText = "";

        void Start()
        {
            fullText = tmpText.text;
            tmpText.text = "";
            StartCoroutine(ShowText());
        }
        public void textanimation()
        {
            fullText = tmpText.text;
            tmpText.text = "";
            StartCoroutine(ShowText());
        }
        IEnumerator ShowText()
        {
            for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i + 1);
                tmpText.text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }
    
}
