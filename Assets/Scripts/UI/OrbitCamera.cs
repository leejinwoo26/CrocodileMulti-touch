using UnityEngine;
using System.Collections;

namespace StylizedWaterShader
{
    public class OrbitCamera : MonoBehaviour
    {
        [Header("Stylized Water Demo")]
        [Space]
        public Transform pivot;

        [Space]
        public bool enableMouse = true;
        public float idleRotationSpeed = 0.05f;

        private Transform cam;
        private float cameraRotSide;
        private float cameraRotUp;
        private float cameraRotSideCur;
        private float cameraRotUpCur;
        private float distance;




        void Start()
        {
            cam = Camera.main.transform;

            cameraRotSide = transform.eulerAngles.y;
            cameraRotSideCur = transform.eulerAngles.y;
            cameraRotUp = transform.eulerAngles.x;
            cameraRotUpCur = transform.eulerAngles.x;
            distance = -cam.localPosition.z;
        }

        void Update()
        {
            if (!pivot) return;



            if (Input.GetMouseButton(0) && enableMouse && UIManager.Instance.isOpenPnl == false)
            {
                cameraRotSide += Input.GetAxis("Mouse X") * 5;
                cameraRotUp -= Input.GetAxis("Mouse Y") * 5;

            }
            else
            {
                cameraRotSide += idleRotationSpeed;
            }
            cameraRotSideCur = Mathf.LerpAngle(cameraRotSideCur, cameraRotSide, Time.deltaTime * 5);
            //cameraRotUpCur = Mathf.Lerp(cameraRotUpCur, cameraRotUp, Time.deltaTime * 5);
            cameraRotUpCur = Mathf.Clamp(Mathf.Lerp(cameraRotUpCur, cameraRotUp, Time.deltaTime * 5), 0f, 90f);


            Vector3 targetPoint = pivot.position;
            transform.position = Vector3.Lerp(transform.position, targetPoint, Time.deltaTime);
            transform.rotation = Quaternion.Euler(cameraRotUpCur, cameraRotSideCur, 0);

            float dist = Mathf.Lerp(-cam.transform.localPosition.z, distance, Time.deltaTime * 5);
            cam.localPosition = -Vector3.forward * dist;



        }
    }
    //    void Update()
    //    {
    //        if (!pivot) return;

    //        // ��ġ �Է� Ȯ��
    //        if (Input.touchCount >0 && enableMouse && UIManager.Instance.isOpenPnl == false)
    //        {
    //            Touch touch = Input.GetTouch(0);

    //            // ���� ��ġ�� ȸ�� �� �̵� ó��
    //            if (touch.phase == TouchPhase.Moved)
    //            {
    //                cameraRotSide += touch.deltaPosition.x * 0.1f;
    //                cameraRotUp -= touch.deltaPosition.y * 0.1f;
    //            }
    //        }
    //        else
    //        {
    //            cameraRotSide += idleRotationSpeed;
    //        }

    //        // ȸ�� �� �� ó��
    //        cameraRotSideCur = Mathf.LerpAngle(cameraRotSideCur, cameraRotSide, Time.deltaTime * 5);
    //        cameraRotUpCur = Mathf.Clamp(Mathf.Lerp(cameraRotUpCur, cameraRotUp, Time.deltaTime * 5), 0f, 90f);

    //        // �� ó��
    //        if (Input.touchCount > 1 && enableMouse && UIManager.Instance.isOpenPnl == false)
    //        {
    //            Touch touch1 = Input.GetTouch(0);
    //            Touch touch2 = Input.GetTouch(1);

    //            // �� ��ġ ������ �Ÿ� ���
    //            float distanceBetweenTouches = Vector2.Distance(touch1.position, touch2.position);

    //            // �� ��/�ƿ� ó��
    //            distance *= (1 - 0.1f * (distanceBetweenTouches - touch1.deltaPosition.magnitude - touch2.deltaPosition.magnitude));
    //        }

    //        // �ǹ� �߽����� �̵� �� ȸ��
    //        Vector3 targetPoint = pivot.position;
    //        transform.position = Vector3.Lerp(transform.position, targetPoint, Time.deltaTime);
    //        transform.rotation = Quaternion.Euler(cameraRotUpCur, cameraRotSideCur, 0);

    //        // ī�޶� �Ÿ� ����
    //        float dist = Mathf.Lerp(-cam.transform.localPosition.z, distance, Time.deltaTime * 5);
    //        cam.localPosition = -Vector3.forward * dist;
    //    }
    //}
}
