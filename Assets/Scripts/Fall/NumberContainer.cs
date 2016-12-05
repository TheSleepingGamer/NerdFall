using UnityEngine;

public class NumberContainer : MonoBehaviour
{
    public TextMesh text;

    public float fallSpeed = 0f;

    public void Update()
    {
        this.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // TODO: Destroy object based on collider with floor
        if (this.transform.position.y < -16)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetNumber(int x)
    {
        this.text.text = x.ToString();
    }

    public int GetNumber()
    {
        return int.Parse(this.text.text);
    }
}
