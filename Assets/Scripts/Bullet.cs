using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int dmg = 5;

    Rigidbody rb;
    PlayerShootController shootController;


    public void SetUp(PlayerShootController _shootController)
    {
        shootController = _shootController;
    }
    public void ReturnToPool()
    {
        if(gameObject.activeInHierarchy)return;


        shootController.ReleaseBullet(this);
    }




    public void Shot(Vector3 direction)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = direction * _speed;
        rb.angularVelocity = Vector3.zero;


        Invoke("ReturnToPool", lifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<Enemy>().EnemyTakeDamage(dmg);
        }


        ReturnToPool();

    }
}

