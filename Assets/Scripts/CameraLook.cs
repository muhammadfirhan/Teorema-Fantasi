using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; // Make sure to import Cinemachine Class

// Make sure the script need to have the required component to never separate dependency
[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    // Cinemachine object for camera
    private CinemachineFreeLook cinemachine;

    // Input action object
    private Player playerInput;

    // Look speed variable
    [SerializeField]
    private float lookSpeed = 1;

    // On awake initialize player input and cinemachine
    private void Awake()
    {
        playerInput = new Player();
        cinemachine = GetComponent<CinemachineFreeLook>();
    }

    // On enable activate player input
    private void OnEnable()
    {
        playerInput.Enable();
    }

    // On disable diactivate player input
    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    // Calculate camera adjustment input
    void Update()
    {
        // Get Vector2 data from player input on look method in input action
        Vector2 delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        // Set cinemachine X axis value with delta x input
        cinemachine.m_XAxis.Value += delta.x * 150 * lookSpeed * Time.deltaTime;
        // Set cinemachine Y axis value with delta y input
        cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }
}
