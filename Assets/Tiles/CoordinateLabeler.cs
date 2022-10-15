using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int gridPosition = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        DisplayCoordinates();
        gridManager = FindObjectOfType<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ToggleLabels();
        ColorCoordinates();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void ColorCoordinates()
    {
        if (gridManager)
        {
            Node node = gridManager.GetNode(gridPosition);
            if (node == null) { return; }
            if (node.isWalkable)
            {
                label.color = defaultColor;
            }
            if (node.isExplored)
            {
                label.color = exploredColor;
            }
            if (node.isPath)
            {
                label.color = pathColor;
            }
            else
            {
                label.color = blockedColor;
            }
        }
    }

    private void DisplayCoordinates()
    {
        if(gridManager == null) { return; }
        gridPosition.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        gridPosition.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = $"{gridPosition.x},{gridPosition.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = gridPosition.ToString();
    }
}
