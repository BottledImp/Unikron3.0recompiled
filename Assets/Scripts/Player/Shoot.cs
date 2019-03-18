using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    #region Variables
    public GameObject projectile;
    private float time;
    public GameObject pivot;
    public float startTime;
    #endregion

    private void Update() {
        ShootProjectile();
    }

    private void ShootProjectile () {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 90); //Add offset

        if (time <= 0) {
            if (Input.GetMouseButtonUp(0)) {
                Instantiate(projectile, pivot.transform.position, pivot.transform.rotation);
                time = startTime;

            }
        }
        else {
            time -= Time.deltaTime;
        }
    }

}
