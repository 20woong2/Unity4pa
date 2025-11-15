using UnityEngine;

public class EnemyHandManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int NumOfHand = 0;
    public GameObject Pos1;

    public readonly float PosX = 5.225f;
    public readonly float moveX = -1.3f * 0.12f; //ī�尡 �߰��� ������ �������� 1.3��ŭ �̵�
    public readonly float PosY = 2.3f;
    public readonly float PosZ = 1.125f; //ī���� Y, Z���� ī�� �ż��� ������� ����
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Pos1 = GameObject.FindWithTag("Pos1");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HandPlus(int newCardID)
    {
        DeckManager.EnemyHandList.Add(newCardID);
    }
    public void rePlaceCard()
    {
        for (int i = 0; i < DeckManager.EnemyHandList.Count; i++)
        {
            GameObject[] thiscards = GameObject.FindGameObjectsWithTag(DeckManager.EnemyHandList[i].ToString());
            GameObject thisCard = GameObject.FindWithTag(DeckManager.EnemyHandList[i].ToString());
            
            Vector3 targetPosition = new Vector3(
                ((DeckManager.EnemyHandList.Count-1) - i*2)*moveX + PosX,
                PosY,
                PosZ - (0.001f * i)
            );
            Vector3 position = targetPosition;
            thisCard.transform.position = position;
            thiscards[1].transform.position = new Vector3(position.x, position.y, position.z - 0.001f);

        }
    }
}
