﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStats : MonoBehaviour {

    public float Playerhealth;
    public int PStocks;
    public int PSouls;
    bool isDead;



	// Use this for initialization
	void Start ()
    {
    Playerhealth = 100f;
    PStocks = 5;
    PSouls = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void PlayerDeath()
    {
        if (Playerhealth <= 0)
        {
            isDead = true;
            //Animación
            Destroy(gameObject, 0.5f);
        }
    }   
    
}
