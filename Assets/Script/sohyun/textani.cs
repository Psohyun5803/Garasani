using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;
public class textani : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public float delay = 0.1f;
    private string fullText;
    private string currentText = "";
    private Coroutine typingCoroutine;
    public static Action npconClickAction;
    void Start()
    {
       
        npconClickAction = ()=> { npcClick(); };
        fullText = tmpText.text;
        tmpText.text = "";
        typingCoroutine =StartCoroutine(ShowText(fullText));
    }
    
    public void Onclick()
    {
        if(npc.buttonnum!=0) //대화가 종료되었을시 재출력 방지
        {
            string nextText = tmpText.text;
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

        
            tmpText.text = "";
            typingCoroutine = StartCoroutine(ShowText(nextText));
        }
       
    }
    public void npcClick()
    {
        if (npc.buttonnum == 0) //npc를 눌러서 새 대화가 시작된다면
        {
            string nextText = tmpText.text;
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

           
            tmpText.text = "";
            typingCoroutine = StartCoroutine(ShowText(nextText));
        }
    }

    IEnumerator ShowText(string fullText)
    {
        
            string currentText = "";
            for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i + 1);
                tmpText.text = currentText;
                yield return new WaitForSeconds(delay);
            }
        
    }

}
