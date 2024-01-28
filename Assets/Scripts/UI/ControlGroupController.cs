using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGroupController : MonoBehaviour
{
   [SerializeField] private RectTransform[] _spawnGroups;
   private List<GameObject> _objects;

   public void Init(List<GameObject> objs)
   {
      _objects = new List<GameObject>();
      _objects.AddRange(objs);
      
      _objects[0].transform.SetParent(_spawnGroups[0]);
      _objects[1].transform.SetParent(_spawnGroups[1]);
      _objects[2].transform.SetParent(_spawnGroups[2]);

      var r = Random.Range(0, _spawnGroups.Length);
      
      for (var i = 2; i < _objects.Count; i++)
      {
         _objects[i].transform.SetParent(_spawnGroups[r]);
      }

      foreach (var obj in _objects)
      {
         obj.transform.localScale = Vector3.one;
      }
      gameObject.SetActive(true);
   }
   
   public void ClearObjects()
   {
      if(_objects.Count == 0) return;
      foreach (var obj in _objects)
      {
         Destroy(obj);
      }
      _objects = new List<GameObject>();
      gameObject.SetActive(false);
   }
}
