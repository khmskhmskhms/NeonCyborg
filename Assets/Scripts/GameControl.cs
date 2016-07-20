﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour {

	public bool SinglePlayer;
	public bool Training;

	private float _player1Score = 0;
	private float _player2Score = 0;

	// Use this for initialization
	void Start () {
		SpawnPlayers (true, SinglePlayer);
		if (Training) {
			Instantiate (Resources.Load ("Trainer"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("Score").GetComponent<Text>().text = "Player 1 : " + _player1Score + " | Player 2 : " + _player2Score;
	}

	void SpawnPlayers(bool first, bool onlyOne){

		GameObject[] spawns = GameObject.FindGameObjectsWithTag ("SpawnPoint");

		int firstNumber = Random.Range (0, spawns.Length);
		int secondNumber;

		do {
			secondNumber = Random.Range (0, spawns.Length);
		} while (secondNumber == firstNumber);

		GameObject firstSpawn = spawns [firstNumber];
		GameObject secondSpawn = spawns [secondNumber];


		if (first) {
			GameObject player1 = (GameObject)Instantiate (Resources.Load ("Player1"), transform.position, Quaternion.identity);
			player1.name = "Player1";
			player1.GetComponent<Player> ().PlayerIdentifier = "Player1";
			if(!onlyOne){
				GameObject player2 = (GameObject)Instantiate (Resources.Load ("Player2"), transform.position, Quaternion.identity);
				player2.name = "Player2";
				player2.GetComponent<Player> ().PlayerIdentifier = "Player2";
			}
		}
		GameObject.Find ("Player1").transform.position = firstSpawn.transform.position;
		if(!onlyOne) GameObject.Find ("Player2").transform.position = secondSpawn.transform.position;
	}

	public void AddPoints(string winner){
		if(winner == "Player1"){
			_player1Score ++;
		} else {
			_player2Score ++;
		}
	}
	public void RespawnPlayer(GameObject victim){
		GameObject[] spawns = GameObject.FindGameObjectsWithTag ("SpawnPoint");

		victim.transform.position = spawns [Random.Range (0, spawns.Length)].transform.position;
	}
}
