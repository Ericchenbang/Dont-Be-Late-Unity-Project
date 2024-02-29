using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] int count;
    void Start()
    {
        for(int i = 0; i < count; i++)
        {
            Transform c = Instantiate(coin.transform);
            c.parent = transform;
            c.localPosition = new Vector3(i, i, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
