using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Teste
{

    /*
     * C# Animator ;
     * Author: Matheus Pedroni ;
     * Version: 0.0.1 ;
     * Website: pedr0ni.github.io ; 
     */

    class Animator
    {

        private Control control;

        private int toX = 0;
        private int toY = 0;

        private int velocity;

        private AnimationType type;

        private FrequencyRunner timer;

        public Animator(Control control)
        {
            this.control = control;
        }

        public void setAnimationType(AnimationType type)
        {
            this.type = type;
        }

        public void setVelocity(int v)
        {
            this.velocity = v;
        }

        public void setMaxVector(int x, int y)
        {
            this.toX = x;
            this.toY = y;
        }

        public void start()
        {
            if (this.timer != null) throw new Exception("A animação já começou.");
            if (this.velocity <= 0) throw new Exception("A velocidade não pode ser menor igual a zero.");

            this.timer = new FrequencyRunner(this.velocity, this.animate);
            this.timer.Start();

            if (this.type == AnimationType.SIZE_IN)
            {
                this.toX = this.control.Size.Width;
                this.toY = this.control.Size.Height;
                this.control.Size = new Size(0, 0);
            }
        }

        private void animate()
        {

            switch (this.type)
            {
                case AnimationType.SCROLL:
                    Point p = this.control.Location;

                    if (toX == p.X && toY == p.Y)
                    {
                        this.timer.Stop();
                        return;
                    }

                    if (toX != p.X)
                        p.X++;

                    if (toY != p.Y)
                        p.Y++;

                    if (this.control.InvokeRequired)
                    {
                        this.control.BeginInvoke((MethodInvoker)delegate () { this.control.Location = p; });
                    }

                    break;
                case AnimationType.FADE_IN:
                    break;
                case AnimationType.FADE_OUT:
                    break;
                case AnimationType.SIZE_IN:

                    int w = this.control.Size.Width;
                    int h = this.control.Size.Height;

                    if (toX == w && toY == h)
                    {
                        this.timer.Stop();
                        return;
                    }

                    if (toX != w) w++;
                    if (toY != h) h++;

                    if (this.control.InvokeRequired) {
                        this.control.BeginInvoke((MethodInvoker)delegate () { this.control.Size = new Size(w, h); });
                    }
                    
                    break;
                case AnimationType.SIZE_OUT:
                    int w1 = this.control.Size.Width;
                    int h1 = this.control.Size.Height;

                    if (w1 == 0 && h1 == 0)
                    {
                        this.timer.Stop();
                        return;
                    }

                    if (w1 != 0) w1--;
                    if (h1 != 0) h1--;

                    if (this.control.InvokeRequired)
                    {
                        this.control.BeginInvoke((MethodInvoker)delegate () { this.control.Size = new Size(w1, h1); });
                    }
                    break;
                default:
                    throw new Exception("Defina um tipo de animação (AnimationType).");
            }
        }

    }

    public enum AnimationType
    {
        SCROLL,
        FADE_IN, FADE_OUT,
        SIZE_IN, SIZE_OUT
    }

    public class FrequencyRunner
    {
        private int _frequency;
        private Action _action;
        private bool _isStarted = false;
        public int Frequency { get { return _frequency; } set { _frequency = value; } }

        public Action Action { get { return _action; } set { _action = value; } }

        public FrequencyRunner()
        {
            _frequency = 1000;
            _action = () => { };
        }

        public FrequencyRunner(int frequency, Action action)
        {
            _frequency = frequency;
            _action = action;
        }

        public void Start()
        {
            _isStarted = true;
            Task.Run(() =>
            {
                Stopwatch sw = new Stopwatch();
                double interval = 1000 / _frequency;

                while (_isStarted)
                {
                    sw.Restart();
                    _action();
                    sw.Stop();

                    double timeLeft = sw.ElapsedMilliseconds;
                    if (timeLeft < interval)
                    {
                        sw.Restart();
                        timeLeft = interval - timeLeft;
                        while (sw.ElapsedMilliseconds < timeLeft)
                        {
                        }
                        sw.Stop();
                    }
                }
            });
        }

        public void Stop()
        {
            _isStarted = false;
        }
    }

}