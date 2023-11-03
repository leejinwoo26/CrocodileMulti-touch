using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{

    public GameObject pnlTouchAgain;
    public Text txtGameStart;
    public Button testbtn;

    //���Ӿ� ī��Ʈ�ٿ� ����
    float countdownTime = 5f;


    private void Start()
    {
        txtGameStart.gameObject.SetActive(true);
        StartCoroutine(Countdown());
 
    }
    private void Update()
    {
        //TouchAgain �Լ� �� �۵��ϴ��� �׽�Ʈ��
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TocuhAgain();
            
        }
    }


    public IEnumerator Countdown()
    {
        countdownTime = 5f;
        txtGameStart.gameObject.SetActive(true);
        while (countdownTime > 0)
        {
            txtGameStart.text = "TOUCH ALL OF THEM IN " + Mathf.Ceil(countdownTime) + " SECONDS !";
            countdownTime -= Time.deltaTime;
            yield return null;
        }

        txtGameStart.gameObject.SetActive(false);
    }

    public void TocuhAgain()
    {
        pnlTouchAgain.SetActive(true); // Panel�� Ȱ��ȭ

        // 2�� �ڿ� ��Ȱ��ȭ
        StartCoroutine(DeactivatePanelAfterDelay(2f));
      
    }

    // ���� �ð��� ���� �� Panel�� ��Ȱ��ȭ�ϴ� �ڷ�ƾ
    private IEnumerator DeactivatePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(2f); // ������ �ð���ŭ ���

        pnlTouchAgain.SetActive(false); // Panel�� ��Ȱ��ȭ

        // 2�ʰ� ���� �� Countdown �Լ� ȣ��
        StartCoroutine(Countdown());
    }

    public void DeActivePnl()
    {
        pnlTouchAgain.gameObject.SetActive(false);
    }

}
