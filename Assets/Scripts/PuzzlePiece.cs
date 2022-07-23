using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip appear, success;

    [SerializeField] private string tagname;

    public Transform slot;

    private bool dragging;

    public bool placed;

    private Vector2 offset, originalPosition;

    //private PuzzleSlot slot;


    private void Awake()
    {
        slot = GameObject.FindWithTag(tagname).transform;
        originalPosition = transform.position;
    }
    private void Update()
    {
        if (placed)
        {
            return;
        }
        if (!dragging)
        {
            return;
        }

        var mousePosition = transform.position = GetMousePos() - offset;
    }
    void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, slot.transform.position) < 2)
        {
            transform.position = slot.position;
            source.PlayOneShot(success);
            placed = true;
        }

        else
        {
            transform.position = originalPosition;
            dragging = false;
        }
    }
    void OnMouseDown()
    {
        dragging = true;
        //source.PlayOneShot();

        offset = GetMousePos() - (Vector2)transform.position;
        //mouse is down
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
