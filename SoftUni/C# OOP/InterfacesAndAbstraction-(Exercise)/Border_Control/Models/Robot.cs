
namespace Border_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Interfaces;
    public class Robot : ICitizen
    {
        public Robot(string model, string id)
        {
            NameOrModel = model;
            Id = id;
        }

        public string NameOrModel { get; private set; }

        public string Id { get; private set; }
    }
}
