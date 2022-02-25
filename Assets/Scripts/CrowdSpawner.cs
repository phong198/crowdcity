using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrowdSpawner : MonoBehaviour
{
    public GameObject npc;
    private GameObject newpeople;
    public GameObject crowdspawner;
    public int xPos;
    public int zPos;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            SpawnNPC();
        }
        StartCoroutine(countinueSpawn());
    }

    IEnumerator countinueSpawn()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            if (crowdspawner.transform.childCount < 100)
            {
                SpawnNPC();
            }
        }
    }


    void SpawnNPC()
    {
            xPos = Random.Range(43, 319);
            zPos = Random.Range(97, 323);
            newpeople = Instantiate(npc, new Vector3(xPos, 0, zPos), Quaternion.identity);
            newpeople.transform.parent = transform;
    }
}
