using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectPunisher : ScenarioBase
{
    public override void Enter(ScenarioController controller)
    {
        int numberOfParticipants = UIManager.Instance.value;
        List<GameObject> touchpoints = GameManager.Instance.Touchpoints;

        int randomIndex = Random.Range(0, numberOfParticipants);
        GameManager.Instance.PunisherIndex = randomIndex;
        Debug.Log("��Ģ�� �ε��� : " + GameManager.Instance.PunisherIndex);

        Vector3 selectedPosition = touchpoints[randomIndex].transform.position;
        Debug.Log("���õ� ��ġ : " + selectedPosition);

        controller.SetNextScenario();
    }

    public override void Execute(ScenarioController controller)
    {

    }

    public override void Exit()
    {

    }
}
