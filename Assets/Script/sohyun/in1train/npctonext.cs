using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npctonext : MonoBehaviour //npc�� ��ȭ�� �� ��ġ�� ��ĭ���� �̵��ϰ��� 
{
    public int firstflag=0;
    public Transform target;

    // �̵� �ӵ�
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name=="�����")
        {
            if (firstflag == 0 && NPCManager.jobflag == 1)
            {
                firstflag = 1;
                StartCoroutine(move(target.position));


            }
        }

        if (gameObject.name=="���̺�")
        {
            if (firstflag == 0 && NPCManager.godflag == 1)
            {
                firstflag = 1;
                StartCoroutine(move(target.position));


            }
        }


    }

    public IEnumerator move(Vector3 targetPosition)
    {
        // ���� ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.1���� Ŭ ���� ��� �̵�
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // ���� ��ġ���� ��ǥ ��ġ�� �� ������ ���ݾ� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // ���� �������� ��ٸ�
            yield return null;
        }

        // ������ �� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
        transform.position = targetPosition;
        gameObject.SetActive(false);
    }
   
}
