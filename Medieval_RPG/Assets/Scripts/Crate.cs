using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Fighter
{
    [SerializeField] private AudioSource woodSoundEffect;

    protected override void Death()
    {
        woodSoundEffect.Play();
        Destroy(gameObject);
    }

}
