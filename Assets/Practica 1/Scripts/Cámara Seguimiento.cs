using UnityEngine;

/// <summary>
/// Script de seguimiento de cámara para el juego de boliche.
/// La cámara sigue la bola suavemente, con anticipación (look-ahead) y evita colisiones.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform target;  // La bola de boliche

    [Header("Ajustes de seguimiento")]
    public Vector3 offset = new Vector3(0f, 5f, -8f);
    public float smoothTime = 0.2f;

    [Header("Anticipación (Look-Ahead)")]
    public float lookAheadFactor = 0.5f;
    public float maxLookAhead = 3f;

    [Header("Colisiones")]
    public float collisionRadius = 0.3f;
    public float collisionBuffer = 0.6f;
    public LayerMask collisionLayers;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody targetRb;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: No se asignó el objetivo (target).");
            enabled = false;
            return;
        }

        targetRb = target.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Calcular dirección hacia la cámara con offset base
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Look-ahead basado en velocidad de la bola
        Vector3 lookAhead = Vector3.zero;
        if (targetRb != null)
        {
            Vector3 velocityDir = targetRb.velocity;
            lookAhead = Vector3.ClampMagnitude(velocityDir * lookAheadFactor, maxLookAhead);
        }

        desiredPosition += lookAhead;

        // Detectar colisiones (para evitar que atraviese objetos)
        if (Physics.SphereCast(target.position, collisionRadius, desiredPosition - target.position, out RaycastHit hit, offset.magnitude, collisionLayers))
        {
            desiredPosition = hit.point + hit.normal * collisionBuffer;
        }

        // Movimiento suave hacia la posición deseada
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

        // Mirar hacia la bola
        transform.LookAt(target.position + lookAhead);
    }
}
