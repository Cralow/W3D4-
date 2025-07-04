using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float fireForce;
    public GameObject firePoint;

    public float fireRate;
    public float timer;

    private Queue<Bullet> bulletPool = new Queue<Bullet>();

    public Bullet GetBullet()
    {
        Bullet bullet = null;
        if(bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate(bulletPrefab);
            bullet.SetUp(this);

        }
        return bullet;
    }
    public void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    void Update()
    {
        timer -=Time.deltaTime;
        
        if (Input.GetMouseButton(0) &&timer <=0)
        {

            Bullet b = GetBullet();
            b.transform.position = firePoint.transform.position;
            b.Shot(firePoint.transform.forward);


            timer = fireRate;

        }
    }

   
}
