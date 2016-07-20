﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CollisionsAndTriggers : MonoBehaviour {

	public Player Owner;

	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Owner.CancelAttack ();
			Camera.main.gameObject.GetComponent<CameraManager> ().Shake (0.5f);
		}
		if (other.collider.gameObject.layer == LayerMask.NameToLayer ("Shield")) {
			Owner.CancelAttack ();
		}
	}
}