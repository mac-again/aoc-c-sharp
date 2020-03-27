namespace AoC
{

    abstract class DayBase : IDay
    {
        internal DayBase() { }

        public void Main()
        {
            MainA();
            MainB();
        }

        internal abstract void MainA();
        internal abstract void MainB();
    }
}
