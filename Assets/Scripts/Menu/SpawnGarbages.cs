using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnGarbages : MonoBehaviour
{
    [SerializeField] private GameObject _containerGarbages;
    [SerializeField] private Garbage[] _garbageTemplate;
    [SerializeField] private Transform _minRandomX;
    [SerializeField] private Transform _maxRandomX;
    [SerializeField] private Transform _minRandomY;
    [SerializeField] private Transform _maxRandomY;
    [SerializeField] private Score _score;

    [SerializeField] private int _leftoverTrash;

    public UnityAction ChangedAward;
    private List<Garbage> _garbages = new List<Garbage>();

    private WaitForSeconds _delay;

    private float _interval = 0.4f;
    private int _fullTurn = 360;

    public int CollectedCount { get; private set; }

    private void Start()
    {
        StartCoroutine(Spawn(0.1f, -3));
        StartCoroutine(Spawn(0.4f, -2));
        StartCoroutine(Spawn(0.7f, -1));
        StartCoroutine(Spawn(1f, 0));
    }

    public int GetLeftoverTrash() => _leftoverTrash;

    private void DestroyGarbage(Garbage garbage)
    {
        CollectedCount++;
        _score.ScoreUp(1);
        _garbages.Remove(garbage);
        garbage.GarbageCountChanged -= DestroyGarbage;

        TryLevelUp();
    }

    private void TryLevelUp()
    {
        if (CollectedCount % _leftoverTrash == 0)
        {
            foreach (var garbage in _garbages)
                garbage.LayerUp();

            StartCoroutine(Spawn(0.1f, -3));
            ChangedAward?.Invoke();
        }
    }

    private IEnumerator Spawn(float alfa, int orderlayer)
    {
        _delay = new WaitForSeconds(_interval);

        for (int i = 0; i < _leftoverTrash; i++)
        {
            Quaternion randomQuaternion = Quaternion.Euler(0, 0, Random.Range(0, _fullTurn));

            Garbage randomGarbage = GetRandomGarbage();

            float randonPositionX = Random.Range(_minRandomX.position.x, _maxRandomX.position.x);
            float randomPositionY = Random.Range(_minRandomY.position.y, _maxRandomY.position.y);

            randomGarbage.SetLayer(alfa, orderlayer);

            Garbage garbage = Instantiate(randomGarbage, new Vector2(randonPositionX, randomPositionY), randomQuaternion, _containerGarbages.transform);

            garbage.GarbageCountChanged += DestroyGarbage;

            _garbages.Add(garbage.GetComponent<Garbage>());

            yield return _delay;
        }
    }

    private int GetRandonNumber() => Random.Range(7, 13);

    private Garbage GetRandomGarbage()
    {
        int randomIndex = Random.Range(0, _garbageTemplate.Length);
        return _garbageTemplate[randomIndex];
    }
}
