using System;

public enum MapType { Heightmap, Satellite };

public static class MapTypeExtensions
{
    public static string ToFriendlyString(this MapType type) {
        switch (type) {
            case MapType.Heightmap:
                return "Heightmap";
            case MapType.Satellite:
                return "Satellite";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
