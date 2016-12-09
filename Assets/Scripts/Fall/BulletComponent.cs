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

    public void OnDestroy()
    {
        this.InformBulletIsNotWorkingAnymore();
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
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
        if (this.onBulletNoWorkiAnyMore != null)
        {
            this.onBulletNoWorkiAnyMore.Invoke();
        }
    }

    public void AddListenerToBullet(Action listener)
    {
        this.onBulletNoWorkiAnyMore += listener;
    }

    public void DeactivateCollider()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
