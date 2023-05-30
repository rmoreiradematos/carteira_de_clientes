namespace carteira_de_clientes
{
    public class Botoes
    {
        public int quantity { get; set; }
        public Form form { get; set; }
        public bool isLateral { get; set; }
        public Dictionary<string, EventHandler> labels { get; set; }

        public Botoes(
            Dictionary<string, EventHandler> labels,
            int quantity,
            Form form,
            bool isLateral = false
        )
        {
            this.quantity = quantity;
            this.form = form;
            this.isLateral = isLateral;
            this.labels = labels;
            GenerateButtons(this.labels, this.quantity, this.form, this.isLateral);
        }

        private void GenerateButtons(
            Dictionary<string, EventHandler> labels,
            int quantity,
            Form form,
            bool isLateral = false
        )
        {
            if (isLateral)
            {
                int x = 250;
                int y = 10;
                int buttonWidth = 150;
                int buttonHeight = 30;
                int i = 0;
                foreach (var label in labels)
                {
                    Button button = new Button();
                    button.Text = label.Key;
                    button.Location = new System.Drawing.Point(x, y);
                    button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                    button.Click += label.Value;
                    form.Controls.Add(button);
                    y += buttonHeight + 10;
                    i++;
                    if (i == quantity)
                    {
                        x += buttonHeight + 10;
                        y = 10;
                        i = 0;
                    }
                }
            }
            else
            {
                int x = 75;
                int y = 500;
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
                }
            }
        }
    }
}
