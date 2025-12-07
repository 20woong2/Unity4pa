using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class GunHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     [Header("Object Hover Height (in Mouse Hover)")]
    public float hoverHeight = 0.1f;

    [Header("Audio Settings")]
    public AudioClip clickSound;
    private AudioSource audioSource;

    // Hover, pressed state?? ?????? ????

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("마우스 enter");
        GameObject thisGun = GameObject.Find("Gun");
        Shoot shoot = thisGun.GetComponent<Shoot>();
        if(shoot.shooting == false)
        {
            // Vector3.up == new Vector3(0, 1, 0)
            Debug.Log("마우스 enter 가능");
            thisGun.transform.position = new Vector3(transform.position.x, 1.971f + 0.1f, transform.position.z);
            //transform.Find("Subtitle").gameObject.SetActive(true);
            //transform.Find("Spot Light").gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("마우스 exit");
        GameObject thisGun = GameObject.Find("Gun");
        Shoot shoot = thisGun.GetComponent<Shoot>();
        if(shoot.shooting == false)
        {
            Debug.Log("마우스 exit 가능");
            // Vector3.down = new Vector3(0, -1, 0)
            thisGun.transform.position = new Vector3(transform.position.x, 1.971f, transform.position.z);
            //transform.Find("Subtitle").gameObject.SetActive(false);
            //transform.Find("Spot Light").gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject thisGun = GameObject.Find("Gun");
        Shoot shoot = thisGun.GetComponent<Shoot>();
        //if(shoot.shooting == false)
        if(clickSound != null)
        audioSource.PlayOneShot(clickSound);
    }
}
