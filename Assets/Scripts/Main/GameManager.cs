using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    private List<GameObject> touchpoints;
    public int punisherIndex;

    public List<GameObject> Touchpoints
    {
        get { return touchpoints; }
        set { touchpoints = value; }
    }

    public int PunisherIndex
    {
        get { return punisherIndex; }
        set { punisherIndex = value; }
    }

    private void Awake()
    {
        // �ν��Ͻ��� �̹� �����ϴ� ���, ���� ����� �ν��Ͻ� ����
        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }

        // �ν��Ͻ��� ���� ������Ʈ�� ����
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void ClearTouchpoints()
    {
        if(touchpoints != null)
        {
            // ��ġ����Ʈ ���� ������Ʈ ����
            foreach(GameObject touchpoint in touchpoints)
            {
                Destroy(touchpoint);
            }

            // ī��Ʈ�ٿ� UI ���� ���� GameUIManager���� ����

            // ��ġ����Ʈ ����Ʈ �ʱ�ȭ
            touchpoints.Clear();
        }
    }

}
