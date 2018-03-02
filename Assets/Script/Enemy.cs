using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Token {
    public static Player target = null;

    public float GetAim()
    {
        float dx = target.X - X;
        float dy = target.Y - Y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }

    int hp;
    int id;
    public int Hp
    {
        get { return hp; }
    }

    bool Damage(int v)
    {
        hp -= v;
        if (hp <= 0)
        {
            Vanish();
            for(int i = 0; i < 4; i++)
            {
                Particle.Add(X, Y);
            }
            return true;
        }
        return false;
    }
	// Use this for initialization
	void Start () {
        hp = 30;
        StartCoroutine("_Update1");
	}
	
	// Update is called once per frame
	IEnumerator _Update1 () {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            float dir = GetAim();
            Bullet.Add(X, Y, dir, 3);
        }
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        string name = LayerMask.LayerToName(c.gameObject.layer);
        if (name == "Shot")
        {
            Shot s = c.GetComponent<Shot>();

            s.Vanish();
            Damage(1);
        }
    }
}
