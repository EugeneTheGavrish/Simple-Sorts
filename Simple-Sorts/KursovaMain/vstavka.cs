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
    public partial class vstavka : Form
    {
        private int[] numbers = new int[8];
        private Label[] labels;

        public vstavka()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
            labels = new Label[] { label5, label6, label7, label8, label9, label10, label11, label12 };
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

        private async void buttonSort_Click_1(object sender, EventArgs e)
        {
            if (!TryParseInput(out numbers))
            {
                MessageBox.Show("Введіть рівно 8 цілих чисел, розділених пробілом або комою.");
                return;
            }
            UpdateLabels();
            await InsertionSortVisualized();
        }

        private async Task InsertionSortVisualized()
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                labels[i].BackColor = Color.Yellow;
                await Task.Delay(400);

                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    labels[j + 1].Text = numbers[j + 1].ToString();
                    labels[j + 1].BackColor = Color.Red;
                    await Task.Delay(400);
                    labels[j + 1].BackColor = Color.LightGray;
                    j--;
                }
                numbers[j + 1] = key;
                labels[j + 1].Text = key.ToString();
                labels[j + 1].BackColor = Color.Green;
                await Task.Delay(400);
                labels[j + 1].BackColor = Color.LightGray;
            }
            UpdateLabels();
        }

        private void vstavka_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label13.Visible = true;
            label13.Location = new Point(37, 93);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label13.Visible = false;
        }

        
    }
}
