using UnityEngine;
using System.Collections;

public class TaskInfoComponent : MonoBehaviour
{

   // public ScrollComponent activeScroll;

    public void OnBackButtonClick()
    {
        this.gameObject.SetActive(false);
        GameStateManager.TransitionToScene(GameScene.University);
    }

    public void OnStartButtonClick()
    {
        this.gameObject.SetActive(false);
        GameStateManager.TransitionToScene(GameScene.Fall);
    }
}
