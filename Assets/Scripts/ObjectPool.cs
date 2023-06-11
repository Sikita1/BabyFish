using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _containerEnemy;
    [SerializeField] private int _capacityEnemy;

    private List<GameObject> _poolEnemy = new List<GameObject>();

    //protected void Initialize(GameObject prefab)
    //{
    //    for (int i = 0; i < _capacity; i++)
    //    {
    //        GameObject spawned = Instantiate(prefab, _container.transform);
    //        spawned.SetActive(false);

    //        _pool.Add(spawned);
    //    }
    //}

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacityEnemy; i++)
        {
            GameObject spawned = Instantiate(prefabs[i], _containerEnemy.transform);
            spawned.SetActive(false);

            _poolEnemy.Add(spawned);
        }
    }

    protected bool TryGetRandomObject(out GameObject result)
    {
        List<GameObject> gameObjects = _poolEnemy.Where(enemy => enemy.activeSelf == false).ToList();

        result = gameObjects[Random.Range(0, gameObjects.Count)];

        return result != null;
    }
}
