using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject cannonHead;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private GameObject loadedBullet;

    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - this.cannonHead.transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        this.cannonHead.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            this.LoadNewBullet();
        }
    }

    public void LoadNewBullet()
    {
        if (this.loadedBullet == null)
        {
            this.loadedBullet = (GameObject)Instantiate(this.bulletPrefab, this.cannonHead.transform.position, this.cannonHead.transform.rotation);
            this.loadedBullet.transform.parent = this.cannonHead.transform;
            this.loadedBullet.transform.localPosition = new Vector3(this.loadedBullet.transform.localPosition.x + 1.2f, this.loadedBullet.transform.localPosition.y, 0f);
        }
        else
        {
            this.FireBullet();
        }
    }

    public void FireBullet()
    {
        Rigidbody2D rbBullet = this.loadedBullet.GetComponent<Rigidbody2D>();
        rbBullet.isKinematic = false;
        rbBullet.AddRelativeForce(new Vector2(bulletSpeed, 0), ForceMode2D.Impulse);
        this.loadedBullet.transform.parent = null;
        Destroy(this.loadedBullet, 3);

        this.loadedBullet = null;
    }

}
