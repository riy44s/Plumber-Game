using UnityEngine;

public class DraggItems : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string DestinationTag = "Tile";
    Vector3 lastValidPosition;
    public bool isPlaced = false;

    [SerializeField] LayerMask placinglayer;
    [SerializeField] LayerMask pipeLayer;

    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void Start()
    {
        // Ensure the object starts slightly above the background to avoid z-fighting
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.01f);
        lastValidPosition = transform.position; // Initialize last valid position
    }

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
        isPlaced = false;
    }

    private void OnMouseUp()
    {
        collider2d.enabled = false;
        RaycastHit2D hitInfoPipe = Physics2D.Raycast(MouseWorldPosition(), Vector2.zero, Mathf.Infinity, pipeLayer);

        if (hitInfoPipe.collider != null)
        {

            Vector3 otherPipeLastPos = hitInfoPipe.transform.position;
            hitInfoPipe.transform.position = lastValidPosition;
            transform.position = otherPipeLastPos;
        }
        else
        {

            RaycastHit2D hitInfoPlacingLayer = Physics2D.Raycast(MouseWorldPosition(), Vector2.zero, Mathf.Infinity, placinglayer);

            if (hitInfoPlacingLayer.collider != null && hitInfoPlacingLayer.collider.tag == DestinationTag)
            {
                Transform destinationTransform = hitInfoPlacingLayer.transform;


                transform.position = destinationTransform.position + new Vector3(0, 0, -0.01f);

            }
            else
            {

                transform.position = lastValidPosition;
            }
        }

        collider2d.enabled = true;
        isPlaced = true;

    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
