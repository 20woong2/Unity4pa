using UnityEngine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class GunHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     [Header("Object Hover Height (in Mouse Hover)")]
    public float hoverHeight = 0.1f;

    [Header("Audio Settings")]
    public AudioClip clickSound;
    private AudioSource audioSource;

    // Hover, pressed state?? ?????? ????
    private bool isHovered = false;
    private bool isPressed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject thisGun = GameObject.Find("Gun");
        Shoot shoot = thisGun.GetComponent<Shoot>();
        //if(shoot.shooting == false)
        //{
            // Vector3.up = new Vector3(0, 1, 0)
            isHovered = true;
            transform.position += Vector3.up * hoverHeight;
            //transform.Find("Subtitle").gameObject.SetActive(true);
            //transform.Find("Spot Light").gameObject.SetActive(true);
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject thisGun = GameObject.Find("Gun");
        Shoot shoot = thisGun.GetComponent<Shoot>();
        //if(shoot.shooting == false)
        //{
            // Vector3.down = new Vector3(0, -1, 0)
            isHovered = true;
            transform.position += Vector3.down * hoverHeight;
            //transform.Find("Subtitle").gameObject.SetActive(false);
            //transform.Find("Spot Light").gameObject.SetActive(false);
        //}
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject thisGun = GameObject.Find("Gun");
        Shoot shoot = thisGun.GetComponent<Shoot>();
        //if(shoot.shooting == false)
        audioSource.PlayOneShot(clickSound);
    }
}
