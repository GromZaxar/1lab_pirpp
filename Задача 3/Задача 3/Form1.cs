using System;
using System.Windows.Forms;

namespace EvenOddApp
{
    public partial class Form1 : Form
    {
        private int[] array = new int[15];
        private Button createButton;
        private Button countButton;
        private ListBox arrayListBox;
        private Label resultLabel;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            createButton = new Button();
            createButton.Text = "Создать массив";
            createButton.Location = new System.Drawing.Point(20, 20);
            createButton.Size = new System.Drawing.Size(120, 30);
            createButton.Click += CreateArray;

            arrayListBox = new ListBox();
            arrayListBox.Location = new System.Drawing.Point(20, 60);
            arrayListBox.Size = new System.Drawing.Size(150, 150);

            countButton = new Button();
            countButton.Text = "Подсчитать";
            countButton.Location = new System.Drawing.Point(20, 220);
            countButton.Size = new System.Drawing.Size(120, 30);
            countButton.Click += CountEvenOdd;
            countButton.Enabled = false;

            resultLabel = new Label();
            resultLabel.Text = "";
            resultLabel.Location = new System.Drawing.Point(20, 260);
            resultLabel.Size = new System.Drawing.Size(300, 30);

            this.Controls.Add(createButton);
            this.Controls.Add(arrayListBox);
            this.Controls.Add(countButton);
            this.Controls.Add(resultLabel);
        }

        private void CreateArray(object sender, EventArgs e)
        {
            arrayListBox.Items.Clear();

            for (int i = 0; i < 15; i++)
            {
                array[i] = random.Next(10, 51);
                arrayListBox.Items.Add("[" + i + "] = " + array[i]);
            }

            countButton.Enabled = true;
            resultLabel.Text = "";
        }

        private void CountEvenOdd(object sender, EventArgs e)
        {
            int evenCount = 0;
            int oddCount = 0;

            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            resultLabel.Text = "Четных: " + evenCount + ", Нечетных: " + oddCount;
        }
    }
}