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

public class tutorial2 : MonoBehaviour
{
    public GameObject talksqu;
    private IEnumerator darkandlight;
    public GameObject button;
    public GameObject dark;
    public TMP_Text content;
    public TMP_Text who;
    public static int textflag = 0;
    public GameObject door;
    public static int doorflag = 0;

    [SerializeField] private GameObject targetAnimatorObject;
    public float moveSpeed = 5f;
    public string boolParameterName = "Left";
    private Animator NPCAnimator;

    string[] text = new string[4] {  "...?", "...�̰� ���� �Ҹ���...?", "���ʿ��� ���� �ٰ����� �־�...", "...!" };
    // Start is called before the first frame update
    void Start()
    {
        if (targetAnimatorObject != null)
        {
            NPCAnimator = targetAnimatorObject.GetComponent<Animator>();
            NPCAnimator.SetBool(boolParameterName, false);
        }
        else
        {
            Debug.LogError("Target animator object not assigned.");
        }

        Vector3 newposition = door.transform.position;
        Player.playertrans(newposition.x+3, newposition.y);
        talksqu.SetActive(false);
        who.text = customize.playername;
        content.text = text[textflag];
        Invoke("dontmove", 1f);
        darkandlight = ����();
    }
    private IEnumerator ����()
    {
        while (true)
        {
            dark.SetActive(true);
            yield return new WaitForSeconds(5f);
            dark.SetActive(false);
            yield return new WaitForSeconds(5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(darkandlight);
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                
                GameObject clickobj = hit.transform.gameObject;
                if (clickobj.name == "�������̹�")
                {
                    talksqu.SetActive(true);
                    who.text = "System";
                    content.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";
                    textflag++;

                    //SceneManager.LoadScene("Dialogue");
                }
            }
        }
    }
    
    public void doordown()
    {
        Debug.Log("Ŭ����");
        if (doorflag==0)
        {
            
            talksqu.SetActive(true);
            who.text = "System";
            content.text = "���𰡿� �ɸ��� ���� ������ �ʴ´�.";
            textflag++;
            doorflag++;
        }
    }
   
    public void buttondown()
    {
        if (textflag == 0)
        {
            textflag++;
        }
        else if (textflag <= 1)
        {
            who.text = customize.playername;
            content.text = text[textflag];
            textflag++;

        }
        else if (textflag == 2)
        {
            who.text = customize.playername;
            content.text = text[textflag];
            //customize.moveflag = 1;
            //talksqu.SetActive(false);
            textflag++;
        }
        else if (textflag == 3 && doorflag ==0)
        {
            talksqu.SetActive(false);
        }
        else if (textflag==4 && doorflag==1)
        {

            Debug.Log("������");
            
            talksqu.SetActive(true);
            who.text = customize.playername;
            content.text = text[3];
            textflag++;
        }

        else if (textflag > 4)
        {
            talksqu.SetActive(false);
            StartCoroutine(NPCEventCoroutine());
            //SceneManager.LoadScene("Prologue2");

        }
    }

    IEnumerator NPCEventCoroutine()
    {
        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, true);
        }

        float targetXPosition = -6.0f; // ��ǥ X ��ǥ
        float moveDuration = 2.0f; // �̵��� �ð�

        Vector3 startPosition = targetAnimatorObject.transform.position;
        Vector3 targetPosition = new Vector3(targetXPosition, startPosition.y, startPosition.z);
        float elapsedTime = 0f;

        Debug.Log($"Starting NPC movement from {startPosition} to {targetPosition}");

        while (elapsedTime < moveDuration)
        {
            targetAnimatorObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            Debug.Log($"NPC position: {targetAnimatorObject.transform.position}");
            yield return null;
        }

        targetAnimatorObject.transform.position = targetPosition; // Ensure it ends at the exact position

        Debug.Log($"NPC movement ended at {targetAnimatorObject.transform.position}");

        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, false);
        }
    }

    void dontmove()
    {
        customize.moveflag = 0;
        talksqu.SetActive(true);

    }
}
