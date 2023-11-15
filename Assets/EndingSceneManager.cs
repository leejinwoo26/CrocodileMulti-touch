using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndingSceneManager : MonoBehaviour
{
    public Text txtWait;

    void Start()
    {
        StartCoroutine(Countdown());
        // 5�� �Ŀ� Ÿ��Ʋ ������ ��ȯ
        Invoke("LoadTitleScene", 5f);
    }

    // Ÿ��Ʋ ������ ��ȯ�ϴ� �޼���
    void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
        SoundManager.Instance.SwapBGMClip(0);
        UIManager.Instance.value = 2;
    }

    public IEnumerator Countdown()
    {
        //���Ӿ� ī��Ʈ�ٿ� ����
        float countdownTime = 5f;

        txtWait.gameObject.SetActive(true);
        while (countdownTime > 0)
        {
            txtWait.text = "PLEASE WAIT FOR " + Mathf.Ceil(countdownTime) + " SECONDS...";
            countdownTime -= Time.deltaTime;
            yield return null;
        }

        txtWait.gameObject.SetActive(false);
    }
}
