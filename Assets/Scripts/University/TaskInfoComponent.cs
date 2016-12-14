using UnityEngine;
using System.Collections;

public class TaskInfoComponent : MonoBehaviour
{

    public AudioSource clickButton;

    public void OnBackButtonClick()
    {
        StartCoroutine(PlayButtonClickSound());
        this.gameObject.SetActive(false);
        GameStateManager.TransitionToScene(GameScene.University);
    }

    public void OnStartButtonClick()
    {
        StartCoroutine(PlayButtonClickSound());
        this.gameObject.SetActive(false);
        GameStateManager.TransitionToScene(GameScene.Fall);
    }

    public void OnMapButtonClick()
    {
        StartCoroutine(PlayButtonClickSound());
        this.gameObject.SetActive(false);
        GameStateManager.TransitionToScene(GameScene.Map);
    }

    private IEnumerator PlayButtonClickSound()
    {
        clickButton.Play();
        yield return new WaitForSeconds(clickButton.clip.length);
    }
}
