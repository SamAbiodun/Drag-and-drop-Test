using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip success;


    public void Placed()
    {
        source.PlayOneShot(success);
    }
}
