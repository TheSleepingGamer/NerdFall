using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject cannonHead;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    public GameObject loadedBullet;

    private bool isObjectPaused;

    void Update()
    {
        if (!this.isObjectPaused)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos = lookPos - this.cannonHead.transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            this.cannonHead.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Input.GetMouseButtonDown(0) && this.loadedBullet != null)
            {
                this.FireBullet();
            }
        }
    }

    public GameObject LoadNewBullet()
    {
        if (this.loadedBullet == null)
        {
            this.loadedBullet = (GameObject)Instantiate(this.bulletPrefab, this.cannonHead.transform.position, this.cannonHead.transform.rotation);
            this.loadedBullet.transform.parent = this.cannonHead.transform;
            this.loadedBullet.transform.localPosition = new Vector3(this.loadedBullet.transform.localPosition.x + 1.8f, this.loadedBullet.transform.localPosition.y, 0f);
        }

        return this.loadedBullet;
    }

    public void LoadGivenBullet(GameObject bullet)
    {
        if (bullet != null)
        {
            bullet.transform.parent = this.cannonHead.transform;
            bullet.transform.position = this.cannonHead.transform.position;

            bullet.transform.localPosition = new Vector3(bullet.transform.localPosition.x + 1.8f, bullet.transform.localPosition.y, 0f);
            bullet.transform.rotation = this.cannonHead.transform.rotation;
            this.loadedBullet = bullet;
        }
    }

    public void FireBullet()
    {
        Rigidbody2D rbBullet = this.loadedBullet.GetComponent<Rigidbody2D>();
        rbBullet.isKinematic = false;
        rbBullet.AddRelativeForce(new Vector2(bulletSpeed, 0), ForceMode2D.Impulse);
        this.loadedBullet.transform.parent = null;
        //Destroy(this.loadedBullet, 3);

        this.loadedBullet = null;
    }

    public void Pause()
    {
        this.isObjectPaused = true;
    }

    public void Resume()
    {
        this.isObjectPaused = false;
    }
}
