using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapsBoard : MonoBehaviour
{
    public BetHandler betHandler;
    public BetButton[] boardNodes;
    public Node[] nodes;
    Node selectedNode;
    // Start is called before the first frame update
    void Start()
    {
        nodes = GetComponentsInChildren<Node>();
        boardNodes = GetComponentsInChildren<BetButton>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector3.forward);

        if (hit.collider != null && hit.collider.CompareTag("CrapsBoard"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;

                foreach (Node node in nodes)
                {
                    if ((mousePosition.x <= node.transform.position.x + 40 && mousePosition.x >= node.transform.position.x - 40)
                        && (mousePosition.y <= node.transform.position.y + 40 && mousePosition.y >= node.transform.position.y - 40))
                    {
                        Debug.Log("node in nodes");
                        node.Select();
                        int betAmount = betHandler.GetBetValue(true);
                        betHandler.UpdateTotal();

                        if (selectedNode != null) selectedNode.betAmount = betAmount;
                        Debug.Log(selectedNode.name);
                        selectedNode?.Deselect();

                        selectedNode = node;
                        break;
                    }
                }
            }
        }
    }
}
