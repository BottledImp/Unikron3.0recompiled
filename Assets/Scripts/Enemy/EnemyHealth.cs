using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health = 100f;
    [SerializeField]
    float PH;

    private void Start()
    {
        PH = GameObject.FindGameObjectWithTag("Player").GetComponent<PStats>().Playerhealth;
    }

    private void Update() {
        Die();
    }

    private void Die () {
        if (health <= 0) {
            //Animación
            Destroy(gameObject, 0.5f); //Destruye el objeto, con un tiempo de delay (Objeto, delay)
        }
    }

}
