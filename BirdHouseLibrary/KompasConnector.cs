﻿using System;
using Kompas6API5;
using Kompas6Constants3D;

namespace BirdHouseLibrary
{
    /// <summary>
    /// Класс для подключения к САПР КОМПАС-3D.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект Компас.
        /// </summary>
        private KompasObject _kompas = null;

        /// <summary>
        /// Документ компас3D.
        /// </summary>
        private ksDocument3D _doc3D = null;

        /// <summary>
        /// Интерфейс компонента.
        /// </summary>
        private ksPart _iPart = null;

        /// <summary>
        /// Соединение с САПР и передача параметров.
        /// </summary>
        public KompasConnector(HouseParameters houseParameters)
        {
            TakeKompas();
        }

        /// <summary>
        /// Свойства _kompas.
        /// </summary>
        public KompasObject kompas
        {
            get
            {
                return _kompas;
            }
            set
            {
                _kompas = value;
            }
        }
        /// <summary>
        /// Свойства _iPart.
        /// </summary>
        public ksPart iPart
        {
            get
            {
                return _iPart;
            }
            set
            {
                _iPart = value;
            }
        }

        /// <summary>
        ///Открыть деталь в Компасе.
        /// </summary>
        public void TakeKompas()
        {
            if (_kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(t);
            }         
            _kompas.Visible = true;
            _kompas.ActivateControllerAPI();

            _doc3D = (ksDocument3D)_kompas.Document3D();
            _doc3D.Create(false, true);
            _iPart = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
        }
    }
}
