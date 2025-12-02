using UnityEngine;
using System.Collections;
public class Scan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;
    private ParticleSystem muzzleFx;
    public ScreenFlash screenFlash; 
    private int originHP = -1;
    private int afterHP = -1;
    public IEnumerator scanAttack()
    {
        if(TurnManager.currentturn == 11)
        {
            int per = Random.Range(1, 101);
            if (per <= player.user.CP * 2)
            {
                GameObject thisGun = GameObject.Find("EnemyGun");
                EnemyGunMove Gunmove = thisGun.GetComponent<EnemyGunMove>();
                Vector3 targetPosition = new Vector3(4.63f, 2.627f, 0.93f);
                Vector3 originPosition = Gunmove.originPosition;
                Quaternion targetRotation = Quaternion.Euler(1.3f, 170f, 0f);
                Quaternion originRotation = Gunmove.originRotation;
                originHP = player.user.HP;
                Gunmove.StartMoving(targetPosition,targetRotation);
                yield return new WaitForSeconds(2.5f);
                player.user.attacked();
                yield return new WaitForSeconds(0.2f);
                afterHP = player.user.HP;
                if(originHP != -1 && originHP > afterHP)
                {
                    Transform t = thisGun.transform.Find("Particle System");
                    if (t != null)
                    {
                        muzzleFx = t.GetComponent<ParticleSystem>();
                    }
                    if (muzzleFx != null)
                    {
                        muzzleFx.Play();
                    }
                    
                    screenFlash.DoFlash();
                }
                Debug.Log("after: " + player.enemy.CP);
                Debug.Log("now HP: " + player.enemy.HP);
                yield return new WaitForSeconds(2f);
                Gunmove.StartMoving(originPosition,originRotation);
                yield return new WaitForSeconds(2f);
            }
            TurnManager.currentturn = 1;
            TurnManager.turnend = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
