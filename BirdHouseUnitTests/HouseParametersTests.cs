using System;
using NUnit.Framework;
using BirdHouseLibrary;

namespace BirdHouseUnitTests
{
    public class HouseParametersTests
    {
        /// <summary>
		/// Отдельный метод для избежания дублирования кода
		/// </summary>
        private HouseParameters _houseParameters;
        [SetUp]
        public void InitParameters()
        {
           _houseParameters = new HouseParameters(250,26, 25, 5, 120, 120, 30);
        }

        [Test(Description = "Позитивный тест геттера Height")]
        public void TestHeightGet_CorrectValue()
        {
            var expected = 250;
            var actual = _houseParameters.Height;
            Assert.AreEqual(expected, actual, "Геттер Height возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера Height")]
        public void TestHeightGet_IncorrectValue()
        {
            var wrongHeight = 240;        
           Assert.Throws<ArgumentException>(() => { _houseParameters.Height = wrongHeight; }, "message");
        }

        [Test(Description = "Позитивный тест сеттера Height")]
        public void TestHeightSet_CorrectValue()
        {
            var expected = 250;
            _houseParameters.Height = expected;
            Assert.AreEqual(expected, _houseParameters.Height, "Сеттер Height  устанавливает неправильное значение.");
        }
        [Test(Description = "Негативный тест сеттера Height")]
        public void TestHeightSet_IncorrectValue()
        {
            var wrongHeight = 240;
            Assert.Throws<ArgumentException>(
            () => { _houseParameters.Height = wrongHeight; },
            "message");
        }

        [Test(Description = "Позитивный тест геттера HallowHeight")]
        public void TestHallowHeightGet_CorrectValue()
        {
            var expected = 26;
            var actual = _houseParameters.HallowHeight;
            Assert.AreEqual(expected, actual, "Геттер HallowHeight возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера HallowHeight")]
        public void TestHallowHeightGet_IncorrectValue()
        {
            var wrongHallowHeight = 24;
            Assert.Throws<ArgumentException>(() => { _houseParameters.HallowHeight = wrongHallowHeight; }, "message");
        }

        [Test(Description = "Позитивный тест сеттера HallowHeight")]
        public void TestHallowHeightSet_CorrectValue()
        {
            var expected = 28;
            _houseParameters.HallowHeight = expected;
            Assert.AreEqual(expected, _houseParameters.HallowHeight, "Сеттер HallowHeight  устанавливает неправильное значение.");
        }
        [Test(Description = "Негативный тест сеттера HallowHeight")]
        public void TestHallowHeightSet_IncorrectValue()
        {
            var wrongHallowHeight = 24;
            Assert.Throws<ArgumentException>(
            () => { _houseParameters.HallowHeight = wrongHallowHeight; },
            "message");
        }

        [Test(Description = "Позитивный тест геттера LengthPerch")]
        public void TestLengthPerchGet_CorrectValue()
        {
            var expected = 25;
            var actual = _houseParameters.LengthPerch;
            Assert.AreEqual(expected, actual, "Геттер LengthPerch возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера LengthPerch")]
        public void TestLengthPerchGet_IncorrectValue()
        {
            var wrongLengthPerch = 12;
            Assert.Throws<ArgumentException>(() => { _houseParameters.LengthPerch = wrongLengthPerch; }, "message");
        }

        [Test(Description = "Позитивный тест сеттера LengthPerch")]
        public void TestLengthPerchSet_CorrectValue()
        {
            var expected = 25;
            _houseParameters.LengthPerch = expected;
            Assert.AreEqual(expected, _houseParameters.LengthPerch, "Сеттер LengthPerch  устанавливает неправильное значение.");
        }
        [Test(Description = "Негативный тест сеттера LengthPerch")]
        public void TestLengthPerchSet_IncorrectValue()
        {
            var wrongLengthPerch = 12;
            Assert.Throws<ArgumentException>(
            () => { _houseParameters.LengthPerch = wrongLengthPerch; },
            "message");
        }

        [Test(Description = "Позитивный тест геттера DiameterPerch")]
        public void TestDiameterPerchGet_CorrectValue()
        {
            var expected = 5;
            var actual = _houseParameters.DiameterPerch;
            Assert.AreEqual(expected, actual, "Геттер DiameterPerch возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера DiameterPerch")]
        public void TestDiameterPerchGet_IncorrectValue()
        {
            var wrongDiameterPerch = 12;
            Assert.Throws<ArgumentException>(() => { _houseParameters.DiameterPerch = wrongDiameterPerch; }, "message");
        }

