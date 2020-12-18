using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	//public string sceneToLoad = "MainGame";

    public void LoadGame ()
    {
		SceneManager.LoadScene("MainGame");
	}

}
