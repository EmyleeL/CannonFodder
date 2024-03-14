using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPathing : MonoBehaviour
{

    public Transform ShipNodes;

    private Transform CurrentNode;

    private int CurrentChildIndex;

    public float ShipSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // stating the "Current node" or where thing will move next
        CurrentNode = ShipNodes.GetChild(CurrentChildIndex); 
    }

    // Update is called once per frame
    void Update()
    {
        //moving ship to current node
        if (CurrentNode != null)
        {

            transform.position = Vector3.MoveTowards(transform.position, CurrentNode.position, ShipSpeed * Time.deltaTime);
            transform.LookAt(CurrentNode.position);

            //updating current node when reached
            if (transform.position == CurrentNode.position)
            {
                CurrentChildIndex = (CurrentChildIndex + 1) % ShipNodes.childCount;

                CurrentNode = ShipNodes.GetChild(CurrentChildIndex);
            }

        }
        
    }
}
