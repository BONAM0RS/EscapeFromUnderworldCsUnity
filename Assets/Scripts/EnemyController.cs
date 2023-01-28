using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage = 1;
    public float moveSpeed;

    public GameObject hitEffect;
    public GameObject hitSound;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnHitEffect();
            SpawnHitSound();
            PlayerController.Instance.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }

    private void SpawnHitEffect()
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
    }

    private void SpawnHitSound()
    {
        Instantiate(hitSound, transform.position, Quaternion.identity);
    }
}
