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

    public void OnScrollClick()
    {
        Debug.Log("Click detected!");
        SceneManager.LoadScene("TaskInfo");
    }

    public void OnBackButtonClick()
    {
        Debug.Log("Click detected!");
        SceneManager.LoadScene("University");
    }

    public void OnStartButtonClick()
    {
        Debug.Log("Click detected!");
        SceneManager.LoadScene("Fall");
    }
}
