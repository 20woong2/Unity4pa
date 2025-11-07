using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime); //카메라를 원래 z축으로 이동
    }
}
