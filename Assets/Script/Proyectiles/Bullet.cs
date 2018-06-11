using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private const int speed = 10;
    private int dirY;
    private int power = 1;
    private float dispersion;

    private void Start()
    {
        GameManager.Get().totalShootsFired++;
    }

    void Update () {
        Movement();
        CheckBoundaries();
        CheckPower();
	}

    private void CheckPower()
    {
        transform.localScale = new Vector3(1,1,1) * power;
    }

    private void CheckBoundaries()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPos.x < 0 || screenPos.y < 0 || screenPos.x > 1 || screenPos.y > 1)
            Destroy(gameObject);
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        movement.y = dirY * speed;
        movement.x = dispersion;
        transform.position += movement * Time.deltaTime;
    }

    public void Initialize(int _dir, int _power, float _disp)
    {
        dirY = _dir;
        power = _power;
        dispersion = Random.Range(-_disp,_disp);
    }

    public void SetDirectionY(int val)
    {
        dirY = val;
    }

    public int GetPower()
    {
        return power;
    }

    public void SetPower(int val)
    {
        power = val;
    }
}
