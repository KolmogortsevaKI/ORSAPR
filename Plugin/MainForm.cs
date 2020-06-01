using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BirdHouseLibrary;

namespace Plugin
{
    public partial class MainForm : Form
    {
        private KompasConnector kompasConnector;
        /// <summary>
        /// Переменная для валидации параметров.
        /// </summary>
        private bool _init = true;
        public MainForm()
        {
            InitializeComponent();
            InitializeParams();
        }

        /// <summary>
        /// Обработчик кнопки "Clean".
        /// </summary>
        private void CleanButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = string.Empty;
            }     
        }

        /// <summary>
        /// Обработчик, ограничивающий ввод символов в поле.
        /// </summary>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!(e.KeyChar > 47 && e.KeyChar < 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        /// <summary>
        /// Обработчик кнопки "Build".
        /// </summary>
        private void Build_Click(object sender, EventArgs e)
        {
            if (diameterPerchBox.Text == "" && (string)housingBox.SelectedItem == "Rectangle")
            {
                HouseParameters houseParameters = new HouseParameters(int.Parse(heightBox.Text),
                  int.Parse(hallowBox.Text), Convert.ToInt32(0), Convert.ToInt32(0),
                  int.Parse(depthBox.Text), int.Parse(widthBox.Text), int.Parse(fastenersBox.Text));
                kompasConnector = new KompasConnector(houseParameters);
                HouseBuilder housebuilder = new HouseBuilder();
                housebuilder.Build(kompasConnector.iPart, kompasConnector.kompas, houseParameters);
            }
            else if (diameterPerchBox.Text != "" && (string)housingBox.SelectedItem == "Rectangle")
            {
                HouseParameters houseParameters = new HouseParameters(int.Parse(heightBox.Text),
                  int.Parse(hallowBox.Text), int.Parse(lengthPerchBox.Text), int.Parse(diameterPerchBox.Text),
                  int.Parse(depthBox.Text), int.Parse(widthBox.Text), int.Parse(fastenersBox.Text));
                kompasConnector = new KompasConnector(houseParameters);
                HouseBuilder housebuilder = new HouseBuilder();
                housebuilder.Build(kompasConnector.iPart, kompasConnector.kompas, houseParameters);
            }
            else if (diameterPerchBox.Text != "")
            {
                HouseParameters houseParameters = new HouseParameters(int.Parse(heightBox.Text),
                  int.Parse(hallowBox.Text), int.Parse(lengthPerchBox.Text), int.Parse(diameterPerchBox.Text)
                  , Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0));
                kompasConnector = new KompasConnector(houseParameters);
                HouseBuilder housebuilder = new HouseBuilder();
                housebuilder.BuildCylinder(kompasConnector.iPart, kompasConnector.kompas, houseParameters);
            }
            else
            {
                HouseParameters houseParameters = new HouseParameters(int.Parse(heightBox.Text),
                  int.Parse(hallowBox.Text), Convert.ToInt32(0), Convert.ToInt32(0)
                  , Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0));
                kompasConnector = new KompasConnector(houseParameters);
                HouseBuilder housebuilder = new HouseBuilder();
                housebuilder.BuildCylinder(kompasConnector.iPart, kompasConnector.kompas, houseParameters);
            }
        }

        /// <summary>
        /// Инициализация начальных параметров.
        /// </summary>
        private void InitializeParams()
        {
            housingBox.SelectedItem = "Rectangle";
            heightBox.Text = "250";
            hallowBox.Text = "26";
            lengthPerchBox.Text = "25";
            diameterPerchBox.Text = "5";
            depthBox.Text = "120";
            widthBox.Text = "120";
            fastenersBox.Text = "30";
            _init = false;
        }

        /// <summary>
        /// Обработчик события при нажатии на текстовое поле.
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                    foreach (Control d in c.Controls)
                        if (d.GetType() == typeof(TextBox))
                            d.BackColor = System.Drawing.Color.LightGreen;

                if (c.GetType() == typeof(TextBox))
                    c.BackColor = System.Drawing.Color.LightGreen;
            }
            Build.Enabled = IsValid();
        }

        /// <summary>
        /// Скрытие или демонстрация дополнительных параметров для построения корпуса.
        /// </summary>
        private void HousingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((string)housingBox.Text) == "Rectangle")
            {
                AdditionalBox.Visible = true;
            }
            else
            {
                AdditionalBox.Visible = false;
            }
        }
        /// <summary>
        /// Проверка списка textBox на минимальные и максимальные значения.
        /// </summary>
        private bool Check_Value(List<TextBox> TextBoxList, int i,
                        List<int> maxValuesList, List<int> minValuesList)
        {
            if ((TextBoxList[i].Text == "") || int.Parse(TextBoxList[i].Text) < minValuesList[i] ||
           int.Parse(TextBoxList[i].Text) > maxValuesList[i] || TextBoxList[i].Text.Length > 3)
            {
                TextBoxList[i].BackColor = System.Drawing.Color.Pink;
                errorLabel.Visible = true;
                return false;
            }
            else
            {
                TextBoxList[i].BackColor = System.Drawing.Color.LightGreen;
                errorLabel.Visible = false;
            }
            return true;
        }

        /// <summary>
        /// Проверка на правильность введённых значений.
        /// </summary>
        private bool IsValid()
        {
            if (_init)
                return true;
            errorLabel.Visible = true;
            Build.Enabled = false;

            List<TextBox> TextBoxList = new List<TextBox>();

            TextBoxList.AddRange(new TextBox[]
            { heightBox,
              hallowBox,
              depthBox,
              widthBox,
              fastenersBox,
              lengthPerchBox,
              diameterPerchBox,
            });
         
            List<int> minValuesList = new List<int>();
            minValuesList.AddRange(new int[] { 250, 26, 120, 120, 30, 25, 5 });
            List<int> maxValuesList = new List<int>();
            maxValuesList.AddRange(new int[] { 500, 474, 190, 190, 50, 35, 10 });

            if (TextBoxList[0].Text != "" && int.Parse(TextBoxList[0].Text) > 26) 
                maxValuesList[1] = int.Parse(TextBoxList[0].Text) - 26;

            int i = 0;

            TextBoxList[5].Enabled = true;
            if (TextBoxList[6].Text != "")
            {
                for (i = 0; i<7; i++)
                {
                    if (!Check_Value(TextBoxList, i, maxValuesList, minValuesList))
                        return false;
                }
            }
            else 
            {
                TextBoxList[5].Enabled = false;
                for (i = 0; i <6; i++)
                {
                    if (!Check_Value(TextBoxList, i, maxValuesList, minValuesList)) 
                        return false;
                }
            }
            return true;
        }
    }
}
