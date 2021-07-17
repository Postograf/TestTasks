using UnityEngine;

public static class CameraExtensions
{
    public static float PixelToUnit(this Camera camera, int pixelsCount)
    {
        return pixelsCount * camera.orthographicSize * 2 / camera.pixelHeight;
    }
}
