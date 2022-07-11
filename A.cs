namespace Downlevel
{
    public class A
    {
        public void One()
        {
            // really making fixes to One
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < 100; ++i)
            {
                builder.Append(i);
            }

            System.IO.File.WriteAllText(null, builder.ToString());
        }

        public void Two()
        {
        }

        public void Three()
        {
            System.Console.WriteLine("another a nonbrekaing change");
        }
    }
}