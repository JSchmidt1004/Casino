using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RouletteBoard : MonoBehaviour
{
    public BetHandler betHandler;
    public NumberNode[] numberNodes;
    public Node[] nodes;
    Node selectedNode;

    void Start()
    {
        nodes = GetComponentsInChildren<Node>();
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

                foreach (Node node in nodes)
                {
                    if ((mousePosition.x <= node.transform.position.x + 20 && mousePosition.x >= node.transform.position.x - 20) 
                        && (mousePosition.y <= node.transform.position.y + 20 && mousePosition.y >= node.transform.position.y - 20))
                    {
                        node.Select();
                        int betAmount = betHandler.GetBetValue(true);
                        betHandler.UpdateTotal();

                        if (selectedNode != null) selectedNode.betAmount = betAmount;
                        selectedNode?.Deselect();
                         
                        selectedNode = node;
                        break;
                    }
                }
            }
        }
    }
}
