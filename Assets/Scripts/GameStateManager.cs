using UnityEngine.SceneManagement;

public static class GameStateManager
{
    public static void TransitionToScene(GameScene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}