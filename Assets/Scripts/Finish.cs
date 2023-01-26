using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Win;
    public AudioSource FinishSound;

    void Start()
    {
        FinishSound = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        FinishSound.Play();
        Win.SetActive(true);
    }
}
