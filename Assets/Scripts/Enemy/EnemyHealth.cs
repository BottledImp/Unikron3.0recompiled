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


    public LayerMask mask;
    private void Damage()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.01f, mask);
        if (hit.collider.CompareTag("Player"))
        {
            hit.collider.GetComponent<PStats>().Playerhealth -= 10;
            //Instantiate(Effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
