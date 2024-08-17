using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SNS_ChungmuroB2 : MonoBehaviour
{
    public static SNS_ChungmuroB2 instance;

    //충무로B2 트윗
    public GameObject ch_climing;
    public GameObject ch_rising;
    public GameObject ch_movie;
    public GameObject ch_line4_1;
    public GameObject ch_line4_2;
    public GameObject ch_line4_3;
    public GameObject ch_line4_4;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        ch_climing.SetActive(true);
        ch_movie.SetActive(true);
        ch_rising.SetActive(true);

        ch_line4_1.SetActive(false);
        ch_line4_2.SetActive(false);
        ch_line4_3.SetActive(false);
        ch_line4_4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inSubway_0.instance.dialogueID == 20)
        {
            ch_line4_1.SetActive(true);
            ch_line4_2.SetActive(true);
            ch_line4_3.SetActive(true);
            ch_line4_4.SetActive(true);
        }
    }
}
