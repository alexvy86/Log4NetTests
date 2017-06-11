using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4net_Tests.Models
{
	internal class Employee
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public DateTime? HireDate { get; set; }
		public IList<string> Skills { get; set; }
	}
}
