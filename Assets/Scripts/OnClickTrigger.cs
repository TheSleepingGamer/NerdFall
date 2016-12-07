using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class OnClickTrigger : MonoBehaviour, IPointerClickHandler
{
    public  GameObject taskInfo;

    public void Start()
    {
        taskInfo.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click detected!");
    }

    public void OnScrollClick()
    {
        taskInfo.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        GameStateManager.TransitionToScene(GameScene.University);
        taskInfo.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        GameStateManager.TransitionToScene(GameScene.Fall);
        taskInfo.SetActive(false);
    }
}
