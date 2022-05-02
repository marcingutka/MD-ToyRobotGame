﻿using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Helpers
{
    internal static class CreatorHelper
    {
       internal static Robot CreateRobot(int x, int y, OrientationState orientation) =>
            new() { Position = new GridPosition { X = x, Y = y, Orientation = orientation } };

        internal static GridPoint CreateGridPoint(int x, int y, bool isWall) =>
            new() { Position = new GridPosition { X = x, Y = y }, IsWall = isWall };
    }
}
