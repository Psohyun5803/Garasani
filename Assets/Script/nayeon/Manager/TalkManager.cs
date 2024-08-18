using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instacne;
    public GameObject ui_dialogue;

    private void Awake()
    {
        if (instacne == null)
        {
            instacne = this;
        }
    }
    public void onClickNext()
    {
        if(DialogueManager.instance.name.text == "System")
            ui_dialogue.SetActive(false);
    }

    public IEnumerator isMove(string dest, string sceneName)
    {
        
        DialogueManager.instance.name.text = "System";
        DialogueManager.instance.dialogue_text.text = dest + "(으)로 이동할까?";
        DialogueManager.instance.chosen1_text.text = "이동한다.";
        DialogueManager.instance.chosen2_text.text = "이동하지 않는다.";
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        Debug.Log("chooseFlag: "+DialogueManager.instance.chooseFlag);
        if (DialogueManager.instance.chooseFlag == 1)
            SceneManager.LoadScene(sceneName);
        else if (DialogueManager.instance.chooseFlag == 2)
            DialogueManager.instance.ui_dialogue.SetActive(false);
        DialogueManager.instance.chooseFlag = 0;
    }

}
