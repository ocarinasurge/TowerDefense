using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManagerScript : MonoBehaviour {
    private List<GameObject> enemies;
    private GameObject[] enemiesUnsorted;
	// Use this for initialization
	void Start () {
	    enemies = new List<GameObject>();
        if(enemiesUnsorted==null){
            enemiesUnsorted=GameObject.FindGameObjectsWithTag("Monster");

        }
        for (int i = 0; i < enemiesUnsorted.Length; i++ )
        {
            for (int j = 0; j < enemiesUnsorted.Length; j++)
            {
                //Debug.Log(System.String.Format("" + unsortedPath[j]));

                if ((enemiesUnsorted[j].GetComponent<MonsterScript>().monsterNumber) == i) { 
                    enemies.Add(enemiesUnsorted[j]); 
                }

            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
