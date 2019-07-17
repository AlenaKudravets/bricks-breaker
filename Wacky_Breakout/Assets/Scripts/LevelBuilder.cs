using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject paddlePrefab;

    [SerializeField]
    private GameObject standartBlockPrefab;

    [SerializeField]
    private GameObject bonusBlockPrefab;

    [SerializeField]
    private GameObject pickUpBlockPrefab;

    private float blockColliderOffset = 0;
    private float numOfBlockRows;
    private float randNum;
    private GameObject block;
    private GameObject generalPrefab;
    private int spawnProbability;

    void Start()
    {
        Instantiate(paddlePrefab);

        GameObject tmpBlock = Instantiate(standartBlockPrefab);
        float colliderHeight = tmpBlock.GetComponent<BoxCollider2D>().size.y;
        Destroy(tmpBlock);
        numOfBlockRows = 3;
        for(int i = 0; i < numOfBlockRows; i++)
        {
            BuildBlockLine(blockColliderOffset + i * colliderHeight);
        }
    }

    void Update()
    {
        
    }

    private void BuildBlockLine(float heightColliderOffset)
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float fifthScreenHeight = halfHeight / 1.5f - heightColliderOffset;
        float halfWidth = camera.aspect * halfHeight;
        Vector2 standartBlockPos = new Vector2(0, fifthScreenHeight);
        GameObject middleBlock = Instantiate(ChoosePrefabToInstantiate(), standartBlockPos, Quaternion.identity);
        float colliderWidth = middleBlock.GetComponent<BoxCollider2D>().size.x;
        float colliderHeight = middleBlock.GetComponent<BoxCollider2D>().size.y;
        while (standartBlockPos.x < halfWidth)
        {
            standartBlockPos.x += colliderWidth;
            Instantiate(ChoosePrefabToInstantiate(), new Vector3(standartBlockPos.x, standartBlockPos.y), Quaternion.identity);
            
            //randNum = Random.Range(1, 3);
            //if(randNum == 2)
            //{
            //    block.GetComponent<PickUpBlock>().SetupSprite(PickupEffect.Freezer);
            //}
            //else
            //{
            //    block.GetComponent<PickUpBlock>().SetupSprite(PickupEffect.Speedup);
            //}
        }
        standartBlockPos.x = 0;
        while (standartBlockPos.x > -halfWidth)
        {
            standartBlockPos.x -= colliderWidth;
            Instantiate(ChoosePrefabToInstantiate(), new Vector3(standartBlockPos.x, standartBlockPos.y), Quaternion.identity);
        }
    }

    private GameObject ChoosePrefabToInstantiate()
    {
        int maxProbability = ConfigurationUtils.StandartBlockProbability + ConfigurationUtils.FreezeBlockProbability + ConfigurationUtils.BonusBlockProbability + ConfigurationUtils.SpeedupBlockProbability;
        spawnProbability = UnityEngine.Random.Range(0, maxProbability);

        //System.Random rnd = new System.Random();
        //int pickUpBlockProb = rnd.Next(1, 15);  // creates a number between 1 and 15
        //int bonusBlcokProb = rnd.Next(16, 49);   // creates a number between 16 and 49
        //int standartBlockProb = rnd.Next(50, 100);     // creates a number between 50 and 100
        //Random.RandomRange(0.1f, 0.5f);
        //float standartProbabilityToDecimal = ConfigurationUtils.StandartBlockProbability / 100; //0.5

        Debug.Log(spawnProbability);
        if (isBetween(spawnProbability, 0, ConfigurationUtils.StandartBlockProbability)) /*spawnProbability <= ConfigurationUtils.FreezeBlockProbability) //%15 percent chance, 0.15*/
        {
            generalPrefab = standartBlockPrefab;
        }
        else if (isBetween(spawnProbability, ConfigurationUtils.StandartBlockProbability, ConfigurationUtils.StandartBlockProbability + ConfigurationUtils.BonusBlockProbability)) /*spawnProbability <= ConfigurationUtils.FreezeBlockProbability + ConfigurationUtils.BonusBlockProbability)*/ //%20 percent chance, 0.2
        {
            generalPrefab = bonusBlockPrefab;
        }
        else if (isBetween(spawnProbability, ConfigurationUtils.StandartBlockProbability + ConfigurationUtils.BonusBlockProbability, ConfigurationUtils.StandartBlockProbability + ConfigurationUtils.BonusBlockProbability + ConfigurationUtils.FreezeBlockProbability)) //%50 percent chance, 0.5
        {
            generalPrefab = pickUpBlockPrefab;
            generalPrefab.GetComponent<PickUpBlock>().SetupSprite(PickupEffect.Freezer);
        }
        else if (isBetween(spawnProbability, ConfigurationUtils.StandartBlockProbability + ConfigurationUtils.BonusBlockProbability + ConfigurationUtils.FreezeBlockProbability, maxProbability))
        {
            generalPrefab = pickUpBlockPrefab;
            generalPrefab.GetComponent<PickUpBlock>().SetupSprite(PickupEffect.Speedup);
        }

            return generalPrefab;
    }

    private bool isBetween(int value, int v1, int v2)
    {
        return value >= v1 && value < v2;
    }
}
