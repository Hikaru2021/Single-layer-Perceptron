namespace Laboratory4_Perceptron
{
    public partial class Form1 : Form
    {
        double w1, w2, biasAnd;
        double w11, w22, biasOr;
        double x1, x2;
        double learning_rate;
        int output1;
        int output2;
        int[] desiredAnd;
        int[] desiredOr;
        int[,] patterns;
        Random rnd;

        private void button2_Click(object sender, EventArgs e)
        {
                double v, delta;
                int max_epoch = 10000, epochsAnd = 0;
                int error = 10;
                int pn; //represents the pattern number
                int[] pat_used = new int[4]; //monitor the pattern

                while (error > 0 && epochsAnd < max_epoch)
                {
                    //set to 0 every epoch
                    pat_used[0] = 0;
                    pat_used[1] = 0;
                    pat_used[2] = 0;
                    pat_used[3] = 0;
                    error = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        //we are selecting a random pattern
                        pn = rnd.Next(4);
                        while (pat_used[pn] == 1)
                        {
                            pn = rnd.Next(4);
                        }
                        x1 = patterns[pn, 0];
                        x2 = patterns[pn, 1];
                        pat_used[pn] = 1;

                        v = x1 * w1 + x2 * w2 + biasAnd;
                        if (v >= 0) output1 = 1;
                        else output1 = 0;

                        delta = desiredAnd[pn] - output1;
                        if (delta != 0)
                        {
                            w1 += learning_rate * delta * x1;
                            w2 += learning_rate * delta * x2;
                            biasAnd += learning_rate * delta;
                        }

                        error += Math.Abs((int)delta);
                    }
                    epochsAnd++;
                }

                MessageBox.Show("Finished!\nEpochs: " + epochsAnd + "\nErrors: " + error);



                v = 0;
                delta = 0;
                max_epoch = 10000;
                int epochsOr = 0;
                error = 10;
                pn = 0; //represents the pattern number
                pat_used = new int[4]; //monitor the pattern

                while (error > 0 && epochsOr < max_epoch)
                {
                    //set to 0 every epoch
                    pat_used[0] = 0;
                    pat_used[1] = 0;
                    pat_used[2] = 0;
                    pat_used[3] = 0;
                    error = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        //we are selecting a random pattern
                        pn = rnd.Next(4);
                        while (pat_used[pn] == 1)
                        {
                            pn = rnd.Next(4);
                        }
                        x1 = patterns[pn, 0];
                        x2 = patterns[pn, 1];
                        pat_used[pn] = 1;

                        v = x1 * w11 + x2 * w22 + biasOr;
                        if (v >= 0) output2 = 1;
                        else output2 = 0;

                        delta = desiredOr[pn] - output2;
                        if (delta != 0)
                        {
                            w11 += learning_rate * delta * x1;
                            w22 += learning_rate * delta * x2;
                            biasOr += learning_rate * delta;
                        }

                        error += Math.Abs((int)delta);
                    }
                    epochsOr++;
                }

                MessageBox.Show("Finished!\nEpochs: " + epochsOr + "\nErrors: " + error);
            

            button2.Enabled = false;
            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox4.Text = null;

            if (textBox1.Text == "0" || textBox1.Text == "1")
            {
                if (textBox2.Text == "0" || textBox2.Text == "1")
                {
                    double v;
                    x1 = Convert.ToInt32(textBox1.Text);
                    x2 = Convert.ToInt32(textBox2.Text);

                    v = x1 * w1 + x2 * w2 + biasAnd;
                    if (v >= 0) textBox3.Text = "1";
                    else textBox3.Text = "0";

                    x1 = Convert.ToInt32(textBox1.Text);
                    x2 = Convert.ToInt32(textBox2.Text);

                    v = x1 * w11 + x2 * w22 + biasOr;
                    if (v >= 0) textBox4.Text = "1";
                    else textBox4.Text = "0";
                }
                else
                    MessageBox.Show("Please fill up all input box with either 1 or 0", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
            }
            else
                MessageBox.Show("Please fill up all input box with either 1 or 0", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public Form1()
        {
            InitializeComponent();
                rnd = new Random();
                w1 = rnd.NextDouble();
                w2 = rnd.NextDouble();
                w11 = rnd.NextDouble();
                w22 = rnd.NextDouble();
                learning_rate = 0.1;
                biasAnd = rnd.NextDouble();
                biasOr = rnd.NextDouble();
                patterns = new int[4, 2];
                desiredAnd = new int[4];
                desiredOr = new int[4];

                patterns[0, 0] = 0;
                patterns[0, 1] = 0;
                patterns[1, 0] = 0;
                patterns[1, 1] = 1;
                patterns[2, 0] = 1;
                patterns[2, 1] = 0;
                patterns[3, 0] = 1;
                patterns[3, 1] = 1;

                desiredAnd[0] = 0;
                desiredAnd[1] = 0;
                desiredAnd[2] = 0;
                desiredAnd[3] = 1;

                desiredOr[0] = 0;
                desiredOr[1] = 1;
                desiredOr[2] = 1;
                desiredOr[3] = 1;

                button1.Enabled = false;
        }   
    }
}