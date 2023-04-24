using System.Drawing;
using static QuoridorApp.Constants;

namespace QuoridorApp.Model
{
    // class that represents a pawn on the board and have 3 properties: location, last location and wall count that the pawn has left 
    public class Pawn
    {
        public Cell Location;
        private int _wallCount; // the number of walls that the pawn has left
        public Cell LastLocation;

        public Pawn(Cell startLocation)
        {
            Location = startLocation;
            _wallCount = WallsPerPlayer;
        }

        // method that sets the location of the pawn to the new location and saves the last location of the pawn
        public void SetLocation(Cell newLocation)
        {
            LastLocation = Location;
            Location = newLocation;
        }
        // reduce the number of walls that the pawn has left by 1
        public void PlaceWall()
        {
            _wallCount--;
        }
        // return the number of walls that the pawn has left
        public int GetWallCount()
        {
            return _wallCount;
        }
        // set the number of walls that the pawn has left
        public void SetWallCount(int wallCount)
        {
            _wallCount = wallCount;
        }
        // increase the number of walls that the pawn has left by 1
        public void RemoveWall()
        {
            _wallCount++;
        }
    }
}