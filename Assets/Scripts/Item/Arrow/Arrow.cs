using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
