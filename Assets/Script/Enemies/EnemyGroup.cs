using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour {
    public GameObject enemyGroupPrefab;
    public List<GameObject> group = new List<GameObject>();
    public int sizeOfGroup = 3;
    // Use this for initialization
    void Start() {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < sizeOfGroup; i++)
        {
            GameObject eg = Instantiate(enemyGroupPrefab, transform.position - new Vector3(0, -1 * i, 0), enemyGroupPrefab.transform.rotation, transform);
            group.Add(eg);
            if (i == 0)
                eg.GetComponent<EnemyGroupSpaceship>().SetLeader(true);
            eg.GetComponent<EnemyGroupSpaceship>().id = i;
        }
    }

    // Update is called once per frame
    void Update() {
        CheckGroup();
    }

    private void CheckGroup()
    {
        if (!group.TrueForAll(EnemyExists))
        {
            group.RemoveAll(EnemyNotExists);
            for (int i = 0; i < group.Count; i++)
                group[i].GetComponent<EnemyGroupSpaceship>().id = i;
        }
        if (group.Count <= 0)
            Destroy(gameObject);
    }

    private bool EnemyExists(GameObject obj)
    {
        return obj != null;
    }

    private bool EnemyNotExists(GameObject obj)
    {
        return obj == null;
    }

    public GameObject GetLeader()
    {
        return group[0].gameObject;
    }

    public GameObject GetNextShip(int index)
    {
        GameObject ship = null;
        if (index <= group.Count && index - 1 >= 0)
            ship = group[index - 1].gameObject;
        return ship;
    }

}
