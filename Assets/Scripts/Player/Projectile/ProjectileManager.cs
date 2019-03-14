using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {

    #region Variables
    public float speed = 5f;
    public float fadeTime = 5f;
    private float cntr = 0;
    public float dmg = 10f;
    public GameObject Effect;
    #endregion

    private void Start() {
        
    }

    private void Update() {
        Fade();
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Damage();
    }

    private void Fade () {
        cntr += Time.deltaTime;
        if (cntr > fadeTime) {
            Destroy(gameObject);
        }
    }
    //Mask for environment and enemy
    public LayerMask mask;
    private void Damage () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.01f, mask);
        if (hit.collider.CompareTag("Enemy")) {
            hit.collider.GetComponent<EnemyHealth>().health -= 10;
            //Instantiate(Effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

}
