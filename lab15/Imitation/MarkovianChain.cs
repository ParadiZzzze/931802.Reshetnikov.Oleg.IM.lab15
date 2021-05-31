using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    class MarkovianChain
    {
        public double[][] Q;
        public double[][] TransitionDist;
        public double time_env_change;
        public int state;
        public int next_state;
        public int S = 3;
        public MarkovianChain()
        {
            Q = new double[][]
            {
                new double[] {-0.4, 0.3, 0.1},
                new double[] {0.4, -0.8, 0.4},
                new double[] {0.1, 0.4, -0.5}
            };

            state = 0;
            next_state = 0;
            calculateDist();
        }


        public void calculateDist()
        {
            TransitionDist = new double[S][];
            for(int i = 0; i < S; i++)
            {
                TransitionDist[i] = new double[S];
                for(int j =0; j< S; j++)
                {
                    TransitionDist[i][j] = 0;
                    if (i!=j) TransitionDist[i][j] = -Q[i][j] / Q[i][i];
                } 
            }
        }


        public void nextState(double t)
        {

            state = next_state;
            Random rnd = new Random();
            double a = rnd.NextDouble();
            time_env_change = t + Math.Log(a)/Q[state][state];

            next_state = 0;
            double A = rnd.NextDouble() - TransitionDist[state][next_state];
            while (A>0)
            {
                next_state++;
                A -= TransitionDist[state][next_state];
            }
        }
    }
}
