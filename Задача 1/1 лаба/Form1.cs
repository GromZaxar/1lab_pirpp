using System;
using System.Windows.Forms;

namespace SumArrayApp
{
    public partial class Form1 : Form
    {
        private int[] numbers = new int[10];
        private TextBox[] textBoxes = new TextBox[10];
        private Label resultLabel;
        private Button calculateButton;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            for (int i = 0; i < 10; i++)
            {
                Label label = new Label();
                label.Text = "Элемент " + (i + 1) + ":";
                label.Location = new System.Drawing.Point(20, 20 + i * 30);
                label.Size = new System.Drawing.Size(70, 20);

                textBoxes[i] = new TextBox();
                textBoxes[i].Location = new System.Drawing.Point(100, 20 + i * 30);
                textBoxes[i].Size = new System.Drawing.Size(100, 20);

                this.Controls.Add(label);
                this.Controls.Add(textBoxes[i]);
            }

            calculateButton = new Button();
            calculateButton.Text = "Вычислить сумму";
            calculateButton.Location = new System.Drawing.Point(20, 330);
            calculateButton.Size = new System.Drawing.Size(120, 30);
            calculateButton.Click += CalculateSum;

            resultLabel = new Label();
            resultLabel.Text = "Сумма: ";
            resultLabel.Location = new System.Drawing.Point(150, 335);
            resultLabel.Size = new System.Drawing.Size(120, 20);

            this.Controls.Add(calculateButton);
            this.Controls.Add(resultLabel);
        }

        private void CalculateSum(object sender, EventArgs e)
        {
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                if (int.TryParse(textBoxes[i].Text, out int value))
                {
                    numbers[i] = value;
                    sum = sum + numbers[i];
                }
            }

            resultLabel.Text = "Сумма: " + sum;
        }
    }
}