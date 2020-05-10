using System;
using System.Drawing;
using System.Windows.Forms;
using BirdHouseLibrary;

namespace Plugin
{
    public partial class MainForm : Form
    {
        private KompasConnector kompasConnector;
        private HouseParameters houseParameters;
        //Переменная для валидации параметров
        private bool _init = true;

        public MainForm()
        {
            InitializeComponent();
            InitializeParams();
        }

        /// <summary>
        /// Обработчик кнопки "Clean"
        /// </summary>
        private void CleanButton_Click(object sender, EventArgs e)
        {
            //foreach (Control c in Controls)
            //{
            //    if (c.GetType() == typeof(GroupBox))
            //        foreach (Control d in c.Controls)
            //            if (d.GetType() == typeof(TextBox))
            //                d.Text = string.Empty;

            //    if (c.GetType() == typeof(TextBox))
            //        c.Text = string.Empty;
            //}
            foreach (Control c in Controls)
                if (c is TextBox)
                    ((TextBox)c).Text = null;
        }

        /// <summary>
        /// Обработчик, ограничивающий ввод символов в поле
        /// </summary>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!(e.KeyChar > 47 && e.KeyChar < 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        /// <summary>
        /// Обработчик кнопки "Build"
        /// </summary>
        private void Build_Click(object sender, EventArgs e)
        {
            if ((string)housingBox.SelectedItem == "Rectangle" && lengthPerchBox.BackColor == Color.Bisque || diameterPerchBox.BackColor == Color.Bisque)
            {
                HouseParameters houseParameters = new HouseParameters(int.Parse(heightBox.Text),
                  int.Parse(hallowBox.Text), Convert.ToInt32(0), Convert.ToInt32(0),
                  int.Parse(depthBox.Text), int.Parse(widthBox.Text), int.Parse(fastenersBox.Text));
                kompasConnector = new KompasConnector(houseParameters);
                HouseBuilder housebuilder = new HouseBuilder();
                housebuilder.Build(kompasConnector.iPart, kompasConnector.kompas, houseParameters);
            }
            else if ((string)housingBox.SelectedItem == "Rectangle" && lengthPerchBox.BackColor == Color.LightGreen && diameterPerchBox.BackColor == Color.LightGreen)
            {
                HouseParameters houseParameters = new HouseParameters(int.Parse(heightBox.Text),
                  int.Parse(hallowBox.Text), int.Parse(lengthPerchBox.Text), int.Parse(diameterPerchBox.Text),
                  int.Parse(depthBox.Text), int.Parse(widthBox.Text), int.Parse(fastenersBox.Text));
                kompasConnector = new KompasConnector(houseParameters);
                HouseBuilder housebuilder = new HouseBuilder();
                housebuilder.Build(kompasConnector.iPart, kompasConnector.kompas, houseParameters);
            }
            else
            {
                HouseParameters houseParameters = new HouseParameters(int.Parse(heightBox.Text),
                  int.Parse(hallowBox.Text), int.Parse(lengthPerchBox.Text), int.Parse(diameterPerchBox.Text));
                kompasConnector = new KompasConnector(houseParameters);
                HouseBuilder housebuilder = new HouseBuilder();
                housebuilder.BuildCylinder(kompasConnector.iPart, kompasConnector.kompas, houseParameters);
            }
        }

        /// <summary>
        /// Инициализация начальных параметров и установка типа корпуса по умолчанию
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
        /// Обработчик события при нажатии на текстовое поле
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            heightBox.BackColor = System.Drawing.Color.LightGreen;
            hallowBox.BackColor = System.Drawing.Color.LightGreen;
            lengthPerchBox.BackColor = System.Drawing.Color.LightGreen;
            diameterPerchBox.BackColor = System.Drawing.Color.LightGreen;
            depthBox.BackColor = System.Drawing.Color.LightGreen;
            widthBox.BackColor = System.Drawing.Color.LightGreen;
            fastenersBox.BackColor = System.Drawing.Color.LightGreen;
            Build.Enabled = IsValid();
        }

