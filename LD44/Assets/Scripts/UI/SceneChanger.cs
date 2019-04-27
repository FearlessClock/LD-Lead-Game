using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void GoToScene(string name){
		UnityEngine.SceneManagement.SceneManager.LoadScene(name);
	}
}
