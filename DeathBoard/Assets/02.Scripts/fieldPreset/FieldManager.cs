using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public int readyCardID;
    public bool cardReady = false;
    public GameObject readyCard;
    public GameObject MyfieldPrefab;
    public GameObject EnemyfieldPrefab;
    public int?[,] CurrntField = new int?[4,7];

    public void FieldReset()
    {
        for(int i=0;i<4;i++)
        {
            for(int j=0;j<7;j++)
            {
                CurrntField[i,j] = null;
            }
        }
    }

    public void SetCardReady(GameObject setCard)
    {
        CardStateManager stateManager = setCard.GetComponent<CardStateManager>();
        cardReady = true;
        readyCard = setCard;
        readyCardID = stateManager.thiscardID;
        
    }
    public bool getReady()
    {
        return cardReady;
    }
    private void FieldInit()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                GameObject FieldCube;
                if (i < 2)
                {
                    FieldCube = Instantiate(MyfieldPrefab, new Vector3(3.95f + 0.425f * j, 2.00f, -1.275f + 0.625f * i), Quaternion.identity);
                    
                }
                else
                {
                    FieldCube = Instantiate(EnemyfieldPrefab, new Vector3(3.95f + 0.425f * j, 2.00f, -1.275f + 0.625f * i), Quaternion.identity);
                }
                FieldReaction fieldReaction = FieldCube.GetComponent<FieldReaction>();
                fieldReaction.fieldPosition[0] = i;
                fieldReaction.fieldPosition[1] = j;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FieldReset();
        FieldInit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
