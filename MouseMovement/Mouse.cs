using System.Runtime.InteropServices;

namespace MouseMovement
{
    class Mouse
    {
        [DllImport ("user32.dll")]
        private static extern long SetCursorPos (int x, int y);

        private int XPos;
        private int YPos;

        private int[]? FinalPosition;

        public void Move()
        {
            Random random = new Random();
            XPos = random.Next(0, 1920);
            YPos = random.Next(0, 1080);

            SetFinalPosition();

            while(true)
            {
                for(int i = 0; i < 100; i++)
                {
                    CalculateNextPosition();
                    Thread.Sleep(1);
                    SetCursorPos(XPos, YPos);
                }

                Console.WriteLine("Positions -> X: " + XPos + " - Y: " + YPos);
            }
        }

        #region Private Methods

        private void SetFinalPosition()
        {
            Random random = new Random();
            FinalPosition = new int[2] { random.Next(0, 1920), random.Next(0, 1080) };
        }

        private void CalculateNextPosition()
        {
            if (FinalPosition[0] == XPos || FinalPosition[1] == YPos)
                SetFinalPosition();

            _ = XPos < FinalPosition[0] ? XPos++ : XPos--;
            _ = YPos < FinalPosition[1] ? YPos++ : YPos--;
        }

        #endregion Private Methods
    }
}
