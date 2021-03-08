using Shapes;
using System.Collections;
using UnityEngine;

/// <summary>
/// Информация об одной планете
/// </summary>
[RequireComponent(typeof(Disc))]
public class Planet : MonoBehaviour
{
    private const int GENERATE_COUNT_SHIP_IN_SEC = 5;
    private const int SEC = 1;

    public int CurrentShipCount { get; private set; } = 0;

    private float planetSize = 0;

    private bool isActiveFactory = false;

    private Disc shape;

    private Coroutine workingFactory = null;

    /// <summary>
    /// Инициализировать планету
    /// </summary>
    public void Init(float size)
    {
        shape = GetComponent<Disc>();

        planetSize = size;

        shape.Radius = planetSize;

        StartFactoryShip();
    }

    /// <summary>
    /// Добавить корабли к счетчику планеты
    /// </summary>
    /// <param name="countShip"></param>
    public void AddCountShip(int countShip)
    {
        CurrentShipCount += countShip;
    }

    /// <summary>
    /// Отнять корабли от счетчика планеты
    /// </summary>
    /// <param name="countShip"></param>
    public void RemoveCountShip(int countShip)
    {
        CurrentShipCount -= countShip;
    }

    private void StartFactoryShip()
    {
        if (workingFactory != null) StopCoroutine(workingFactory);
        workingFactory = StartCoroutine(StartFactory());
    }

    private IEnumerator StartFactory()
    {
        isActiveFactory = true; 

        while (isActiveFactory)
        {
            var wait = SEC / GENERATE_COUNT_SHIP_IN_SEC;
            yield return new WaitForSeconds(wait);
            CurrentShipCount++;
        }
    }

    private void StopFactory()
    {
        isActiveFactory = false;

        if (workingFactory != null) StopCoroutine(workingFactory);
    }
}
