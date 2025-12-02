using UnityEngine;
using System.Collections;
public class Shoot : MonoBehaviour
{
    public Player player;
    public TurnManager turnManager;
    private ParticleSystem muzzleFx;
    public ScreenFlash screenFlash; 
    public AudioSource reloadSource;   // cocking-a-revolver-... 클립 연결
    public AudioSource shotSource;  // single-pistol-gunshot-... 클립 연결
    public AudioSource nobullet;   
    public bool Dofire = false;
    private int originHP = -1;
    private int afterHP = -1;
    void OnMouseDown()
    {
       if(TurnManager.currentturn == 10)
        {
            TurnManager.currentturn = 11;
            StartCoroutine(Gunmoving());
        }
    }
    public IEnumerator Gunmoving()
    {
        GameObject thisGun = GameObject.Find("Gun");
        GunMove Gunmove = thisGun.GetComponent<GunMove>();
        Vector3 targetPosition = new Vector3(5.68f, 2.479f, -1.81f);
        Vector3 originPosition = Gunmove.originPosition;
        Quaternion targetRotation = Quaternion.Euler(0f, -5f, 0f);
        Quaternion originRotation = Gunmove.originRotation;
        originHP = player.enemy.HP;
        Gunmove.StartMoving(targetPosition,targetRotation);
        yield return new WaitForSeconds(0.7f);
        reloadSource.Play();
        yield return new WaitForSeconds(1.8f);
        Debug.Log("before: " + player.enemy.CP);
        player.enemy.attacked();
        yield return new WaitForSeconds(0.5f);
        afterHP = player.enemy.HP;
        //if(originHP != -1 && originHP > afterHP)
        //{
            shotSource.Play();
            yield return new WaitForSeconds(0.2f);
            Transform t = thisGun.transform.Find("Particle System");
            if (t != null)
            {
                muzzleFx = t.GetComponent<ParticleSystem>();
            }
            if (muzzleFx != null)
            {
                muzzleFx.Play();
            }
            Debug.Log("before screenFlash");
            
            screenFlash.DoFlash();
            
        //}
        //else 
        //{
            nobullet.Play();
        //}
        Debug.Log("after: " + player.enemy.CP);
        Debug.Log("now HP: " + player.enemy.HP);
        yield return new WaitForSeconds(2f);
        Gunmove.StartMoving(originPosition,originRotation);
        yield return new WaitForSeconds(2f);
        
        TurnManager.turnend = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
