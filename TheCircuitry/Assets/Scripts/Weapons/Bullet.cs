﻿using UnityEngine;
using System.Collections;

public class Bullet : Weapon
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void FireWeapon(Vector3 rotation, Vector2 position, Vector2 velocity)
    {
        base.FireWeapon(rotation, position, velocity);
    }

    public override void FireWeapon(Vector2 position, Vector2 velocity)
    {
        GameObject go = Instantiate(this.gameObject, position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered)
        {
            isTriggered = true;
            GameObject go = collision.gameObject;

            if (go.tag == "Enemy")
            {
                Destroy(this.gameObject);
                Enemy enemy = go.GetComponent<Enemy>();
                enemy.applyDamage(getDamage());
                enemy.playDamageEffect();
            }

            if (go.tag == "OutOfBounds")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
