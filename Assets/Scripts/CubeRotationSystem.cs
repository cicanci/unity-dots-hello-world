using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class CubeRotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, ref Rotation rotation, in CubeRotationSpeed speed) => 
        {
            var rotationAmount = speed.Value * deltaTime * Mathf.Deg2Rad;
            var rotationQuaternion = quaternion.Euler(0, rotationAmount, 0);
            var newRotation = math.mul(rotationQuaternion, rotation.Value);
            rotation.Value = newRotation;
        }).ScheduleParallel();
    }
}
