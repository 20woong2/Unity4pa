using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toggleIsOn : MonoBehaviour
{
    public GameObject toggle;
    public TMP_Text text;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void togglePressed(bool isOn)
    {
        if (isOn)
        {
            text.color = Color.black;
        }
        else
        {
            text.color = Color.white;
        }
    }
}
