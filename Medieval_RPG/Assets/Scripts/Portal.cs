using UnityEngine;

public class Portal : Collidable
{

    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //teleport player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[0];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

    }
}
