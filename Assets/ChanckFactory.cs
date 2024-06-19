using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class ChanckFactory : MonoBehaviour
{
    [SerializeField] private List<Chanck> _chancks;
    [SerializeField] private float _Offset = 8;

    private bool _gameStart = false;

    private List<Chanck> _instanceChancks = new();
    private int MaxCount = 100;
    private Transform _lastInctance;

    private void Start()
    {
        _lastInctance = transform;
        _gameStart = true;
        StartCoroutine(InstanceChanck());
    }


    private IEnumerator InstanceChanck()
    {
        var waitForSecons = new WaitForSecondsRealtime(1f);
        while (_gameStart && _instanceChancks.Count >= MaxCount)
        {
            var indexChanck = Random.Range(0, _chancks.Count);
            var instantiateChanck = Instantiate(_chancks[indexChanck], transform);
            instantiateChanck.transform.position = _lastInctance.transform.position + new Vector3(0, _Offset, 0);
            _lastInctance = instantiateChanck.transform;
            _instanceChancks.Add(instantiateChanck);
            yield return waitForSecons;
        }
    }

    public void Reset()
    {
        if (!_gameStart)
            return;

        foreach (var chanck in _instanceChancks)
        {
            chanck.Reset();
        }
    }
}