using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace BirdHouseLibrary
{
    /// <summary>
    /// Класс для построения скворечника.
    /// </summary>
    public class HouseBuilder
    {
        /// <summary>
        /// Интерфейс компонента.
        /// </summary>
        private ksPart _iPart;

        /// <summary>
        /// Переменная смещения.
        /// </summary>
        private int _bias = 10;

        /// <summary>
        /// Построение прямоугольного скворечника.
        /// </summary>
        public void Build(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            this._iPart = iPart;
            CreateMain(iPart, kompas, houseParameters);
            CreateFastener(iPart, kompas, houseParameters);
            CreateHollow(iPart, kompas, houseParameters);
            CreateRoof(iPart, kompas, houseParameters);
            CreatePerch(iPart, kompas, houseParameters);
        }

        /// <summary>
        /// Построение прямоугольного корпуса скворечника.
        /// </summary>
        private void CreateMain(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            int thickness = houseParameters.Depth;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam part1 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part1.ang = 0; 
            part1.x = 0;
            part1.y = 0;
            part1.width = houseParameters.Width;
            part1.height = houseParameters.Height;
            part1.style = 1; 
            iDocument2D.ksRectangle(part1);
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Построение крепежа на задней стенке скворечника.
        /// </summary>
        private void CreateFastener(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            //Толщина выдавливания крепежа.
            int thickness = 30;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam part2 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part2.ang = 0; 
            part2.x = houseParameters.Width / 2 - houseParameters.WidthFasteners / 2; ;
            part2.y = houseParameters.Height;
            part2.width = houseParameters.WidthFasteners;

            //Высота крепежа.
            part2.height = 150;
            part2.style = 1;
            iDocument2D.ksRectangle(part2);
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Ппостроение крыши скворечника.
        /// </summary>
        private void CreateRoof(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            //Смещение по оси Z.
            int offset = 0;

            //Толщина выдавливания крыши.
            int thickness = 3;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam part3 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part3.ang = 0;
            part3.x = -_bias;
            part3.y = 0;
            part3.width = houseParameters.Width + (2* _bias);
            part3.height = thickness;
            part3.style = 1; 
            iDocument2D.ksRectangle(part3);
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, houseParameters.Depth + (2 * _bias), true);
        }

        /// <summary>
        /// Радиус дупла. 
        /// </summary>
        private int _radiusHollow = 21;

        /// <summary>
        /// Рразмещение дупла.
        /// </summary>
        private void CreateHollow(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            // Смещение по оси Z.
            int offset = houseParameters.Depth;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(houseParameters.Width / 2, 
            houseParameters.Height - houseParameters.HallowHeight - houseParameters.DiameterPerch / 2, _radiusHollow,1);

            iDefinitionSketch.EndEdit();
            ksEntity entityCutExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
            cutExtrDef.SetSketch(iSketch);
            cutExtrDef.directionType = (short)Direction_Type.dtNormal; 
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, 5, 0, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);
            entityCutExtr.Create();
        }

        /// <summary>
        /// Построение для жёрдочки.
        /// </summary>
        private void CreatePerch(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            // Смещение по оси Z.
            int offset = houseParameters.Depth;

            // Радиус жёрдочки.
            int radius = houseParameters.DiameterPerch/2;
            int thickness = houseParameters.LengthPerch;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(houseParameters.Width/2,
                houseParameters.Height - houseParameters.HallowHeight + _radiusHollow, radius, 1);
            iDefinitionSketch.EndEdit();
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Создание эскиза на плоскости XOZ.
        /// </summary>
        private void CreateSketch(out ksEntity iSketch, out ksSketchDefinition iDefinitionSketch, int offset = 0)
        {
            #region Создание смещенной плоскости -------------------------
            ksEntity iPlane = (ksEntity)_iPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition iPlaneDefinition = (ksPlaneOffsetDefinition)iPlane.GetDefinition();

            iPlaneDefinition.SetPlane(_iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ));
            iPlaneDefinition.direction = true;
            iPlaneDefinition.offset = offset;
            iPlane.Create();
            #endregion --------------------------------------------------

            iSketch = (ksEntity)_iPart.NewEntity((short)Obj3dType.o3d_sketch);
            iDefinitionSketch = iSketch.GetDefinition();
            iDefinitionSketch.SetPlane(iPlane);
            iSketch.Create();
        }

        /// <summary>
        /// Выдавливание по эскизу.
        /// </summary>
        private void ExctrusionSketch(ksPart iPart, ksEntity iSketch, int fatness, bool direction)
        {
            ksEntity entityExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition();
            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam();
            extrusionDef.SetSketch(iSketch);

            if (direction == false)
            {
                extrProp.direction = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrProp.direction = (short)Direction_Type.dtNormal;
            }

            extrProp.typeNormal = (short)End_Type.etBlind;
            if (direction == false)
            {
                extrProp.depthReverse = fatness;
            }
            else
            {
                extrProp.depthNormal = fatness;
            }
            entityExtr.Create();
        }

        /// <summary>
        /// Построение скворечника с цилиндрическим корпусом, все параметры поделены пополам для красивого отображения.
        /// </summary>
        public void BuildCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            this._iPart = iPart;
            CreateMainCylinder(iPart, kompas, houseParameters);
            CreateHollowCylinder(iPart, kompas, houseParameters);
            CreateRoofCylinder(iPart, kompas, houseParameters);         
            CreatePerchCylinder(iPart, kompas, houseParameters);
        }

        /// <summary>
        /// Радиус цилиндрического корпуса. 
        /// </summary>
        private int _radiusCylinder = 40;

        private void CreateMainCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            // Смещение по оси Z.
            int offset = 0;
            int thickness = houseParameters.Height / 2;

            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketchCylinder(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(0, 0, _radiusCylinder, 1);
            iDefinitionSketch.EndEdit();
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }

        /// <summary>
        /// Создание эскиза на плоскости XOY.
        /// </summary>
        private void CreateSketchCylinder(out ksEntity iSketch, out ksSketchDefinition iDefinitionSketch, int offset = 0)
        {
            #region Создание смещенной плоскости -------------------------
            ksEntity iPlane = (ksEntity)_iPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition iPlaneDefinition = (ksPlaneOffsetDefinition)iPlane.GetDefinition();

            iPlaneDefinition.SetPlane(_iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            iPlaneDefinition.direction = true;
            iPlaneDefinition.offset = offset;
            iPlane.Create();
            #endregion --------------------------------------------------

            iSketch = (ksEntity)_iPart.NewEntity((short)Obj3dType.o3d_sketch);
            iDefinitionSketch = iSketch.GetDefinition();
            iDefinitionSketch.SetPlane(iPlane);
            iSketch.Create();
        }

        /// <summary>
        /// Создание крыши для цилиндрического корпуса.
        /// </summary>
        private void CreateRoofCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            int offset = -4* _bias;
            int width = 90;
            int thickness = 3;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            ksRectangleParam part3 = (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            part3.ang = 0;
            part3.x = -width/2;
            part3.y = -(houseParameters.Height) / 2 - thickness;
            part3.width = width;
            part3.height = thickness;
            part3.style = 1; 
            iDocument2D.ksRectangle(part3);
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, width, true);
        }

        /// <summary>
        /// Размещение дупла цилиндрического корпуса.
        /// </summary>
        private void CreateHollowCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            int depth = 5;
            int radius = _radiusHollow/2;
            int offset = _radiusCylinder;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(0, -houseParameters.HallowHeight/2 - houseParameters.DiameterPerch/4, radius, 1);
            iDefinitionSketch.EndEdit();

            ksEntity entityCutExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
            cutExtrDef.SetSketch(iSketch);   
            cutExtrDef.directionType = (short)Direction_Type.dtNormal;
            cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, depth, 0, false);
            cutExtrDef.SetThinParam(false, 0, 0, 0);
            entityCutExtr.Create();
        }

        /// <summary>
        /// Построение жёрдочки цилиндрического корпуса.
        /// </summary>
        private void CreatePerchCylinder(ksPart iPart, KompasObject kompas, HouseParameters houseParameters)
        {
            // Смещение по оси Z
            int offset = _radiusCylinder;

            // Радиус жёрдочки
            int radius = houseParameters.DiameterPerch/4;
            int thickness = houseParameters.LengthPerch;
            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(0, -(houseParameters.HallowHeight / 2 - _radiusHollow / 2), radius, 1);
            iDefinitionSketch.EndEdit();
            iDefinitionSketch.EndEdit();

            ExctrusionSketch(iPart, iSketch, thickness, true);
        }
    }
}
