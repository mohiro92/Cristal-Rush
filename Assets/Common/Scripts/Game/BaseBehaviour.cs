using System;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Randoms;
using UnityEngine;
using UnityEngine.AI;

public class BaseBehaviour : MonoBehaviour
{
    protected T SpawnPrefab<T> (T prefab) where T : MonoBehaviour
    {
        GameObject prefabGameObject = Instantiate(prefab.gameObject);
        prefabGameObject.transform.SetParent(transform, false);
        return prefabGameObject.GetComponent<T>();
    }
}
