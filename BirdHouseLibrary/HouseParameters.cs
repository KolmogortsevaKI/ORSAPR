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
        /// Длина жердочки.
        /// </summary>
        private int _lengthPerch;
        /// <summary>
        /// Диаметр жердочки.
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
        /// Создает экземпляр класса HouseParameters для прямоугольного корпуса
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
        /// Создает экземпляр класса HouseParameters для цилиндррического корпуса
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
        /// Возвращает и задаёт высоту скворечника от 250-500мм.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value <= 500 && value >= 250)
                    _height = value;
                else
                    throw new ArgumentException("Height has to be from 250 mm 500 mm.");
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
                if (value < 25 || value > (_height - 25))
                {
                    throw new ArgumentException("");
                }

                _hallowHeight = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт длину жердочки.
        /// </summary>
        public int LengthPerch
        {
            get
            {
                return _lengthPerch;
            }
            set
            {
                if (value == 0)
                    _lengthPerch = 0;
                else if (value <= 35 && value >= 25)
                    _lengthPerch = value;
                else
                    throw new ArgumentException("Length perch has to be more 25 mm and less than 35 mm.");
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр жердочки.
        /// </summary>
        public int DiameterPerch
        {
            get
            {
                return _diameterPerch;
            }
            set
            {
                if (LengthPerch == 0)
                    _diameterPerch = 0;
                else if (value <= 10 && value >= 5)
                    _diameterPerch = value;
                else
                    throw new ArgumentException("Diameter perch has to be more 5 mm and less 10 mm.");
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
                if (value <= 190 && value >= 120)
                    _depth = value;
                else
                    throw new ArgumentException("Depth has to be more 120 mm and less 190 mm");
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
                if (value <= 190 && value >= 120)
                    _width = value;
                else
                    throw new ArgumentException("Width has to be more 120 mm and less 190 mm.");
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
                if (value <= 50 && value >= 30)
                    _widthFasteners = value;
                else
                    throw new ArgumentException("Width fasteners has to be more 30 mm and less 50 mm.");
            }
        }
    }
}
