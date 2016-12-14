using System;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Action onBulletNoWorkiAnyMore;

    private Vector3 pausedVelocity;
    private float pausedAngularVelocity;

    void Awake()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
    }

    public void OnBecameInvisible()
    {
        this.InformBulletIsNotWorkingAnymore();
    }

    public void Pause()
    {
        this.pausedVelocity = this.rigidBody.velocity;
        this.pausedAngularVelocity = this.rigidBody.angularVelocity;
        this.rigidBody.isKinematic = true;
    }

    public void Resume()
    {
        this.rigidBody.isKinematic = false;
        this.rigidBody.velocity = this.pausedVelocity;
        this.rigidBody.angularVelocity = this.pausedAngularVelocity;
    }

    public void InformBulletIsNotWorkingAnymore()
    {
        if (this.onBulletNoWorkiAnyMore != null && this.rigidBody.isKinematic == false)
        {
            this.rigidBody.isKinematic = true;
            this.onBulletNoWorkiAnyMore.Invoke();
        }
    }

    public void AddListenerToBullet(Action listener)
    {
        this.onBulletNoWorkiAnyMore += listener;
    }
}
