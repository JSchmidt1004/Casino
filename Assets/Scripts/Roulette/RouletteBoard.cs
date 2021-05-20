using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RouletteBoard : MonoBehaviour
{
    public NumberNode[] numberNodes;
    Node selectedNode;

    void Start()
    {
        numberNodes = GetComponentsInChildren<NumberNode>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector3.forward);

        if (hit.collider != null && hit.collider.CompareTag("RouletteBoard"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;

                foreach (Node node in numberNodes)
                {
                    if ((mousePosition.x <= node.transform.position.x + 20 && mousePosition.x >= node.transform.position.x - 20) 
                        && (mousePosition.y <= node.transform.position.y + 20 && mousePosition.y >= node.transform.position.y - 20))
                    {
                        node.Select();
                        selectedNode?.Deselect();
                        selectedNode = node;
                        break;
                    }
                }
            }
        }
    }
}
