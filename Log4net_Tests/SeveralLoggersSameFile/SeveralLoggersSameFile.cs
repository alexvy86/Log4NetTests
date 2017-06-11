using log4net;
using Log4net_Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4net_Tests.SeveralLoggersSameFile
{
	internal static class SeveralLoggersSameFile
	{
		private static ILog logger = LogManager.GetLogger("Outer");
		private static ILog innerLogger = LogManager.GetLogger("Inner");

		public static void Do()
		{
			logger.Info("Processing employees - START");

			foreach (var e in GetEmployees())
			{
				using (log4net.LogicalThreadContext.Stacks["Employee"].Push(String.Format("EmployeeID:{0}",e.ID.ToString())))
				{
					try
					{
						innerLogger.InfoFormat("Processing employee name {0}", e.Name);
						innerLogger.InfoFormat("Formatted hire date is {0}", e.HireDate.Value.ToString("yyyy-MM-dd"));
						foreach (var s in e.Skills)
						{
							using (log4net.LogicalThreadContext.Stacks["Employee"].Push(String.Format("Skill:{0}", s)))
							{
								try
								{
									innerLogger.InfoFormat("Uppercase skill '{0}'", s.ToUpper());
								}
								catch (Exception ex)
								{
									innerLogger.Error("An unexpected error occurred.", ex);
								}
							}
						}
					}
					catch (Exception ex)
					{
						innerLogger.Error("An unexpected error occurred.", ex);
					}
				}
			}
			logger.Info("Processing employees - DONE");
		}

		private static IEnumerable<Employee> GetEmployees()
		{
			return new List<Employee>()
			{
				new Employee() { ID = 1, Name = "Alex Villarreal", HireDate = DateTime.UtcNow, Skills = new List<string>() { "SQL", "C#" } },
				new Employee() { ID = 2, Name = "Leo Hinojosa", HireDate = DateTime.UtcNow, Skills = new List<string>() { "SQL", "C#" } },
				new Employee() { ID = 3, Name = "Sergio Cavazos", HireDate = new DateTime?(), Skills = new List<string>() { "SQL", "C#" } },
				new Employee() { ID = 4, Name = "Daniel Ramirez", HireDate = DateTime.UtcNow, Skills = new List<string>() { "SQL", null } },
			};
		}
	}
}
