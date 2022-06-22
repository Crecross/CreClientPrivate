using VRC;
using System;
using CreClient.Modules;

namespace CreClient.Settings
{ 
    public class Shared
    {
        private static Player targetPlayer;
        public static Player TargetPlayer
        {
            get => targetPlayer;
            set
            {
                targetPlayer = value;
            }
        }

    }
}