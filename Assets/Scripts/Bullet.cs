using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;

    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);

            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out Wall wall))
        {
            Destroy(gameObject);
        }
    }
}