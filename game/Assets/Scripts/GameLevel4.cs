﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameLevel4 : GameSystem, IGameSystem {

	// change game level here
	private static int LEVEL = 4;

	void Start () {
		Run ();
	}

	void Update () {
		ObservePauseButton ();
		ObserveMonsters ();
        if (isOver) {
            StartCoroutine(LoadScene());
        }
	}

	public override void Initialize(){
		Init ();
		startingCoordinates.Add (new Vector3 (-11f, 3.8f, 1));		// starting coordinate for enemies
		startingCoordinates.Add (new Vector3 (-11f, 0.33f, 1));		// you can add more starting coordinate based on the routes on your map
		startingCoordinates.Add (new Vector3 (-11f, -3.2f, 1));		// monster factory will be generated based on the number of starting coordinates
		MovePattern.setInstance(LEVEL);
		ig = new ItemGenerator (0.9f); // items spawn rate
		SetUp();
	}

	public override void Play(){
		timer.Run ();
		StartCoroutine (Spawn());
		StartCoroutine (ig.Generate ());
	}

	// how the enemies will be spawned, use enum "Monsters" to select the enemy you want to spawn
	public IEnumerator Spawn() {
		// choose which monster factory you want to spawn the monster
		// the number of monster factories in "mfs" variable is equal to the number of starting coordinates
		monsters.Add(mfs[0].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[1].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[2].getMonster(Monsters.bt));
		yield return new WaitForSeconds(8);
		monsters.Add(mfs[0].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[1].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[2].getMonster(Monsters.bt));
        yield return new WaitForSeconds(5);
        monsters.Add(mfs[0].getMonster(Monsters.rt));
        monsters.Add(mfs[1].getMonster(Monsters.rt));
        monsters.Add(mfs[2].getMonster(Monsters.rt));
        yield return new WaitForSeconds(2);
        monsters.Add(mfs[0].getMonster(Monsters.goomba));
        yield return new WaitForSeconds(2);
        monsters.Add(mfs[1].getMonster(Monsters.goomba));
        yield return new WaitForSeconds(2);
        monsters.Add(mfs[2].getMonster(Monsters.goomba));
        yield return new WaitForSeconds(5);
        monsters.Add(mfs[0].getMonster(Monsters.rt));
        yield return new WaitForSeconds(2);
        monsters.Add(mfs[1].getMonster(Monsters.goomba));
        yield return new WaitForSeconds(2);
        monsters.Add(mfs[2].getMonster(Monsters.bt));
        yield return new WaitForSeconds(6);
        monsters.Add(mfs[0].getMonster(Monsters.bt));
        yield return new WaitForSeconds(2);
        monsters.Add(mfs[1].getMonster(Monsters.bt));
        yield return new WaitForSeconds(2);
        monsters.Add(mfs[2].getMonster(Monsters.bt));

		numberOfMonsters = monsters.Count;
	}

    public IEnumerator LoadScene() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Level + 1);
    }

	public int Level {
		get {
			return LEVEL;
		}
	}

	public bool IsPaused {
		get {
			return isPaused;
		}
	}

	public bool IsOver {
		get {
			return isOver;
		}
	}

	public ArrayList MonsterList {
		get {
			return monsters;
		}
	}

}