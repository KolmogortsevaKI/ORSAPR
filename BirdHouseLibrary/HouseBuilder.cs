using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace BirdHouseLibrary
{
    public class HouseBuilder
    {
        /// <summary>
        /// Интерфейс компонента
        /// </summary>
        public ksPart iPart;

        /// <summary>
        /// Построение прямоугольного скворечника
        /// </summary>
        public void Build(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            this.iPart = iPart;
            CreateMain(iPart, kompas, houseParameters);
            CreateFastener(iPart, kompas, houseParameters);
            CreateHollow(iPart, kompas, houseParameters);
            CreateRoof(iPart, kompas, houseParameters);
            CreatePerch(iPart, kompas, houseParameters);
        }

        /// <summary>
        /// Построение прямоугольного корпуса скворечника
        /// </summary>
        public void CreateMain(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            int thickness = houseParameters.Depth;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);
            // Интерфейс для рисования
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            // Построение прямоугольника (x1,y1, x2,y2, style)
            ksRectangleParam part1 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part1.ang = 0; //Угол ?
            part1.x = 10;
            part1.y = 10;
            part1.width = houseParameters.Width;
            part1.height = houseParameters.Height;
            part1.style = 1; // При нуле не видно деталь
            iDocument2D.ksRectangle(part1);

            // Закончить редактирование эскиза
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Построение крепежа на задней стенке скворечника
        /// </summary>
        public void CreateFastener(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            //Толщина выдавливания крепежа
            int thickness = 30;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);

            // Интерфейс для рисования = на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam part2 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part2.ang = 0; //Угол 
            part2.x = (houseParameters.Width) / 2;
            part2.y = 10 + houseParameters.Height;
            part2.width = houseParameters.WidthFasteners;
            //Высота крепежа
            part2.height = 150;
            part2.style = 1;
            iDocument2D.ksRectangle(part2);

            // Закончить редактирование эскиза
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Ппостроение крыши скворечника
        /// </summary>
        public void CreateRoof(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            //Смещение по оси Z 
            int offset = -10;
            //Толщина выдавливания крыши
            int thickness = 5;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования = на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            // Построение прямоугольника (x1,y1, x2,y2, style)
            ksRectangleParam part3 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part3.ang = 0; //Угол наклона
            part3.x = 0;
            part3.y = 10;
            part3.width = houseParameters.Width + 20;//Крыша выходит за границы корпуса на 20 мм
            part3.height = thickness; 
            part3.style = 1; // При нуле не видно деталь
            iDocument2D.ksRectangle(part3);

            // Закончить редактирование эскиза
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, houseParameters.Depth + 20, true);
        }

        /// <summary>
        /// Рразмещение дупла
        /// </summary>
        public void CreateHollow(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {

            // Смещение по оси Z
            int offset = houseParameters.Depth;
            // Радиус дупла
            int radius = 25;

            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования = на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(10 + (houseParameters.Width / 2), ((houseParameters.Height) - (houseParameters.HallowHeight)), radius, 1);

            // Закончить редактирование эскиза
            iDefinitionSketch.EndEdit();

            // Вырезание выдавливанием
            ksEntity entityCutExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
            cutExtrDef.SetSketch(iSketch);   
            cutExtrDef.directionType = (short)Direction_Type.dtNormal; //прямое направление
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, 20, 0, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);
            entityCutExtr.Create(); // Операция вырезание выдавливанием
        }

        /// <summary>
        /// Построение для жёрдочки
        /// </summary>
        public void CreatePerch(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            // Смещение по оси Z
            int offset = houseParameters.Depth;
            // Радиус жёрдочки
            int radius = houseParameters.DiameterPerch / 2;
            int thickness = houseParameters.LengthPerch;

            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования = на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(10 + (houseParameters.Width / 2),
                ((houseParameters.Height) - (houseParameters.HallowHeight) + 30), radius, 1);

            // Закончить редактировние эскиза
            iDefinitionSketch.EndEdit();
            iDefinitionSketch.EndEdit();
            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Создание эскиз на плоскости XOZ
        /// </summary>
        private void CreateSketch(out ksEntity iSketch, out ksSketchDefinition iDefinitionSketch, int offset = 0)
        {
            #region Создание смещенной плоскости -------------------------
            // интерфейс смещенной плоскости
            ksEntity iPlane = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);

            // Интрефейс настроек смещенной плоскости
            ksPlaneOffsetDefinition iPlaneDefinition = (ksPlaneOffsetDefinition)iPlane.GetDefinition();

            // Настройки: начальная позиция, направление смещения, расстояние от плоскости
            iPlaneDefinition.SetPlane(iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ));
            iPlaneDefinition.direction = true;
            iPlaneDefinition.offset = offset;
            iPlane.Create();
            #endregion --------------------------------------------------

            // Создаем обьект эскиза
            iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);

            // Получение интерфейса настроек эскиза
            iDefinitionSketch = iSketch.GetDefinition();

            // Устанавка плоскости эскиза
            iDefinitionSketch.SetPlane(iPlane);

            // Создать эскиз
            iSketch.Create();
        }

        // <summary>
        /// Выдавливание по эскизу
        /// </summary>
        private void ExctrusionSketch(ksPart iPart, ksEntity iSketch, int fatness, bool direction)
        {
            //Операция выдавливания
            ksEntity entityExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);

            //Интерфейс операции выдавливания
            ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition();

            //Интерфейс структуры параметров выдавливания
            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam();

            //Эскиз операции выдавливания
            extrusionDef.SetSketch(iSketch);

            //Направление выдавливания
            if (direction == false)
            {
                extrProp.direction = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrProp.direction = (short)Direction_Type.dtNormal;
            }

            //Тип выдавливания
            extrProp.typeNormal = (short)End_Type.etBlind;

            //Глубина выдавливания
            if (direction == false)
            {
                extrProp.depthReverse = fatness;
            }
            else
            {
                extrProp.depthNormal = fatness;
            }
            //Создание операции выдавливания
            entityExtr.Create();
        }

        /// <summary>
        /// Построение скворечник с цилиндрическим корпусом, все параметры поделены пополам для красивого отображения
        /// </summary>
        public void BuildCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            this.iPart = iPart;
            CreateMainCylinder(iPart, kompas, houseParameters);
            CreateHollowCylinder(iPart, kompas, houseParameters);
            CreateRoofCylinder(iPart, kompas, houseParameters);
            CreatePerchCylinder(iPart, kompas, houseParameters);
        }
        //Радиус цилиндрического корпуса 
        private int radiusCylinder = 40;
        public void CreateMainCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            // Смещение по оси Z
            int offset = 0;
            int thickness = houseParameters.Height / 2;

            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketchCylinder(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования = на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(10, 10, radiusCylinder, 1);

            // Закончить редактирование эскиза
            iDefinitionSketch.EndEdit();
            iDefinitionSketch.EndEdit();
            ExctrusionSketch(iPart, iSketch, thickness, true);
        }
        /// <summary>
        /// Создание эскиза на плоскости XOY
        /// </summary>
        private void CreateSketchCylinder(out ksEntity iSketch, out ksSketchDefinition iDefinitionSketch, int offset = 0)
        {
            #region Создание смещенной плоскости -------------------------
            // Интерфейс смещенной плоскости
            ksEntity iPlane = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);

            // Получение интрефейса настроек смещенной плоскости
            ksPlaneOffsetDefinition iPlaneDefinition = (ksPlaneOffsetDefinition)iPlane.GetDefinition();

            // Настройки: начальная позиция, направление смещения, расстояние от плоскости
            iPlaneDefinition.SetPlane(iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            iPlaneDefinition.direction = true;
            iPlaneDefinition.offset = offset;
            iPlane.Create();
            #endregion --------------------------------------------------

            // Создание обьекта эскиза
            iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);

            // Получение интерфейс настроек эскиза
            iDefinitionSketch = iSketch.GetDefinition();

            // Устанавка плоскости эскиза
            iDefinitionSketch.SetPlane(iPlane);

            //Создание эскиза
            iSketch.Create();
        }
        /// <summary>
        /// Создание крыши для цилиндрического корпуса
        /// </summary>
        public void CreateRoofCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            int offset = -30;
            int thickness = 5;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;
            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            // Построение прямоугольника (x1,y1, x2,y2, style)
            ksRectangleParam part3 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part3.ang = 0;
            part3.x = -35;
            part3.y = -(houseParameters.Height) / 2 - thickness;
            part3.width = 90;
            part3.height = thickness; 
            part3.style = 1; // При нуле не видно деталь
            iDocument2D.ksRectangle(part3);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, 90, true);
        }

        /// <summary>
        /// Размещение дупла цилиндрического корпуса
        /// </summary>
        public void CreateHollowCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            int depth = 20;
            int radius = 12;
            int offset = radiusCylinder + depth;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования = на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(0, -houseParameters.HallowHeight / 2 - houseParameters.DiameterPerch / 4, radius, 1);

            // Закончить редактирование эскиза
            iDefinitionSketch.EndEdit();

            // Вырезание выдавливанием
            ksEntity entityCutExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
            cutExtrDef.SetSketch(iSketch);    // установка эскиза операции
            cutExtrDef.directionType = (short)Direction_Type.dtNormal; //прямое направление
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, depth, 0, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);
            entityCutExtr.Create(); // Операция вырезание выдавливанием
        }

        /// <summary>
        /// Построение жёрдочки цилиндрического корпуса
        /// </summary>
        public void CreatePerchCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            // Смещение по оси Z
            int offset = radiusCylinder + houseParameters.LengthPerch / 4;
            // Радиус жёрдочки
            int radius = houseParameters.DiameterPerch / 4;
            int thickness = houseParameters.LengthPerch;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);

            // Интерфейс для рисования = на скетче
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            iDocument2D.ksCircle(0, -((houseParameters.HallowHeight / 2) - 12), radius, 1);
            // Закончить редактирование эскиза
            iDefinitionSketch.EndEdit();
            iDefinitionSketch.EndEdit();
            ExctrusionSketch(iPart, iSketch, thickness, true);
        }
    }
}
