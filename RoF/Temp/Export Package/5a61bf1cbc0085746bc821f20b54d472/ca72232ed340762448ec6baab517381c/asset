using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Manager")]
    private InputManager input;

    private CharacterController player;
    private CharacterController reflectionChar;

    [Header("Movement Parameters")]
    [SerializeField] private Vector3 WorldDirection;
    private Vector3 velocity;
    private AudioSource walkSound;
    private float defaultSoundSpeed;

    [Header("Speed and Gravity")]
    public float currentSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float gravity = -0.5f;

    [Header("Look Parameters")]
    public Quaternion lookDirection;
    private float verticalRotation;
    public float sensitivity;
    public float upDownRange = 90;

    private Camera cam;

    private void Awake()
    {
        #region Get Managers
        input = GameObject.Find("InputManager").GetComponent<InputManager>();
        #endregion

        #region Get Components
        player = GetComponent<CharacterController>();
        walkSound = GetComponent<AudioSource>();
        #endregion

        #region Camera
        cam = Camera.main;
        #endregion

        #region
        defaultSoundSpeed = walkSound.pitch;
        #endregion
    }

    private void FixedUpdate()
    {
        HandleGravity();
        HandleMovement();
    }

    void Update()
    {
        HandleRotation();
        GetMovementInput();
    }

    private void GetMovementInput()
    {
        float horizontal = input.MoveInput.x;
        float vertical = input.MoveInput.y;
        Vector3 InputDirection = new Vector3(horizontal, velocity.y, vertical);
         
        WorldDirection = transform.TransformDirection(InputDirection);
        WorldDirection.Normalize();
    }

    private void HandleRotation()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        float mouseXRotation = input.LookInput.x * sensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= input.LookInput.y * sensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        lookDirection = Quaternion.Euler(verticalRotation, 0, 0);
        cam.transform.localRotation = lookDirection;
    }

    private void HandleGravity()
    {
        if (player.isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            return;
        }
        velocity.y += gravity;
    }
    private void HandleMovement()
    {
        currentSpeed = input.RunInput ? runSpeed : walkSpeed;
        Vector3 MovementDirection = WorldDirection * currentSpeed;

        player.Move(MovementDirection * Time.deltaTime);
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        float newPitch = defaultSoundSpeed * (currentSpeed / walkSpeed);
        walkSound.pitch = newPitch;

        if (player.velocity.magnitude > 0.1f)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else
        {
            walkSound.Stop();
        }
    }

    public void StopMove(){
        walkSpeed = 0;
    }
}
