using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    //파괴 시간
    public float destructionDelay = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //인트로가 일정 시간이 지나면 파괴된다.
        Destroy(gameObject, destructionDelay);
    }
}
