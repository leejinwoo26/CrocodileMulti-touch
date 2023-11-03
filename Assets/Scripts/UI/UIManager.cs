using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region �̱��� �ν��Ͻ�
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
    #region ������
  

    //�ο� ���� ����
    public int value = 2;

    //�г� on off Ȯ�� ����
    public bool isOpenPnl = false;

 

    #endregion
    #region �̱��� Ȱ�� �Լ���
     
    public void ActivePnl(GameObject pnl)
    {
        isOpenPnl = !pnl.activeSelf;
        pnl.SetActive(isOpenPnl);

    }

    public void OnClickExit()
    {
        Application.Quit();
    }
    #endregion





}



