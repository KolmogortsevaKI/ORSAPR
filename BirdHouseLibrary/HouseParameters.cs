using System;

namespace BirdHouseLibrary
{
    /// <summary>
    /// Класс, содержащий параметры скворечника.
    /// </summary>
    public class HouseParameters
    {
        /// <summary>
        /// Высота скворечника.
        /// </summary>
        private int _height;
        /// <summary>
        /// Высота расположения дупла.
        /// </summary>
        private int _hallowHeight;
        /// <summary>
        /// Длина жёрдочки.
        /// </summary>
        private int _lengthPerch;
        /// <summary>
        /// Диаметр жёрдочки.
        /// </summary>
        private int _diameterPerch;
        /// <summary>
        /// Глубина скворечника.
        /// </summary>
        private int _depth;
        /// <summary>
        /// Ширина скворечника.
        /// </summary>
        private int _width;
        /// <summary>
        /// Ширина крепежа.
        /// </summary>
        private int _widthFasteners;

        /// <summary>
        /// Проверка вхождения в диапазон минимально и максимально допустимых значений.
        /// </summary>
        private int SetParams(int min, int max, int value)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Incorrect values ( " + value +
                                            " ) it must be from" +
                                            min + " to " + max);
            }
            return value;
        }

        /// <summary>
        /// Создает экземпляр класса HouseParameters для прямоугольного корпуса.
        /// </summary>
        public HouseParameters(int height,
            int hallowHeight,
            int lengthPerch,
            int diameterPerch,
            int depth,
            int width,
            int widthFasteners)
        {
            Height = height;
            HallowHeight = hallowHeight;
            LengthPerch = lengthPerch;
            DiameterPerch = diameterPerch;
            Depth = depth;
            Width = width;
            WidthFasteners = widthFasteners;
        }
        /// <summary>
        /// Создает экземпляр класса HouseParameters для цилиндррического корпуса.
        /// </summary>
        public HouseParameters(int height,
            int hallowHeight,
            int lengthPerch,
            int diameterPerch
           )
        {
            Height = height;
            HallowHeight = hallowHeight;
            LengthPerch = lengthPerch;
            DiameterPerch = diameterPerch;
        }

        /// <summary>
        /// Возвращает и задаёт высоту скворечника.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                SetParams(250, 500, value);
                _height = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт высоту расположения дупла.
        /// </summary>
        public int HallowHeight
        {
            get
            {
                return _hallowHeight;
            }
            set
            {
                SetParams(26, Height - 26, value);
                _hallowHeight = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт длину жёрдочки.
        /// </summary>
        public int LengthPerch
        {
            get
            {
                return _lengthPerch;
            }
            set
            {
                if (value == 0 || value <= 35 && value >= 25)
                    _lengthPerch = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр жёрдочки.
        /// </summary>
        public int DiameterPerch
        {
            get
            {
                return _diameterPerch;
            }
            set
            {
                if (value == 0 || value <= 10 && value >= 5)
                    _diameterPerch = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт глубину скворечника.
        /// </summary>
        public int Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                SetParams(120, 190, value);
                _depth = value;

            }
        }

        /// <summary>
        /// Возвращает и задаёт ширину скворечника.
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                SetParams(120, 190, value);
                _width = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт ширину крепежа скворечника.
        /// </summary>
        public int WidthFasteners
        {
            get
            {
                return _widthFasteners;
            }
            set
            {
                SetParams(30, 50, value);
                _widthFasteners = value;
            }
        }
    }
}
