using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class OnClickTrigger : MonoBehaviour, IPointerClickHandler
{
    public AudioSource clickButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click detected!");
    }
   
    public void OnUniversitySpriteClick()
    {
        StartCoroutine(PlayButtonClickSound());
        GameStateManager.TransitionToScene(GameScene.University);
    }

    public void OnHomeSpriteClick()
    {
        StartCoroutine(PlayButtonClickSound());
        GameStateManager.TransitionToScene(GameScene.Home);
    }

    public void OnFallSpriteClick()
    {
        StartCoroutine(PlayButtonClickSound());
        GameStateManager.TransitionToScene(GameScene.Fall);
    }

    public void OnMapButtonClick()
    {
        StartCoroutine(PlayButtonClickSound());
        GameStateManager.TransitionToScene(GameScene.Map);
    }

    public void OnExitClick()
    {
        StartCoroutine(PlayButtonClickSound());
        Application.Quit();
    }

    private IEnumerator PlayButtonClickSound()
    {
        clickButton.Play();
        yield return new WaitForSeconds(clickButton.clip.length);
    }
}
