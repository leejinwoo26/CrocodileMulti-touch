using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        // ���� ���� ������Ʈ�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(this.gameObject);
    }
}
