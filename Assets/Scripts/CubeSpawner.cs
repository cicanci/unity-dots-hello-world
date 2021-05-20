using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab = null;

    [SerializeField]
    private int _size = 10;

    [SerializeField]
    private bool _useECS = false;

    private float _spacer = 1.5f;

    private void Start()
    {
       if(_useECS)
       {
           CreateCubesECS();
       }
       else
       {
           CreateCubes();
       }
    }

    private void CreateCubes()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                for (int k = 0; k < _size; k++)
                {
                    Vector3 position = new Vector3(i * _spacer, j * _spacer, k * _spacer);

                    Instantiate(_cubePrefab, position, Quaternion.identity, transform);
                }
            }
        }
    }

    private void CreateCubesECS()
    {
        var world = World.DefaultGameObjectInjectionWorld;
        var manager = world.EntityManager;
        var settings = new GameObjectConversionSettings(world, GameObjectConversionUtility.ConversionFlags.AssignName);
        var cubeEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(_cubePrefab, settings);

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                for (int k = 0; k < _size; k++)
                {
                    Vector3 position = new Vector3(i * _spacer, j * _spacer, k * _spacer);

                    var cube = manager.Instantiate(cubeEntityPrefab);
                    manager.SetComponentData(cube, new Translation { Value = position });
                }
            }
        }
    }
}
