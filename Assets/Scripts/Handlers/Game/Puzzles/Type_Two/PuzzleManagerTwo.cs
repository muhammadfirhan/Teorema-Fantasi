using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerTwo : MonoBehaviour
{
    // Insert the camera used
    public Camera GameCamera;
    // Insert marker game object used
    public GameObject marker;
    // Insert game object that holds number of piece needed
    public GameObject piecesHolder1;
    // Array of object pieces from the holder
    public GameObject[] pieces1;
    public PuzzleTypeTwoHandler canvasObject;

    // Total number of pieces
    [SerializeField] int totalpieces1 = 0;
    // Total number of correct pieces
    [SerializeField] int correctPieces = 0;
    // The object piece selected
    [SerializeField] private Block b_Selected = null;

    private void Start()
    {
        // Make sure that marker object set to false
        marker.SetActive(false);
        // Get the number of object from holder
        totalpieces1 = piecesHolder1.transform.childCount;
        // Initialize the array of object
        pieces1 = new GameObject[totalpieces1];
        // Loop that will iterate for each object in holder
        for (int i = 0; i < pieces1.Length; i++)
        {
            // Insert the object into the array
            pieces1[i] = piecesHolder1.transform.GetChild(i).gameObject;
        }
    }

    // Method that will handle when object is selected
    public void HandleSelection()
    {
        // Vector3 position to get the mouse position from the camera
        // The z axis calculate where the input location from camera z axis
        // Because it's in 2D, we use this (And the camera z axis are -10 in this case)
        // Basically it made the z axis as -10 + 10 = 0
        Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        // Vector2 position that will be casted from screen to world point on camera pov
        Vector2 ray = GameCamera.ScreenToWorldPoint(vector);
        // Raycast Hit 2D that will detect the collider if hit
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        // Check if the raycast hit a collider or no
        if (hit.collider != null)
        {
            // Get the Block component from the hitted collider
            var block = hit.collider.GetComponentInParent<Block>();
            // Set the selected object with the block
            b_Selected = block;
        }
    }

    // Method that will handle action after object is selected
    public void HandleAction()
    {
        // Vector3 position to get the mouse position from the camera
        // The z axis calculate where the input location from camera z axis
        // Because it's in 2D, we use this (And the camera z axis are -10 in this case)
        // Basically it made the z axis as -10 + 10 = 0
        Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        // Vector2 position that will be casted from screen to world point on camera pov
        Vector2 ray = GameCamera.ScreenToWorldPoint(vector);
        // Raycast Hit 2D that will detect the collider if hit
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        // Check if the raycast hit a collider or no
        if (hit.collider != null)
        {
            // First we check if the player select / the raycast hits other block object
            // We try to get the block component from the hit collider
            var blockPlaced = hit.collider.GetComponentInParent<Block>();
            // Checks if it was a block or area
            if (blockPlaced == null)
            {
                // If null then we get the block area component that will be the place for the block
                // We try to get the block area component from the hit collider
                var blockArea = hit.collider.GetComponentInParent<BlockArea>();
            
                if(blockArea.correctBlock.name.Equals(b_Selected.name))
                {
                    b_Selected.transform.position = blockArea.transform.position;
                    b_Selected.isPlaced = true;
                    CorrectMove();
                    b_Selected = null;
                } 
                else
                {
                    if(b_Selected.isPlaced == true)
                    {
                        correctPieces -= 1;
                        b_Selected.isPlaced = false;
                    }
                    b_Selected.transform.position = blockArea.transform.position;
                    WrongMove();
                }
            }
            else
            {
                b_Selected = blockPlaced;
            }
        }
    }

    public void CorrectMove()
    {
        correctPieces += 1;

        if (correctPieces == totalpieces1)
        {
            Debug.Log("You win");
            canvasObject.GameEnded = true;
            canvasObject.ResultScreen(1);
        }
    }

    public void WrongMove()
    {
        StartCoroutine(ReturnPos());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && b_Selected == null)
        {
            HandleSelection();
        }
        else if (b_Selected != null && Input.GetMouseButtonDown(0))
        {
            HandleAction();
        }

        MarkerHandling();
    }

    IEnumerator ReturnPos()
    {
        yield return new WaitForSeconds(2);
        b_Selected.transform.position = new Vector3(b_Selected.posX, b_Selected.posY, b_Selected.transform.localPosition.z);
        b_Selected = null;
    }

    void MarkerHandling()
    {
        if (b_Selected == null && marker.activeInHierarchy)
        {
            marker.SetActive(false);
            marker.transform.SetParent(null);
        }
        else if (b_Selected != null && marker.transform.parent != b_Selected.transform)
        {
            marker.SetActive(true);
            marker.transform.SetParent(b_Selected.transform, false);
            marker.transform.localScale = new Vector3(1, 1, 1);
            marker.transform.localPosition = Vector3.zero;
        }
    }
}