        [Test(Description = "Позитивный тест сеттера DiameterPerch")]
        public void TestDiameterPerchSet_CorrectValue()
        {
            var expected = 5;
            _houseParameters.DiameterPerch = expected;
            Assert.AreEqual(expected, _houseParameters.DiameterPerch, "Сеттер DiameterPerch  устанавливает неправильное значение.");
        }
        [Test(Description = "Негативный тест сеттера DiameterPerch")]
        public void TestDiameterPerchSet_IncorrectValue()
        {
            var wrongDiameterPerch = 12;
            Assert.Throws<ArgumentException>(
            () => { _houseParameters.DiameterPerch = wrongDiameterPerch; },
            "message");
        }

        [Test(Description = "Позитивный тест геттера Depth")]
        public void TestDepthGet_CorrectValue()
        {
            var expected = 120;
            var actual = _houseParameters.Depth;
            Assert.AreEqual(expected, actual, "Геттер Depth возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера Depth")]
        public void TestDepthGet_IncorrectValue()
        {
            var wrongDepth = 110;
            Assert.Throws<ArgumentException>(() => { _houseParameters.Depth = wrongDepth; }, "message");
        }

        [Test(Description = "Позитивный тест сеттера Depth")]
        public void TestDepthSet_CorrectValue()
        {
            var expected = 120;
            _houseParameters.Depth = expected;
            Assert.AreEqual(expected, _houseParameters.Depth, "Сеттер Depth  устанавливает неправильное значение.");
        }
        [Test(Description = "Негативный тест сеттера Depth")]
        public void TestDepthhSet_IncorrectValue()
        {
            var wrongDepth = 110;
            Assert.Throws<ArgumentException>(
            () => { _houseParameters.Depth = wrongDepth; },
            "message");
        }

        [Test(Description = "Позитивный тест геттера Width")]
        public void TestWidthGet_CorrectValue()
        {
            var expected = 120;
            var actual = _houseParameters.Width;
            Assert.AreEqual(expected, actual, "Геттер Width возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера Width")]
        public void TestWidthGet_IncorrectValue()
        {
            var wrongWidth = 110;
            Assert.Throws<ArgumentException>(() => { _houseParameters.Width = wrongWidth; }, "message");
        }

        [Test(Description = "Позитивный тест сеттера Width")]
        public void TestWidthSet_CorrectValue()
        {
            var expected = 120;
            _houseParameters.Width = expected;
            Assert.AreEqual(expected, _houseParameters.Width, "Сеттер Width  устанавливает неправильное значение.");
        }
        [Test(Description = "Негативный тест сеттера Width")]
        public void TestWidthSet_IncorrectValue()
        {
            var wrongWidth = 110;
            Assert.Throws<ArgumentException>(
            () => { _houseParameters.Width = wrongWidth; },
            "message");
        }

        [Test(Description = "Позитивный тест геттера WidthFasteners")]
        public void TestWidthFastenersGet_CorrectValue()
        {
            var expected = 30;
            var actual = _houseParameters.WidthFasteners;
            Assert.AreEqual(expected, actual, "Геттер WidthFasteners возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера WidthFasteners")]
        public void TestWidthFastenersGet_IncorrectValue()
        {
            var wrongWidthFasteners = 20;
            Assert.Throws<ArgumentException>(() => { _houseParameters.WidthFasteners = wrongWidthFasteners; }, "message");
        }

        [Test(Description = "Позитивный тест сеттера WidthFasteners")]
        public void TestЕWidthFastenersSet_CorrectValue()
        {
            var expected = 30;
            _houseParameters.WidthFasteners = expected;
            Assert.AreEqual(expected, _houseParameters.WidthFasteners, "Сеттер WidthFasteners  устанавливает неправильное значение.");
        }
        [Test(Description = "Негативный тест сеттера WidthFasteners")]
        public void TestWidthFastenersSet_IncorrectValue()
        {
            var wrongWidthFasteners = 20;
            Assert.Throws<ArgumentException>(
            () => { _houseParameters.WidthFasteners = wrongWidthFasteners; },
            "message");
        }
    }
}
