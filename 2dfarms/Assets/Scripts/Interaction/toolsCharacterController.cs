using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class toolsCharacterController : MonoBehaviour
{
    PlayerMovement character;
    Rigidbody2D rgdb2d;
    ToolbarController toolbarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] ToolAction onTilePickup;
    

    Vector3Int selecectedTilePosition;
    bool selectable;
    private void Awake()
    {
        character = GetComponent<PlayerMovement>();
        rgdb2d = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true){
                return; 
            }
            useToolGrid();
        }
    }
    private void SelectTile()
    {
        selecectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }
    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }
    private void Marker()
    {
       
        markerManager.markedCellPosition = selecectedTilePosition;
    }
    private bool UseToolWorld()
    {
        Vector2 position = rgdb2d.position + character.lastMotionVector * offsetDistance;

        Item item = toolbarController.GetItem;
        if (item == null)
        {
            return false;
        }
        if(item.onAction == null)
        {
            return false;
        }
       bool complete =  item.onAction.OnApply(position);
        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }
        }
        return complete;
    }
    private void useToolGrid()
    {
        if (selectable == true)
        {
            Item item = toolbarController.GetItem;
            if(item == null) {
                PickUpTile();
                return; }
            if (item.onTileMapAction == null) { return; }

            bool complete = item.onTileMapAction.OnApplyToTileMap(selecectedTilePosition, tileMapReadController, item);
            if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }
    }
    public void PickUpTile()
    {
        if(onTilePickup == null) { return; }

        onTilePickup.OnApplyToTileMap(selecectedTilePosition, tileMapReadController, null);
    }
}
