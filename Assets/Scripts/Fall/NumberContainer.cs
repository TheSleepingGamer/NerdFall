using UnityEngine;

public class NumberContainer : MonoBehaviour
{
    public TextMesh text;

    private float fallSpeed = 2f;

    public void Update()
    {
        this.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
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
