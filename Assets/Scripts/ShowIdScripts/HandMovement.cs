using UnityEngine;
using UnityEngine.InputSystem;

public class HandMovement : MonoBehaviour
{
    
    [Header("Player movement")]
    public float acceleration = 100f;
    public float maxSpeed = 200f;
    public float damping = 0.95f;

    [Header("Random movement")]
    public float minInterval = 2f;
    public float maxInterval = 3f;
    public float minForce = 10f;
    public float maxForce = 20f;
    private float nextRMTime;
    private Vector2 currentForce;

    private Vector2 velocity;
    public InputAction handMovement;
    public bool movementEnabled = true;

    void OnEnable()
    {
        handMovement.Enable();
    }

    void OnDisable()
    {
        handMovement.Disable();
    }
    void Start()
    {
        ScheduleNextRM();
    }

    void ScheduleNextRM()
    {
        nextRMTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    void ApplyRandomMovement()
    {
        nextRMTime = Time.time + Random.Range(minInterval, maxInterval);

        Vector2 direction = Random.insideUnitCircle.normalized;
        float strength = Random.Range(minForce, maxForce);

        currentForce = direction * strength;
    }

    void Update()
    {
        if (!movementEnabled) return;

        if (Time.time >= nextRMTime)
        {
            ApplyRandomMovement();
            ScheduleNextRM();
        }

        Vector2 input = handMovement.ReadValue<Vector2>();

        if (input.magnitude > 1f)
            input.Normalize();

        velocity += currentForce * Time.deltaTime;
        velocity += input * acceleration * Time.deltaTime;
        velocity *= damping;

        transform.position += (Vector3)(velocity * Time.deltaTime);
    }
}