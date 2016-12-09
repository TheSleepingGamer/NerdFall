using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class OnClickTrigger : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click detected!");
    }
   
    public void OnUniversitySpriteClick()
    {
        GameStateManager.TransitionToScene(GameScene.University);
    }

    public void OnHomeSpriteClick()
    {
        GameStateManager.TransitionToScene(GameScene.Home);
    }

    public void OnFallSpriteClick()
    {
        GameStateManager.TransitionToScene(GameScene.Fall);
    }

    public void OnMapButtonClick()
    {
        GameStateManager.TransitionToScene(GameScene.Map);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
