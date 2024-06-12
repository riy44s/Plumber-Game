using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
    public Transform pointTransform;
    public Vector2 rayDirection;
}

public class PipeConnection : MonoBehaviour
{

    public bool hasWater = false;
    public List<Point> points = new List<Point>();
    public bool isConnected = false;
    public bool isEndPipe = false;
    public bool isStartPipe = false;
    public string connectableTag = "Pipe";
    public LayerMask layerMask; // Layer mask to filter raycast hits
    public GameObject waterFill;

    private DraggItems draggableItem;

    private void Start()
    {
       
    }

    private void OnEnable()
    {
        CheckConnections();
        if (!isEndPipe)
        {
            draggableItem = GetComponent<DraggItems>();
        }
    }

    private void Update()
    {

        if (isStartPipe || isEndPipe || (draggableItem != null && draggableItem.isPlaced))
        {
            CheckConnections();
        }
        else
        {
            isConnected = false;
            hasWater = false;
        }

        SetWaterFill(hasWater);
    }

    public void ReleaseWater()
    {
        hasWater = false;
    }

    private void SetWaterFill(bool isActive)
    {
        waterFill.SetActive(isActive);
    }

    public void CheckConnections()
    {
        isConnected = false;

        foreach (Point point in points)
        {
            RaycastHit2D hit = Physics2D.Raycast(point.pointTransform.position, point.rayDirection, 0.3f, layerMask);

            Debug.DrawRay(point.pointTransform.position, point.rayDirection * 0.3f, Color.red);

            if (hit.collider != null && hit.collider.CompareTag(connectableTag))
            {
                PipeConnection hitPipelinePiece = hit.collider.gameObject.GetComponentInParent<PipeConnection>();
                if (hitPipelinePiece != null)
                {
                    hasWater = hitPipelinePiece.hasWater;
                }

                isConnected = true;
                break;
            }
            else
            {
                hasWater = false;
            }
        }
    }
}
