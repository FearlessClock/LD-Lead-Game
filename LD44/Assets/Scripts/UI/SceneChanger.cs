using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToScene(string name){
		UnityEngine.SceneManagement.SceneManager.LoadScene(name);
	}

    public void AddScene(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public void UnloadScene(string name)
    {
        SceneManager.UnloadSceneAsync(name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

	public void Quit(){
		Application.Quit();
	}
}
