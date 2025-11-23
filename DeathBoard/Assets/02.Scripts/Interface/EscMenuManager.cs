using UnityEngine;

public class EscMenuManager : MonoBehaviour
{
    private bool isActived = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            if (!isActived)
            {
                GameObject.Find("Canvas").transform.Find("Esc Screen").gameObject.SetActive(true);
                isActived = true;
            }
            else 
            {
                GameObject.Find("Canvas").transform.Find("Esc Screen").gameObject.SetActive(false);
                isActived = false;
            }
        }
    }
}
