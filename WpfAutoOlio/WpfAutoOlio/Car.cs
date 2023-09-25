using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfAutoOlio
{
    public class Car //luokka. Luokka on koodia. Kun koodia aletaan käyttämään, siitä tulee olio.
    {
        //Ominaisuudet
        public string Color { get; set; } //Tämä on ominaisuus (property). Iso alkukirjain = public
        public int MaxSpeed
        {
            get //palauttaa
            {
                return maxSpeed; //Arvo on tallessa maxSpeed kentässä. Palautetaan kutsuvalle ohjelmalle
            }
            set
            {
                if (value > 0 && value <= 400)
                {
                    maxSpeed = value;
                }
                else
                {
                    maxSpeed = 0;
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        private int maxSpeed; //Tämä on kenttä, ei ominaisuus.Pieni alkukirjain = private
        private int gearCount;
        public Boolean Running { get; set; }
        public string Model { get; set; }
        public string GearType { get; set; }
        public string EngineType { get; set; }
        public int Horsepower { get; set; }
        public double? AverageFuelConsumption { get; set; }
        public int? ElectricVehicleRange { get; set; }
        public int GearCount
        {
            get
            {
                return gearCount;
            }
            set
            {
                if (Regex.IsMatch(value.ToString(), "^[4-9]{1,1}$"))
                {
                    gearCount = value;
                }
                else
                {
                    gearCount = 0;
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        //Metodeja
        public void StartEngine() //Tämä on metodi
        {
            Running = true;
        }

        public void StopEngine()
        {
            Running = false;
        }

        public void SetMaxSpeed(int UserInputMaxSpeed) //Asetetaan huippunopeus 
        {
            maxSpeed = UserInputMaxSpeed; //Arvon tarkastus
            if (UserInputMaxSpeed >= 0 && UserInputMaxSpeed <= 400)
            {
                maxSpeed = UserInputMaxSpeed;
            }
            else
            {
                maxSpeed = 0;
                throw new ArgumentOutOfRangeException();
            }
        }
        public int GetMaxSpeed() // Hakee/lukee asetetun arvon oliolta
        {
            return maxSpeed;
        }
                        
    }
}
