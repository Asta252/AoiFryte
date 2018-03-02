using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Token {
    public float MoveSpeed = 3.0f;
    public int life;
    public GameObject[] LifeIcon;

    public int destroyCount = 0;
	// Use this for initialization
	void Start () {
        var w = SpriteWidth / 2;
        var h = SpriteHeight / 2;

        SetSize(w, h);
        life = 3;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 v = Util.GetInputVector();
        float speed = MoveSpeed * Time.deltaTime;

        ClampScreenAndMove(v * speed);

        if (Input.GetKey(KeyCode.Z))
        {
            float py = Y + Random.Range(0, SpriteHeight / 2);
            float dir = Random.Range(-3.0f, 3.0f);
            Shot.Add(X, py, dir, 10);
        }
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        string name = LayerMask.LayerToName(c.gameObject.layer);
        switch (name)
        {
            case "Enemy":

                break;
            case "Bullet":
                life--;
                destroyCount++;
                UpdateLifeIcon();
                if (life <= 0)
                {
                    Vanish();

                    for(int i = 0; i < 8; i++)
                    {
                        Particle.Add(X, Y);
                    }
                }


                break;
        }
    }

    void UpdateLifeIcon()
    {
        for(int i = 0; i < LifeIcon.Length; i++)
        {
            if (destroyCount <= i)
            {
                LifeIcon[i].SetActive(true);
            }
            else
            {
                LifeIcon[i].SetActive(false);
            }
        }
    }
}
