using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneOnCollide : MonoBehaviour {

	public string PortalToScene = "TestScene2";

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{

		if (collisionInfo.collider.name == "Bert") {
			SceneManager.LoadScene (PortalToScene, mode: LoadSceneMode.Single);
		}

	}
}
