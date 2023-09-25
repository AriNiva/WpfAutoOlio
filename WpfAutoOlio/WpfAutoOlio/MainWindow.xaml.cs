using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAutoOlio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car volvo = new Car(); //Luodaan Car-tyyppinen olio, jonka nimi on "volvo"
        Car ford = new Car(); //Luodaan Car-tyyppinen olio, jonka nimi on "ford"
        string EngineType;
        string GearType;

        public MainWindow()
        {
            InitializeComponent();
            txtColor.Focus();
        }

        private int? ParseNullableInt(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            else
            {
                return int.Parse(s);
            }
        }

        private double? ParseNullableDouble(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            else
            {
                return double.Parse(s);
            }
        }

        private void btnAuto1_Click(object sender, RoutedEventArgs e)
        {
            Boolean ok = true;

            //Kun käyttäjä klikkaa tätä buttonia, asetetaan oliolle nämä arvot ominaisuuksiin
            volvo.Color = txtColor.Text;
            volvo.Model = txtModel.Text;
            //Kaksi tapaa asettaa nopeus  
            //volvo.SetMaxSpeed(int.Parse(txtMaxSpeed.Text)); //1.käytetään luotua SetMaxSpeed metodia
            try //yritetään asettaa huippunopeus
            {
                volvo.MaxSpeed = int.Parse(txtMaxSpeed.Text); //2.käytetään ominaisuuteen sijoitettua returnia tai if lausetta tarkistamiseen.
                lblMaxSpeedInfo.Content = "";
            }
            catch (Exception) //mikäli käyttäjä syöttää arvon joka ei ole välillä 0-400
            {
                lblMaxSpeedInfo.Content = "Huippunopeus voi olla enintään 400!";
                txtMaxSpeed.Text = ""; // tyhjentää maxspeed kentän
                txtMaxSpeed.Focus();   // laittaa kursorin valmiiksi maxspeed kenttään
                ok = false;            //tyhjentää vain maxspeed kentän
            }

            volvo.AverageFuelConsumption = ParseNullableDouble(txtAverageFuelConsumption.Text);
            volvo.Horsepower = int.Parse(txtHorsepower.Text);
            volvo.ElectricVehicleRange = ParseNullableInt(txtElectricVehicleRange.Text);
            volvo.GearType = GearType;
            volvo.EngineType = EngineType;
            
            try
            {
                volvo.GearCount = int.Parse(txtGearCount.Text);
            }
            catch (Exception)
            {

                lblGearCountInfo.Content = "<-!";
                txtGearCount.Text = "";
                txtGearCount.Focus();
            }

            if (ok) //jos käyttäjä syöttää arvon väliltä 0-400 ok = true ja tyhjentää kaikki kentät
            {
                ClearTextBoxes();
                SetRadioButtonsOff();
            }
        }

        public void ShowCarInfo(Car auto) // Tämä rutiini listaa parametrinä saadun olion arvot
        {
            string message = "Model: " + auto.Model + "\n" +
                "Color: " + auto.Color + "\n" +
                //kaksi tapaa asettaa huippunopeus. sama data eritavalla haettuna.Näyttää toimivan vaikka fordissa on käytetty metodia ja messagea ei ole muutettu.
                //"Maxspeed: " + auto.GetMaxSpeed() + "\n" + //1.Metodi joka palauttaa private kentän arvon
                "Maxspeed: " + auto.MaxSpeed + "\n" +        //2.Ominaisuus joka palauttaa private kentän arvon
                "Average Fuel Consumption: " + auto.AverageFuelConsumption.ToString() + "\n" +
                "Horsepower: " + auto.Horsepower.ToString() + "\n" +
                "Electric Vehicle Range: " + (auto.ElectricVehicleRange?.ToString() ?? "No information") + "\n" +
                "GearType: " + auto.GearType + "\n" +
                "EngineType: " + auto.EngineType + "\n" +
                "Gearcount: " + auto.GearCount + "\n" +
                "Engine running: " + auto.Running;


            MessageBox.Show(message);

        }

        private void btnAuto1Info_Click(object sender, RoutedEventArgs e)
        {
            ShowCarInfo(volvo);
        }

        private void btnAuto2_Click(object sender, RoutedEventArgs e)
        {
            Boolean ok = true;

            //ford.SetMaxSpeed(int.Parse(txtMaxSpeed.Text));
            ford.Color = txtColor.Text;
            ford.Model = txtModel.Text;
            try
            {
                ford.MaxSpeed = int.Parse(txtMaxSpeed.Text);
                lblMaxSpeedInfo.Content = "";
            }
            catch (Exception)
            {
                lblMaxSpeedInfo.Content = "Huippunopeus voi olla enintään 400!";
                txtMaxSpeed.Text = "";
                txtMaxSpeed.Focus();
                ok = false;
            }

            ford.AverageFuelConsumption = ParseNullableDouble(txtAverageFuelConsumption.Text);
            ford.Horsepower = int.Parse(txtHorsepower.Text);
            ford.ElectricVehicleRange = ParseNullableInt(txtElectricVehicleRange.Text);
            ford.GearType = GearType;
            ford.EngineType = EngineType;
            try
            {
                ford.GearCount = int.Parse(txtGearCount.Text);
            }
            catch (Exception)
            {

                lblGearCountInfo.Content = "<-!";
                txtGearCount.Text = "";
                txtGearCount.Focus();
            }

            if (ok)
            {
                ClearTextBoxes();
                SetRadioButtonsOff();
            }
        }

        private void btnAuto2Info_Click(object sender, RoutedEventArgs e)
        {
            ShowCarInfo(ford);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnStart)
            {
                volvo.StartEngine();
                if (volvo.Running == true)
                {
                    btnIndicator.Background = Brushes.PaleGreen;
                }
            }
            else if (sender == btnStart2) //voisi käyttää pelkkä else. Else if varalta jos tulee lisää autoja.
            {
                ford.StartEngine();
                if (ford.Running == true)
                {
                    btnIndicator2.Background = Brushes.PaleGreen;
                }
            }

        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnStop)
            {
                volvo.StopEngine();
                if (volvo.Running == false)
                {
                    btnIndicator.Background = Brushes.Yellow;
                }
            }
            else if (sender == btnStop2)
            {
                ford.StopEngine();
                if (ford.Running == false)
                {
                    btnIndicator2.Background = Brushes.Yellow;
                }
            }

        }

        private void ClearTextBoxes()
        {
            txtColor.Text = "";
            txtModel.Text = "";
            txtMaxSpeed.Text = "";
            txtAverageFuelConsumption.Text = "";
            txtHorsepower.Text = "";
            txtElectricVehicleRange.Text = "";
           
        }

        private void SetRadioButtonsOff()
        {
            rbAutomatic.IsChecked = false;
            rbManual.IsChecked = false;
            rbRobotic.IsChecked = false;
            rbDiesel.IsChecked = false;
            rbGasoline.IsChecked = false;
            rbElectric.IsChecked = false;
        }

       

        private void GearButtons_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            GearType = button.Content.ToString();
        }

        private void EngineButtons_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            EngineType = button.Content.ToString();
        }
                       
    }
}   