        /// <summary>
        /// Проверка на правильность введённых значений
        /// </summary>
        private bool IsValid()
        {
            if (_init)
                return true;
            errorLabel.Visible = true;
            if ((heightBox.Text == "") || int.Parse(heightBox.Text) < 250 || int.Parse(heightBox.Text) > 500)
            {
                heightBox.BackColor = System.Drawing.Color.Pink;
                errorLabel.Text = "Height has to be from 250 mm 500 mm";
                return false;
            }
            if ((hallowBox.Text == "") || int.Parse(hallowBox.Text) <= 25 || (int.Parse(hallowBox.Text)) > ((int.Parse(heightBox.Text)) - 26))
            {
                hallowBox.BackColor = System.Drawing.Color.Pink;
                errorLabel.Text = "Hallow height depends on height. It has to be higher 25 mm and below on 26 mm";
                return false;
            }
            if ((lengthPerchBox.Text == ""))
            {
                lengthPerchBox.BackColor = System.Drawing.Color.Bisque;
                errorLabel.Text = "Length perch doesn't specified. House will be without perch";
            }
            else if (int.Parse(lengthPerchBox.Text) < 25 || (int.Parse(lengthPerchBox.Text)) > 35)
            {
                lengthPerchBox.BackColor = System.Drawing.Color.Pink;
                errorLabel.Text = "Length perch has to be more 25 mm and less than 35 mm";
                return false;
            }
            else
            {
                lengthPerchBox.BackColor = System.Drawing.Color.LightGreen;
                errorLabel.Visible = false;
            }
            if (diameterPerchBox.Text == "")
            {
                diameterPerchBox.BackColor = System.Drawing.Color.Bisque;
                errorLabel.Text = "Diameter perch doesn't specified. House will be without perch";
            }
            else if (int.Parse(diameterPerchBox.Text) < 5 || (int.Parse(diameterPerchBox.Text)) > 10)
            {
                diameterPerchBox.BackColor = System.Drawing.Color.Pink;
                errorLabel.Text = "Diameter perch has to be more 5 mm and less 10 mm";
                return false;
            }
            else
            {
                diameterPerchBox.BackColor = System.Drawing.Color.LightGreen;
                errorLabel.Visible = false;
            }
            if ((depthBox.Text == "") || int.Parse(depthBox.Text) < 120 || (int.Parse(depthBox.Text)) > 190)
            {
                depthBox.BackColor = System.Drawing.Color.Pink;
                errorLabel.Text = "Depth has to be more 120 mm and less 190 mm";
                return false;
            }
            else
            {
                depthBox.BackColor = System.Drawing.Color.LightGreen;
                errorLabel.Visible = false;
            }
            if ((widthBox.Text == "") || int.Parse(widthBox.Text) < 120 || (int.Parse(widthBox.Text)) > 190)
            {
                widthBox.BackColor = System.Drawing.Color.Pink;
                errorLabel.Text = "Width has to be more 120 mm and less 190 mm";
                return false;
            }
            else
            {
                widthBox.BackColor = System.Drawing.Color.LightGreen;
                errorLabel.Visible = false;
            }
            if ((fastenersBox.Text == "") || int.Parse(fastenersBox.Text) < 30 || (int.Parse(fastenersBox.Text)) > 50)
            {
                fastenersBox.BackColor = System.Drawing.Color.Pink;
                errorLabel.Text = "Width fasteners has to be more 30 mm and less 50 mm";
                return false;
            }
            else
            {
                fastenersBox.BackColor = System.Drawing.Color.LightGreen;
                errorLabel.Visible = false;
            }

            if (heightBox.BackColor == Color.LightGreen && hallowBox.BackColor == Color.LightGreen
                && lengthPerchBox.BackColor == Color.LightGreen && diameterPerchBox.BackColor == Color.LightGreen
                && depthBox.BackColor == Color.LightGreen && widthBox.BackColor == Color.LightGreen
                && fastenersBox.BackColor == Color.LightGreen)
            {
                Build.Enabled = true;
                houseParameters = new HouseParameters
                  (Convert.ToInt32(heightBox.Text), Convert.ToInt32(hallowBox.Text),
                   Convert.ToInt32(lengthPerchBox.Text), Convert.ToInt32(diameterPerchBox.Text),
                   Convert.ToInt32(depthBox.Text), Convert.ToInt32(widthBox.Text),
                   Convert.ToInt32(fastenersBox.Text));
            }
            if (heightBox.BackColor == Color.LightGreen && hallowBox.BackColor == Color.LightGreen
               && lengthPerchBox.BackColor == Color.Bisque || diameterPerchBox.BackColor == Color.Bisque
               && depthBox.BackColor == Color.LightGreen && widthBox.BackColor == Color.LightGreen
               && fastenersBox.BackColor == Color.LightGreen)
            {
                Build.Enabled = true;
                houseParameters = new HouseParameters
                  (Convert.ToInt32(heightBox.Text), Convert.ToInt32(hallowBox.Text),
                   Convert.ToInt32(0), Convert.ToInt32(0),
                   Convert.ToInt32(depthBox.Text), Convert.ToInt32(widthBox.Text),
                   Convert.ToInt32(fastenersBox.Text));
            }
            return true;
        }

        /// <summary>
        /// Скрытие или демонстрация дополнительных параметров для построения корпуса
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
    }
}
