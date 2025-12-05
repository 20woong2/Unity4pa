using UnityEngine;
using UnityEngine.EventSystems;

public class GuideSelecter : MonoBehaviour, IPointerDownHandler
{
    public TurnManager turnManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        turnManager.HelpOn = true;
        GameObject.Find("Canvas").transform.Find("Illustrated Guide Screen").gameObject.SetActive(true);
    }
}
