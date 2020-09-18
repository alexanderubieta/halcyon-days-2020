using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public AudioSource damagedSFX;
    void OnColliderEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            damagedSFX.Play();
            other.GetComponent<PlayerHealth>().arms -= 1;
        }
    }
}
