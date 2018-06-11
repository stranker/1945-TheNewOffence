using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosion : MonoBehaviour {
    public GameObject explosionPrefab;
    public GameObject explosion;
    public float shakeAmount;
    public float shakeDuration;

    public void Create(Vector3 pos, float duration, int speed, float _shakeDuration, float _shakeAmount)
    {
        explosion = Instantiate(explosionPrefab, pos, explosionPrefab.transform.rotation, transform.parent);
        explosion.GetComponent<Explosion>().Initialize(duration,speed);
        shakeAmount = _shakeAmount;
        shakeDuration = _shakeDuration;
        Camera.main.GetComponent<CameraShake>().Shake(shakeDuration, shakeAmount);
    }
}
