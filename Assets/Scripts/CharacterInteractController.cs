using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float interactableArea = 1.2f;

    Character character;
    CharacterController2D characterController;
    Rigidbody2D rb2D;


    private void Awake()
    {
        character = GetComponent<Character>();
        characterController = GetComponent<CharacterController2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Vector2 position = rb2D.position + characterController.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, interactableArea);

        foreach(Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();

            if(hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
