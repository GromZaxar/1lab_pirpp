using System;
using System.Windows.Forms;

namespace CountDuplicatesApp
{
    public partial class Form1 : Form
    {
        private int[] numbers = new int[10];
        private TextBox[] textBoxes = new TextBox[10];
        private Button createButton;
        private Button countButton;
        private ListBox resultListBox;
        private bool[] counted;

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
                label.Text = "Число " + (i + 1) + ":";
                label.Location = new System.Drawing.Point(20, 20 + i * 30);
                label.Size = new System.Drawing.Size(50, 20);

                textBoxes[i] = new TextBox();
                textBoxes[i].Location = new System.Drawing.Point(80, 20 + i * 30);
                textBoxes[i].Size = new System.Drawing.Size(100, 20);

                this.Controls.Add(label);
                this.Controls.Add(textBoxes[i]);
            }

            createButton = new Button();
            createButton.Text = "Создать массив";
            createButton.Location = new System.Drawing.Point(20, 330);
            createButton.Size = new System.Drawing.Size(120, 30);
            createButton.Click += CreateArray;

            countButton = new Button();
            countButton.Text = "Подсчитать дубликаты";
            countButton.Location = new System.Drawing.Point(150, 330);
            countButton.Size = new System.Drawing.Size(140, 30);
            countButton.Click += CountDuplicates;
            countButton.Enabled = false;

            Label resultLabel = new Label();
            resultLabel.Text = "Результат:";
            resultLabel.Location = new System.Drawing.Point(20, 370);
            resultLabel.Size = new System.Drawing.Size(100, 20);

            resultListBox = new ListBox();
            resultListBox.Location = new System.Drawing.Point(20, 390);
            resultListBox.Size = new System.Drawing.Size(350, 120);

            this.Controls.Add(createButton);
            this.Controls.Add(countButton);
            this.Controls.Add(resultLabel);
            this.Controls.Add(resultListBox);
        }

        private void CreateArray(object sender, EventArgs e)
        {
            bool validInput = true;

            for (int i = 0; i < 10; i++)
            {
                if (!int.TryParse(textBoxes[i].Text, out numbers[i]))
                {
                    validInput = false;
                    break;
                }
            }

            if (validInput)
            {
                countButton.Enabled = true;
                resultListBox.Items.Clear();
                MessageBox.Show("Массив создан успешно!");
            }
            else
            {
                MessageBox.Show("Введите корректные числа");
            }
        }

        private void CountDuplicates(object sender, EventArgs e)
        {
            resultListBox.Items.Clear();
            counted = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                if (!counted[i])
                {
                    int count = 1;

                    for (int j = i + 1; j < 10; j++)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            count++;
                            counted[j] = true;
                        }
                    }

                    resultListBox.Items.Add("Число " + numbers[i] + " встречается " + count + " раз(а)");
                    counted[i] = true;
                }
            }
        }
    }
}