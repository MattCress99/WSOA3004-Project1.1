using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Enemies;
    void Start()
    {
        int select = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[select], transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
   
}
