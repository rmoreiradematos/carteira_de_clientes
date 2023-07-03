using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Carteira_De_Clientes
{
    public class Botoes
    {
        public int quantity { get; set; }
        public Form form { get; set; }
        public bool isLateral { get; set; }
        public Dictionary<string, EventHandler> labels { get; set; }
        public Dictionary<string, Button> buttonDictionary = new Dictionary<string, Button>();
        public int newX { get; set; }
        public int newY { get; set;}
        public Botoes() { }

        public Botoes(
            Dictionary<string, EventHandler> labels,
            int quantity,
            Form form,
            int newX,
            int newY,
            bool isLateral = false
        )
        {
            this.quantity = quantity;
            this.form = form;
            this.isLateral = isLateral;
            this.labels = labels;
            this.newX = newX;
            this.newY = newY;
            GenerateButtons(this.labels, this.quantity, this.form, this.newX, this.newY, this.isLateral);
        }

        public Button GetButton(string label)
        {
            if (buttonDictionary.ContainsKey(label))
            {
                return buttonDictionary[label];
            }

            return null; // Button not found
        }


        private void GenerateButtons(
            Dictionary<string, EventHandler> labels,
            int quantity,
            Form form,
            int newX,
            int newY,
            bool isLateral = false
        )
        {
            if (isLateral)
            {
                int x = 15;
                int y = 350;
                int buttonWidth = 350;
                int buttonHeight = 80;
                int i = 0;
                foreach (var label in labels)
                {
                    Button button = new Button();
                    button.Text = label.Key;
                    button.UseVisualStyleBackColor = true;
                    button.Font = new Font(button.Font.FontFamily, 20, FontStyle.Bold);
                    button.Location = new System.Drawing.Point(x, y);
                    button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                    button.Click += label.Value;
                    form.Controls.Add(button);
                    y += buttonHeight + 20;
                    i++;
                    if (i == quantity - 1)
                    {
                        y = 950;
                    }
                    // buttonDictionary[label.Value] = button;
                }
            }
            else
            {
                int x = newX;
                int y = newY;
                Console.WriteLine(newX);
                Console.WriteLine(newY);
                int buttonWidth = 150;
                int buttonHeight = 30;
                int i = 0;
                foreach (var label in labels)
                {
                    Button button = new Button();
                    button.Text = label.Key;
                    button.UseVisualStyleBackColor = true;
                    button.Location = new System.Drawing.Point(x, y);
                    button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                    button.Click += label.Value;
                    form.Controls.Add(button);
                    x += buttonWidth + 75;
                    i++;
                    if (i == quantity)
                    {
                        y += buttonHeight + 100;
                        x = 10;
                        i = 0;
                    }
                    button.BringToFront();
                    // buttonDictionary[label.Value] = button;
                }
            }
        }
    }
}
