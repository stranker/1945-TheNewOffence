using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour{

    public List<GameObject> items;
    public int dropProb;

    public void DropItem(Vector3 pos)
    {
        if (Random.Range(1,10) > dropProb)
        {
            if (items.Count > 0)
            {
                int typeDrop = Random.Range(0, items.Count);
                Instantiate(items[typeDrop], pos, items[typeDrop].transform.rotation, transform.parent);
            }
        }
    }
}
