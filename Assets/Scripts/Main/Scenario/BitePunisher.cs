using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BitePunisher : ScenarioBase
{
    GameUIManager gameUIManager;
    GameObject crocodile;
    GameObject punisher;

    [SerializeField] float hSliderValueR = 0.0F;
    [SerializeField] float hSliderValueG = 0.0F;
    [SerializeField] float hSliderValueB = 0.0F;
    [SerializeField] float hSliderValueA = 1.0F;

    public override void Enter(ScenarioController controller)
    {
        crocodile = FindObjectOfType<RandMove>().gameObject;
        crocodile.GetComponent<MoveAround>().enabled = false;
        crocodile.GetComponent<TouchScreen>().enabled = true;

        punisher = GameManager.Instance.Touchpoints[GameManager.Instance.PunisherIndex];
        // ��Ģ�� ���� UI Ȱ��ȭ
        StartCoroutine(ShowPunisherUI());
        
        //controller.SetNextScenario();
    }

    public override void Execute(ScenarioController controller)
    {
    }

    public override void Exit()
    {
    }

    IEnumerator ShowPunisherUI()
    {
        ParticleSystem particle = punisher.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mainModule = particle.main;

        // �Ǿ ���� �ö�� �� ��Ģ�� ��ġ����Ʈ�� ȿ�� �ֱ� ����
        while(crocodile.transform.position.y < 13f)
        {
            yield return null;
        }
        mainModule.startColor = new Color(1f, 0f, 0f);

        // �Ǿ ��Ģ�ڿ��� �̵��ϰ� ���� �ö���� �ð��� 5�� ��
        yield return new WaitForSeconds(5f);

        // ��Ģ�ڰ� �����Ǿ��ٴ� UI�� ���
        //gameUIManager = FindObjectOfType<GameUIManager>();
        //gameUIManager.BittenPay();

        // 5�� �� Ÿ��Ʋ������ ��ȯ
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End");
    }
}
