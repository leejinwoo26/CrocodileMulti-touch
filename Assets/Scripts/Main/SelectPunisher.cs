using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectPunisher : ScenarioBase
{
    public override void Enter(ScenarioController controller)
    {
        // starts after all participants touch.
        StartCoroutine(GetPositionOfPunisher());

        // TODO : �ڷ�ƾ ���ֱ�
    }

    public override void Execute(ScenarioController controller)
    {

    }

    public override void Exit()
    {

    }

    IEnumerator GetPositionOfPunisher()
    {
        // TODO : edit this seconds
        yield return new WaitForSeconds(2f);
        int numberOfParticipants = UIManager.Instance.value;
        List<GameObject> touchpoints = GameManager.Instance.Touchpoints;

        int randomIndex = Random.Range(0, numberOfParticipants);
        Vector3 selectedPosition = touchpoints[randomIndex].transform.position;
        Debug.Log("���õ� ��ġ : " + selectedPosition);
    }
}
