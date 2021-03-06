﻿/* 
 * GSND 6320 PSYCHOLOGY OF PLAY
 * PROJECT 1 DIGITAL PROTOTYPE
 * CODERS:
 * SIDAN FAN
 * JIN H KIM 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoControl : MonoBehaviour {

    Rigidbody rb;
    GameObject player;
    public float ammoDamage = 10f;
    public GameObject VFX_sparkPrefab;

    // has the enemy objects face the player
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        rb.AddForce((player.transform.position - transform.position).normalized * 2, ForceMode.Impulse);
	}

    // the enemy can become hostile and target the player
    // enemy dies after a certain number of ammo fired to player
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.GetComponent<PlayerControl>().GetHit(ammoDamage);
            GameObject vfx = Instantiate(VFX_sparkPrefab, transform.position, Quaternion.identity);
            Destroy(vfx, 2.0f);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == 9)
        {
            GameObject vfx = Instantiate(VFX_sparkPrefab, transform.position, Quaternion.identity);
            Destroy(vfx, 2.0f);
            Destroy(this.gameObject);
        }

    }
}
