using System.Collections.Generic;
using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    [SerializeField] private List<Slot> _slots;
    [SerializeField] private GameObject _figurePrefab;
    public void Spawn()
    {
        //тут можно спавнить в случайной а можно и нет. Случайная требует чуть больше строк кода
        List<Slot> freeSlots = new List<Slot>();
        for (int i = 0; i< _slots.Count; i++)
        {
            if( _slots[i].IsEmpty)
            {
                freeSlots.Add(_slots[i]);
            }
        }
        if (freeSlots.Count > 0) 
        {
            freeSlots[Random.Range(0,freeSlots.Count-1)].Spawn(_figurePrefab);
        }
    }
}
