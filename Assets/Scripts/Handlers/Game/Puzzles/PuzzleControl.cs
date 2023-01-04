using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl : MonoBehaviour
{
    public Camera GameCamera;
    public GameObject Marker;
    private Player playerInput;

    [SerializeField] private PuzzlePiece p_selected = null;

    private void Awake()
    {
        playerInput = new Player();
    }

    // When enabled activate player input
    private void OnEnable()
    {
        playerInput.Enable();
    }

    // When disabled diactivate player input
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        Marker.SetActive(false);
    }

    public void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var unit = hit.collider.GetComponentInParent<PuzzlePiece>();
            p_selected = unit;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleSelection();
        } 
        else if (p_selected != null && playerInput.PuzzleMain.RotateRight.IsPressed())
        {
            //p_selected.RotateRight();
        }
        else if (p_selected != null && playerInput.PuzzleMain.RotateLeft.IsPressed())
        {
            //p_selected.RotateLeft();
        }

        MarkerHandling();
    }

    void MarkerHandling()
    {
        if (p_selected == null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
        }else if (p_selected != null && Marker.transform.parent != p_selected.transform)
        {
            Marker.SetActive(true);
            Marker.transform.SetParent(p_selected.transform, false);
            Marker.transform.localPosition = Vector3.zero;
        }
    }
}
