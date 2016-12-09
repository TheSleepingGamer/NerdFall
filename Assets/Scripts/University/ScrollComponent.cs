using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollComponent : MonoBehaviour, IPointerClickHandler
{
    public string name;

    public string description;

    public GameObject taskInfo;

    public Sprite lockedSprite;

    public Sprite unlockedSprite;

    private SpriteRenderer spriteRenderer;

    private bool isUnlocked;

    // Use this for initialization
    void Start () {
        taskInfo.SetActive(false);
        spriteRenderer  = GetComponent<SpriteRenderer>();
        this.isUnlocked = false;
        switch (name)
	    {
            case "addition":
	            this.description = "In this level you'll master your skill to solve simple arithmethic addition.";
	            spriteRenderer.sprite = unlockedSprite;
	            this.isUnlocked = true;
                break;
            case "subtraction":
                if (Player.intelligenceAmount > 200)
                {
                    this.description = "In this level you'll master your skill to solve simple arithmethic subtraction.";
                    spriteRenderer.sprite = unlockedSprite;
                    this.isUnlocked = true;
                }
                else
                {
                    spriteRenderer.sprite = lockedSprite;
                }
               
                break;
            case "multiplication":
                if (Player.intelligenceAmount > 250)
                {
                    spriteRenderer.sprite = unlockedSprite;
                    this.isUnlocked = true;
                }
                else
                {
                    spriteRenderer.sprite = lockedSprite;
                }

	            break;
            case "division":
                if (Player.intelligenceAmount > 350)
                {
                    spriteRenderer.sprite = unlockedSprite;
                    this.isUnlocked = true;
                }
                else
                {
                    spriteRenderer.sprite = lockedSprite;
                }

	            break;
            case "fibonacci":
                if (Player.intelligenceAmount > 450)
                {
                    spriteRenderer.sprite = unlockedSprite;
                    this.isUnlocked = true;
                }
                else
                {
                    spriteRenderer.sprite = lockedSprite;
                }

	            break;
            case "trigonometry":
                if (Player.intelligenceAmount >= 600)
                {
                    spriteRenderer.sprite = unlockedSprite;
                    this.isUnlocked = true;
                }
                else
                {
                    spriteRenderer.sprite = lockedSprite;
                }
                break;
        }
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.isUnlocked)
        {
            taskInfo.SetActive(true);
        }
    }
}
