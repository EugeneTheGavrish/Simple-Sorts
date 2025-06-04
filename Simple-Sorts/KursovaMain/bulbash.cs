using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovaMain
{
    public partial class bulbash : Form
    {
        private int[] numbers = new int[8];
        private Label[] labels;

        public bulbash()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
            label13.Visible = false;
            labels = new Label[] { label5, label6, label7, label8, label9, label10, label11, label12 };
        }

        private void bulbash_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label13.Visible = true;
            label13.Location = new Point(29, 84);
            label13.BringToFront();
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            label13.Visible = false;
        }

        private void UpdateLabels()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                labels[i].Text = numbers[i].ToString();
                labels[i].BackColor = Color.LightGray;
            }
        }

        private bool TryParseInput(out int[] arr)
        {
            arr = null;
            var input = textBox1.Text
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length != 8)
                return false;

            int[] temp = new int[8];
            for (int i = 0; i < 8; i++)
            {
                if (!int.TryParse(input[i], out temp[i]))
                    return false;
            }
            arr = temp;
            return true;
        }

        private async Task BubbleSortVisualized()
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    labels[j].BackColor = Color.Yellow;
                    labels[j + 1].BackColor = Color.Yellow;
                    await Task.Delay(400);

                    if (numbers[j] > numbers[j + 1])
                    {
                        // Swap
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;

                        labels[j].Text = numbers[j].ToString();
                        labels[j + 1].Text = numbers[j + 1].ToString();

                        labels[j].BackColor = Color.Red;
                        labels[j + 1].BackColor = Color.Red;
                        await Task.Delay(400);
                    }

                    labels[j].BackColor = Color.LightGray;
                    labels[j + 1].BackColor = Color.LightGray;
                }
                labels[numbers.Length - i - 1].BackColor = Color.Green;
            }
            labels[0].BackColor = Color.Green;
        }

        private async void buttonSort_Click_1(object sender, EventArgs e)
        {
            if (!TryParseInput(out numbers))
            {
                MessageBox.Show("Введіть рівно 8 цілих чисел, розділених пробілом або комою.");
                return;
            }
            UpdateLabels();
            await BubbleSortVisualized();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
