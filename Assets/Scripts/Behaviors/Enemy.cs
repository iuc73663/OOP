﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
	private int health;
	private bool dead;
	private Text loseText;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		dead = false;
		audio = this.GetComponent<AudioSource> ();
		loseText = GameObject.Find("WinText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			dead = true;
		}
	}
		
	public bool isDead(){
		return dead;
	}
	public void setHealth(int h){
		health = h;
		print (health);
	}
	public void takeDamage(){
		health--;
		print (health);
	}

	public void takeDamage(int d){
		health = health - d;
	}

	void LoadNextLevel() {
		SceneManager.LoadScene ("Level 1");
	}

	void OnCollisionEnter2D (Collision2D other) {

		if (other.gameObject.CompareTag ("Player")) {
			Destroy(other.gameObject);
			audio.Play ();
			loseText.text = "Game Over";
			Invoke ("LoadNextLevel", 2);
		}
	}

}
