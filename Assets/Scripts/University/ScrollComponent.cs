using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollComponent : MonoBehaviour, IPointerClickHandler
{
    public string name;

    public string description;

    public int inteligencePoints;

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
                this.description = "In this level you'll master your skill to solve simple arithmethic subtraction.";
                spriteRenderer.sprite = unlockedSprite;
                this.isUnlocked = true;
                break;
            case "multiplication":
                if (inteligencePoints > 50)
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
                if (inteligencePoints >= 100)
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
                if (inteligencePoints >= 150)
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
                if (inteligencePoints >= 200)
                {
                    spriteRenderer.sprite = unlockedSprite;
                    this.isUnlocked = true;
                }
                else
                {
                    spriteRenderer.sprite = lockedSprite;
                }
                this.description = "TODO";
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
