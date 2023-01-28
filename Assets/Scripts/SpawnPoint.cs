using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject spawnPrefab;

    private void Start()
    {
        Instantiate(spawnPrefab, transform.position, Quaternion.identity);
    }
}
