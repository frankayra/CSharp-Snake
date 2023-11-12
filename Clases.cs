using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{

    public enum GameMode
    {
        Edited,
        Default
    }

    [Serializable]
    public class SerializableClass
    {
        public readonly int[,] Field;
        public readonly int Eggs_number;
        public SerializableClass(int[,] Field, int eggs)
        {
            this.Field = Field;
            Eggs_number = eggs;
        }
    }

    public enum Direction { UP, RIGHT, DOWN, LEFT }
    public interface Coordinates<T>
    {
        Coordinates<T> CoordinateAt(int inc_x, int inc_y);
        int Distance(Coordinates<T> xy);
        int X { get; set; }
        int Y { get; set; }
        int MaxX { get; }
        int MaxY { get; }
    }

    #region Kinds of Coordinates 

    public struct CircularCoordinates : Coordinates<CircularCoordinates>
    {
        static int[] incR = { -1, 0, 1, 0 };
        static int[] incC = { 0, 1, 0, -1 };
        Direction direction;
        int pos_x, pos_y;
        public readonly int max_x, max_y;
        public CircularCoordinates(int x, int y, Direction direction, int maxx, int maxy)
        {
            if (x < 0 || y < 0) throw new InvalidOperationException("Coordenadas negativas");
            max_x = maxx;
            max_y = maxy;
            this.direction = direction;
            pos_x = x;
            pos_y = y;
        }

        public int X
        {
            get { return pos_x; }
            set
            {
                pos_x = value < 0
                ? (value + max_x) % max_x
                : (value) % max_x;
            }
        }
        public int Y
        {
            get { return pos_y; }
            set
            {
                pos_y = value < 0
                ? (value + max_y) % max_y
                : (value) % max_y;
            }
        }
        public int MaxX => max_x;
        public int MaxY => max_y;

        public void GO(Direction direction)
        {
            this.direction = direction;
            GO();
        }
        public void GO()
        {
            X += incC[(int)direction];
            Y += incR[(int)direction];
        }
        public CircularCoordinates CoordinatesAt(Direction direction, int casillas)
        {
            CircularCoordinates xy = this;
            for (int c = 0; c < casillas; c++)
            {
                xy.GO(direction);
            }
            return xy;
        }
        public CircularCoordinates CoordinatesAt(int casillas)
        {
            return CoordinatesAt(direction, casillas);
        }
        public Direction GetDirection => direction;


        public static int Distance(CircularCoordinates xy, CircularCoordinates xz)
        {
            return Math.Min(LineDistance(xy, xz, Direction.DOWN),
                Math.Min(LineDistance(xy, xz, Direction.LEFT),
                Math.Min(LineDistance(xy, xz, Direction.RIGHT),
                LineDistance(xy, xz, Direction.UP))));
        }
        private static int LineDistance(CircularCoordinates xy, CircularCoordinates xz, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                case Direction.DOWN:
                    if (xy.X == xz.X)
                        return Math.Abs(xy.Y - xz.Y);
                    //return 1 + LineDistance(xy.CoordinatesAt(direction, 1), xz, direction);
                    return xy.X - xz.X < 0 ? xy.X + xy.max_x - xz.X : xz.X - xy.X;
                case Direction.LEFT:
                case Direction.RIGHT:
                    if (xy.Y == xz.Y)
                        return Math.Abs(xy.X - xz.X);
                    //return 1 + LineDistance(xy.CoordinatesAt(direction, 1), xz, direction);
                    return xy.Y - xz.Y < 0 ? xy.Y + xy.max_y - xz.Y : xz.Y - xy.Y;
            }
            return 0;
        }
        public override string ToString()
        {
            return "X: " + X + "_ Y: " + Y;
        }

        public Coordinates<CircularCoordinates> CoordinateAt(int inc_x, int inc_y)
        {
            return new CircularCoordinates(
                inc_x < 0 ? (X + max_x + inc_x) % max_x : (X + inc_x) % max_x,
                inc_y < 0 ? (Y + max_y + inc_y) % max_y : (Y + inc_y) % max_y, Direction.DOWN, max_x, max_y);
        }

        public int Distance(Coordinates<CircularCoordinates> xy)
        {
            return Distance(this, (CircularCoordinates)xy);
        }
        public static bool operator ==(CircularCoordinates xy, CircularCoordinates xz) => xy.X == xz.X && xy.Y == xz.Y;
        public static bool operator !=(CircularCoordinates xy, CircularCoordinates xz) => !(xy == xz);
    }

    #endregion

    public class Objec
    {
        int number;
        public int Value
        {
            get => number;
            set => number = value;
        }
        public Type GetType =>
            number < 0 ? new Obstacle().GetType() :
            number == 0 ? new VoidCell().GetType() :
                                      new Egg(number).GetType();
        public Objec(int number) => this.number = number;
        public Objec() => number = 0;
    }
    public class VoidCell : Objec { public VoidCell() : base(0) { } }
    public class Obstacle : Objec { public Obstacle() : base(-1) { } }
    public class Egg : Objec { public Egg(int number) : base(Math.Abs(number)) { } }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Tipo de Campo</typeparam>
    /// <typeparam name="K">Tipo de Coordenadas(Coordinates)</typeparam>
    public struct World<T, K>
    {
        public readonly T[,] Matrix;
        Tuple<int, int> camera_range;
        public World(T[,] field, int camera_range_x, int camera_range_y)
        {
            Matrix = field;
            camera_range = camera_range = new Tuple<int, int>(camera_range_x, camera_range_y);
        }
        public int X => Matrix.GetLength(0);
        public int Y => Matrix.GetLength(1);
        public int CameraX => camera_range.Item1;
        public int CameraY => camera_range.Item2;
        public T[,] CameraMatrix(Coordinates<K> center)
        {
            T[,] TempMatrix = new T[camera_range.Item1, camera_range.Item2];
            Coordinates<K> xz = center.CoordinateAt(-(camera_range.Item1 / 2), -(camera_range.Item2 / 2));
            for (int i = 0; i < camera_range.Item1; i++)
                for (int f = 0; f < camera_range.Item2; f++)
                {
                    Coordinates<K> Temporal_Coordinates = xz.CoordinateAt(i, f);
                    TempMatrix[i, f] = Matrix[Temporal_Coordinates.X, Temporal_Coordinates.Y];
                }
            return TempMatrix;
        }
        /// <summary>
        /// Traduce de una de las Coordenadas del interior del rango de la matriz de la camara a sus respectivas coordenadas reales en el Campo.
        /// </summary>
        /// <param name="center">Centro del rango de vision de la camara</param>
        /// <param name="pseudo_x">Abcisa de la coordenada a traducir</param>
        /// <param name="pseudo_y">Ordenada de la coordenada a traducir</param>
        /// <returns></returns>
        public Coordinates<K> TranslateCoordinate(Coordinates<K> center, int pseudo_x, int pseudo_y)
        {
            return center.CoordinateAt(-(camera_range.Item1 / 2) + pseudo_x, -(camera_range.Item1 / 2) + pseudo_y);
        }
        /// <summary>
        /// Al reves. Particularmente este metodo no devuelve una Coordenada en si, por el hecho de que toda Coordenada
        /// representada en el Campo debe estar supuesta realmente sobre este, debido a que a pesar de que el rango 
        /// del "pseudo campo"
        /// que constituye la matriz que abarca la vision de la camara es diferente a la del Campo, el trabajo con los
        /// maximos y minimos de las coordenadas es el mismo y, al devolver una coordenada donde sus maximos y minimos
        /// serian adecuados a la camara, esto alteraria el desplazamiento de la misma por el terreno.
        /// </summary>
        /// <param name="center">Centro del rango de vision de la camara</param>
        /// <param name="real_coordinate">Coordenada real (en la matrixz que representa el campo</param>
        /// <returns></returns>
        public Tuple<int, int> TranslateCoordinate(Coordinates<K> center, Coordinates<K> real_coordinate)
        {
            throw new NotImplementedException();
        }
        public T this[int i, int j]
        {
            get => Matrix[i, j];
            set => Matrix[i, j] = value;
        }
    }
    public class Snake
    {
        CircularCoordinates xy;
        public readonly int color_pos;        
        public Snake(int pos_x, int pos_y, int max_x, int max_y, Direction direction, int pos_color)
        {
            color_pos = pos_color;
            xy = new CircularCoordinates(pos_x, pos_y, direction, max_x, max_y);
        }
        public Snake(CircularCoordinates xz, int pos_color)
        {
            xy = xz;
            color_pos = pos_color;
        }
        public CircularCoordinates XY { get { return xy; } }
        public void GO()
        {
            xy.GO();
        }
        public Direction GetDirection
        {
            get { return xy.GetDirection; }
        }
        public void ChangeDirection(Direction direction)
        {
            xy = (int)((xy.GetDirection) + 2) % 4 == (int)direction ? xy : new CircularCoordinates(xy.X, xy.Y, direction, xy.max_x, xy.max_y);
        }
    }    
}
