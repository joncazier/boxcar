using UnityEngine;
using System.Collections;

public class TakeHits : MonoBehaviour {

	public float Health = 3;

	private Animator anim;

	void Awake() {
		anim = GetComponent<Animator> ();
	}

	int getState(Collider2D obj) {
		Animator anim = obj.GetComponentInParent<Animator>();
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
		return info.fullPathHash;
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		int swingAnim = Animator.StringToHash ("Base Layer.swing");

		if (collisionInfo.collider.name == "Sword" && swingAnim == getState(collisionInfo.collider)) {
			if (Health > 1) {
				Health--;
				anim.SetTrigger ("Hit");
				print ("Sword hit: " + Health);
			} else {
				//Destroy(this.gameObject);
				anim.SetTrigger ("Fall");
				StartCoroutine (delayDestroy ());
				print ("Object died");
			}
		}
	}

	private IEnumerator delayDestroy() {
		yield return new WaitForSeconds (0.8f);
		Destroy (this.gameObject);
	}

}
