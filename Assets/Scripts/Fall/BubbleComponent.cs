using System;
using UnityEngine;
using System.Collections;

public class BubbleComponent : MonoBehaviour
{
    public TextMesh text;

    [HideInInspector]
    private Action<int> bubbleHitAction = null;

    public void SetNumber(int x)
    {
        this.text.text = x.ToString();
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "WeaponType_1")
        {
            if (this.bubbleHitAction != null)
            {
                Debug.Log("HIT!!");

                Destroy(col.gameObject);
                this.bubbleHitAction.Invoke(int.Parse(this.text.text));
            }
        }
    }

    public void AttachAHitListener(Action<int> newAction)
    {
        this.bubbleHitAction += newAction;
    }
}
