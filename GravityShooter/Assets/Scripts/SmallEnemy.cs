﻿//using System;
using UnityEngine;
using System.Collections;

public class SmallEnemy : MonoBehaviour, EnemyManager
{
    private GameObject player;
    public GameObject BulletPreb;

    public int BulletSpeed;
    public int amo;
    public float delay;
    private float timer;
    private int count;

    void Start ()
    {
        count = 0;
        StartCoroutine(findPlayer());
    }

    IEnumerator findPlayer()
    {
        while (player == null)
        {
            player = GameObject.Find("Player");
            yield return null;
        }
    }

    public void Fire()
    {
        if (player != null)
        {
            //Vector2 accuracy = new Vector2(0, Random.Range(-0.1f, 0.1f));
            GameObject bullet = Instantiate(BulletPreb) as GameObject;
            bullet.transform.position = transform.position;
        
            Vector2 playerDir = (player.transform.position - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = playerDir.normalized * BulletSpeed;
        }
    }

    public bool aim()
    {
        return true;
    }
    
    public void movement()
    {
        if (player != null)
        {
            transform.right = (transform.position - player.transform.position).normalized;
        }
    }

    void FixedUpdate ()
    {
        movement();

        timer += Time.deltaTime;

        if (count > amo)
        {
            if (player != null)
            {
                Vector2 playerDir = (player.transform.position - transform.position).normalized;
                GetComponent<Rigidbody2D>().velocity = playerDir.normalized * BulletSpeed;
            }
        }
        else
        {
            if (timer > delay)
            {
                count++;
                Fire();
                timer = 0;
            }
        }
	}

    void TriggerOnEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
