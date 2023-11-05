using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] float startWaitTime;
    public bool IsAround;
    [SerializeField] float AroundSpeed = 10f;
    [SerializeField] float AroundAngleSpeed = 0.5f;
    Vector3 target;
    Animator animator;
    RandMove randMove;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
        randMove = GetComponent<RandMove>();
        GameManager.Instance.touchpointIndex = Random.Range(0, GameManager.Instance.touchpointIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
       if (IsAround)//������ ���� ������
        {
            randMove.IsTouch = true;
            MakingAroundSpot();//��ġ����Ʈ ����Ʈ�� �ε����� ��������
            AroundMove();//ȸ���� ������
            animator.SetBool("Sprint", true);
            if (Vector3.Distance(transform.position, GameManager.Instance.Touchpoints[GameManager.Instance.touchpointIndex].GetComponent<Transform>().position) < 0.2f)
            {                
                if (waitTime <= 0)
                {
                    MakingAroundSpot();//�������� �����Ұ� ����
                    IsAround = true; //������ Ȱ��ȭ
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
    }
    public void MakingAroundSpot()
    {
        GameManager.Instance.touchpointIndex = Random.Range(0, GameManager.Instance.touchpointIndex); //��ġ����Ʈ ����Ʈ�� �ε����� ��������
    }
    public void AroundMove()
    {
        target = GameManager.Instance.Touchpoints[GameManager.Instance.touchpointIndex].GetComponent<Transform>().position - transform.position;
        //������ ��ġ����Ʈ�� ���� ���⺤��

        //��ġ����Ʈ �����ϰ� ����
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Touchpoints[GameManager.Instance.touchpointIndex].GetComponent<Transform>().position,
        AroundSpeed * Time.deltaTime); //������ ��ġ����Ʈ�� �̵�

        //��ġ����Ʈ�� ���� ȸ��
        Quaternion AroundAngle = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, AroundAngle, AroundAngleSpeed * Time.deltaTime);
    }
}
