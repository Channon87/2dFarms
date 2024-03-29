using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{

    PlayerMovement characterController;
    Rigidbody2D rgdb2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1f;
    Character character;
    [SerializeField] HighlightController highlightController;


    private void Awake()
    {
        characterController = GetComponent<PlayerMovement>();
        rgdb2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }
    private void Update()
    {
        Check();

        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }
    private void Check()
    {
        Vector2 position = rgdb2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
      
        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject);
                return;
            }
        }
        highlightController.Hide();
    }
    private void Interact()
    {
        Vector2 position = rgdb2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
