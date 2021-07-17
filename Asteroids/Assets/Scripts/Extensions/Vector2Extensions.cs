using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 RotateByAngle(this Vector2 vector, float angleDegrees)
    {
        var directionDeviation = Quaternion.AngleAxis(angleDegrees, Vector3.forward);
        return directionDeviation * vector;
    }
}
