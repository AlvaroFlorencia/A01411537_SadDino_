using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// The change the scene
	public void LoadLevel(string levelName) {
		SceneManager.LoadScene(levelName);
	}

	// To quit the application
	public void EndGame() {
		Application.Quit();
	}
}
