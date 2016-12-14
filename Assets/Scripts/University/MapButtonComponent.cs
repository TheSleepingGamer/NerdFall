using UnityEngine;
using System.Collections;

public class MapButtonComponent : MonoBehaviour {
    public AudioSource clickButton;

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
