using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
   [SerializeField] float moveSpeed = 10f;
   [SerializeField] float upSpeed = 100f;
   [SerializeField] float rotateSpeed = 10f;
   [SerializeField] float waitTime = 2f;
   [SerializeField] GameObject upmove;
    public bool ShoudMove = false;
    public bool ShouldAttack = false;
    private MoveAround moveAround;

    Animator animator;
    ParticleSystem Swim;
    GameObject punisher;

    // Start is called before the first frame update
    void Start()
    {
        moveAround = GetComponent<MoveAround>();
        animator = GetComponent<Animator>();
        punisher =GameManager.Instance.Touchpoints[GameManager.Instance.TouchpointIndex];//�й��� ����
        upmove = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (ShoudMove) // �������� true �϶� ����
        {
            if (Input.GetMouseButtonDown(0))
            {
                moveAround.IsAround = false;//�����̵�����
                                            //���� �ִϸ��̼� ����
                animator.SetBool("Sprint", true);
                //���� �ִϸ��̼� ����
                animator.SetBool("Attack", false);
                //�Ǿ ���ƾ��� ������ targetRotation �� ����
                Quaternion targetRotation = Quaternion.LookRotation(punisher.transform.position - transform.position);
                //ȸ���� ������ �ϰ� targetRotation �������� �� 
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
                //�������� ����Ʈ�� ��ġ�� �̵�
                transform.position = Vector3.MoveTowards(transform.position, punisher.transform.position, moveSpeed * Time.deltaTime);
                //���� ��Ȱ��ȭ
                ShouldAttack = false;
                //����Ʈ�� ��ġ�� 0.2f���� ����� ���� 
                if (Vector3.Distance(transform.position, punisher.transform.position) <= 0.2f)
                {
                    ShoudMove = false; //������ ����
                    animator.SetBool("Sprint", false);//�̵� �ִϸ��̼� ����
                    ShouldAttack = true;//���� ����              
                }
                if (ShouldAttack)
                {
                    StartCoroutine(attack());
                    //���� �ִϸ��̼� ���                             
                }
            }
            
        }
    }
    IEnumerator attack()
    {
        Swim.Stop();
        transform.Rotate(new Vector3(-90, 0, 0) * 0.8f);
        transform.position = Vector3.MoveTowards(transform.position, upmove.transform.position, upSpeed); //ī�޶� �������� �̵��ϰ� �ؼ� �ִ��� �ְ� ����
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1.4f); // 1�ʴ��
        animator.SetBool("Attack", false);
        transform.position = new Vector3(transform.position.x, 12, transform.position.z);
        transform.Rotate(new Vector3(90, 0, 0) * 0.8f);
        Swim.Play();
    }

    void OnAttackReady()
    {
        animator.SetFloat("AttackSpeed", 1.5f);
    }
    void OnAttack()
    {
        animator.SetFloat("AttackSpeed", 2f);
    }
}
