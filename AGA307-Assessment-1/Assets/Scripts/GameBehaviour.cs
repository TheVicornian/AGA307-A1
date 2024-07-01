using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public static List<T> ShuffleList<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int rNum = Random.Range(0, _list.Count);
            _list[i] = _list[rNum];
            _list[rNum] = temp;
        }

        return _list;
    }

 
}
