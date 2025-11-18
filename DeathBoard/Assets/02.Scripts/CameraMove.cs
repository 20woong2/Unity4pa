using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.0f;
    GameObject OriginalPos;


    void Start()
    {
        OriginalPos = GameObject.Find("OriginalPos");
        Application.targetFrameRate = 60;
    }

    // 메인 화면의 카메라 움직임을 조정하는 함수
    void Update()
    {
        if (transform.position.x > 6.3f) // 화면이 일정 범위를 넘어가지 않게 함
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime); // 카메라를 원래 z축으로 이동
        }
        else
        {
            this.transform.position = OriginalPos.transform.position; // 카메라를 원래 위치로으로 이동
        }
    }
}
