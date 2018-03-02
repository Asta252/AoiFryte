using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Token {
    public int col;
    public int knd;
    public Sprite[] bulcolor;
    SpriteRenderer BulletSpriteRenderer;

    public static TokenMgr<Bullet> parent = null;
    public static Bullet Add(float x,float y,float direction,float speed)
    {
        return parent.Add(x, y, direction, speed);
    }
	// Use this for initialization
	void Start () {
        BulletSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        BulletSpriteRenderer.sprite = bulcolor[col];
	}
	
	// Update is called once per frame
	void Update () {
        if (IsOutside())
        {
            Vanish();
        }
	}
}
