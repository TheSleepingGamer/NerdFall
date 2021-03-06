﻿using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollComponent : MonoBehaviour, IPointerClickHandler
{
    private const int IntelliganceBetweenProblems = 100;

    public Problem problem;

    public GameObject taskInfo;

    public GameObject mapButton;

    public Sprite lockedSprite;

    public Sprite unlockedSprite;

    private SpriteRenderer spriteRenderer;

    private bool isUnlocked;
    
    void Start()
    {
        taskInfo.SetActive(false);
        mapButton.SetActive(true);
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.isUnlocked = false;

        if(Player.playerProgressData.ContainsKey(this.problem))
        {
            spriteRenderer.sprite = unlockedSprite;
            this.isUnlocked = true;
        }
        else
        {
            if (Player.intelligenceAmount >= (int)this.problem * IntelliganceBetweenProblems)
            {
                Player.playerProgressData.Add(this.problem, ProblemManager.GenerateNewProblem(this.problem));
                Player.Save();

                spriteRenderer.sprite = unlockedSprite;
                this.isUnlocked = true;
            }
            else
            {
                spriteRenderer.sprite = lockedSprite;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.isUnlocked)
        {
            Player.selectedProblem = this.problem;
            taskInfo.SetActive(true);
        }
    }
}
