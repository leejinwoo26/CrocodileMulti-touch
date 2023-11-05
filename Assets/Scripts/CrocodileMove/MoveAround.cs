using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] float startWaitTime;
    [SerializeField] float AroundSpeed = 10f;
    [SerializeField] float AroundAngleSpeed = 0.5f;
    Vector3 target;
    Animator animator;
    int randomPositionIndex;

    void Start()
    {
        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
        MakingAroundSpot();
    }

    void Update()
    {
        AroundMove();//ȸ���� ������
        animator.SetBool("Sprint", true);
        float dis = Vector3.Distance(transform.position, GameManager.Instance.Touchpoints[randomPositionIndex].transform.position);
        if (dis < 0.2f)
        {
            if (waitTime <= 0)
            {
                MakingAroundSpot();//�������� �����Ұ� ����
                waitTime = Random.Range(0, 2f);
                startWaitTime = waitTime;
            }
            else
            {
                animator.SetBool("Sprint", false);
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void MakingAroundSpot()
    {
        Debug.Log("��������Ʈ ��ġ : " + randomPositionIndex);
        randomPositionIndex = Random.Range(0, GameManager.Instance.Touchpoints.Count); //��ġ����Ʈ ����Ʈ�� �ε����� ��������
    }

    public void AroundMove()
    {
        target = GameManager.Instance.Touchpoints[randomPositionIndex].GetComponent<Transform>().position - transform.position;
        //������ ��ġ����Ʈ�� ���� ���⺤��

        //��ġ����Ʈ �����ϰ� ����
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Touchpoints[randomPositionIndex].GetComponent<Transform>().position,
        AroundSpeed * Time.deltaTime); //������ ��ġ����Ʈ�� �̵�

        //��ġ����Ʈ�� ���� ȸ��
        Quaternion AroundAngle = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, AroundAngle, AroundAngleSpeed * Time.deltaTime);
    }
}
