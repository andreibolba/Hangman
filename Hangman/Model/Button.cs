using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Model
{
    public class Button
    {
        public string label { get; set; }
        public string visible { get; set; }

        public Button()
        {
            label = "";
            visible = "";
        }

        public Button(string label)
        {
            this.label = label;
            visible = "Visiblle";
        }

        public Button(string label,string visible)
        {
            this.label = label;
            this.visible = visible;
        }
    }
}
