using MXGP.Core.Contracts;
using MXGP.IO;
using MXGP.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ConsoleWriter writer;
        private ConsoleReader reader;
        private ChampionshipController controller;

        public Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.controller = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "CreateRider")
                    {
                        string riderName = input[1];

                        result = controller.CreateRider(riderName);
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        var type = input[1];
                        var model = input[2];
                        var horsepower = int.Parse(input[3]);

                        result = controller.CreateMotorcycle(type, model, horsepower);
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        string riderName = input[1];
                        string motorcycleName = input[2];

                        result = controller.AddMotorcycleToRider(riderName, motorcycleName);
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        string raceName = input[1];
                        string riderName = input[2];
                       
                        result = controller.AddRiderToRace(raceName, riderName);
                    }
                    else if (input[0] == "CreateRace")
                    {
                        string name = input[1];
                        int laps = int.Parse(input[2]);

                        result = controller.CreateRace(name, laps);
                    }
                    else if (input[0] == "StartRace")
                    {
                        string raceName = input[1];

                        result = controller.StartRace(raceName);
                    }
                  

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
