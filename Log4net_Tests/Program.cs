using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4net_Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			SeveralLoggersSameFile.SeveralLoggersSameFile.Do();
			Console.WriteLine("Done. Press ENTER to exit.");
			Console.ReadLine();
		}
	}
}
