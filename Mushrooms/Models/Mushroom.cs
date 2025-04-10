using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mushrooms.Models
{
    public class Mushroom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LatinName {  get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image {  get; set; } = string.Empty;

        public Mushroom(string name,
            string latinName,
            string description,
            string image)
        {
            this.Name = name;
            this.LatinName = latinName;
            this.Description = description;
            this.Image = image;
        }

        public Mushroom(int id,
            string name,
            string latinName,
            string description,
            string image)
        {
            this.Id = id;
            this.Name = name;
            this.LatinName = latinName;
            this.Description = description;
            this.Image = image;
        }
    }
}
