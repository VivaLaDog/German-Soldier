using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChocResp : MonoBehaviour
{
    [SerializeField]
    GameObject coko;

    [SerializeField]
    GameObject mina;

    [SerializeField]
    GameObject mask;

    void Start()
    {
        RandomSpawn(coko);
        for(int i = 0; i < 5; i++)
        {
            RandomSpawn(mina);
        }
        RandomSpawn(mask);
    }

    private void RandomSpawn(GameObject go)
    {
        var point = new Vector3(Random.Range(-4f, 4f), 0.25f, Random.Range(-4f, 4f));
        if (Physics.Raycast(point, Vector3.down, out RaycastHit hit, 4.5f))
        {
            Instantiate(go, point, go.transform.rotation);
        }
    }
}
