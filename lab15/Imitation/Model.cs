using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Imitation
{
    class Model
    {
        public double current_time;
        public int current_state;
        public int events;
        public double[] Statistic;
        public double[] Statistic2;
        public MarkovianChain weatherCondition;

        public Model()
        {
            weatherCondition = new MarkovianChain();

            current_state = weatherCondition.state;
            current_time = 0;
            events = 0;

            Statistic = new double[4];
            Statistic2 = new double[4];
            weatherCondition.nextState(current_time);
        }

        public void simulate(int numberOfEvents, System.Windows.Forms.PictureBox thePicture, System.Windows.Forms.Label label1, System.Windows.Forms.Label label2)
        {
            while (events < numberOfEvents)
            {
                events++;
                double ts = weatherCondition.time_env_change;
                double dt = ts - current_time;
                Statistic[current_state] += dt;
                current_state = weatherCondition.state;
                current_time = ts;
                switch (current_state)
                {
                    case 0:
                        thePicture.Image = Image.FromFile("bulletrain.jpg");
                        label1.Text = "Bullet rain";
                        break;
                    case 1:
                        thePicture.Image = Image.FromFile("rainofmeatballs.png");
                        label1.Text = "Rain of meatballs";
                        break;
                    case 2:
                        thePicture.Image = Image.FromFile("flood1.png");
                        label1.Text = "Flood";
                        break;
                    
                }
                thePicture.Refresh();
                thePicture.Visible = true;
                weatherCondition.nextState(current_time);
                label2.Text = Convert.ToString(current_time);
            }
            events = 0;
            for (int i = 0; i < Statistic.Length; i++)
            {
                Statistic2[i] = Statistic[i]/current_time * 100;
            }
            showDistribution();
        }
        public void showDistribution()
        {

        }
    }
}
