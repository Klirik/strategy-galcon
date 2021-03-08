using UnityEngine;
public class MapGenerator : MonoBehaviour
{
    private const float MIN_PLANET_SIZE = 0.5f;
    private const float MAX_PLANET_SIZE = 3f;

    public Planet PlanetTemplate = null;
    public Transform PlanetsContainer = null;

    public float Height = 600;
    public float Width = 800;

    public int OneMapStep = 10;

    public int MaxCountPlanets = 10;

    private void Start()
    {
        Height = 2 * Camera.main.orthographicSize;
        Width = Height * Camera.main.aspect;

        var countHori = 0;
        var countVert = 0;

        var h = Height / countHori;
        var w = Width / countVert;

        for (var indW = 0; indW < countHori; indW++)
        {
            for (var indH = 0; indH < countVert; indH++)
            {
                var position = new Vector2(indW * w + MAX_PLANET_SIZE, indH * h + MAX_PLANET_SIZE);
                CreatePlanet(CalculatePlanetSize(position));
            }
        }
    }

    private float coef = 1f;

    private void CreatePlanet(float planetSize)
    {
        var planet = Instantiate(PlanetTemplate, PlanetsContainer);
        planet.transform.position = coef * Random.insideUnitCircle;

        planet.Init(planetSize);
    }
    public float CalculatePlanetSize(Vector2 posInRect)
    {
        //TODO:
        posInRect += Random.insideUnitCircle;

        return Random.Range(MIN_PLANET_SIZE, MAX_PLANET_SIZE);
    }
}

