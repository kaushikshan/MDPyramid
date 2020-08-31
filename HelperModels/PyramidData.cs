using MDPyramid.HelperInterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace MDPyramid.HelperModels
{
	/// <summary>
	/// Deals with the Data Access 
	/// </summary>
	public class PyramidData : IDataProvider
	{
		public string filePath { get; private set; }

		public PyramidData()
		{
			filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
												ConfigurationManager.AppSettings["relativeFilePath"].ToString()));
		}

		public PyramidData(string filePath)
		{
			this.filePath = filePath;
		}

		/// <summary>
		/// Return and Enumerable of Enumerable
		/// Not high on Memory Utilization because of ReadLines
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IEnumerable<int>> ReadByLines()
		{
			//Make sure the FilePath is present
			if (!String.IsNullOrEmpty(filePath))
			{
				if (File.Exists(filePath))
				{
					//Process and yield one row at a time
					foreach (string rowElement in File.ReadLines(filePath))
					{
						yield return rowElement.Split(' ').Select(int.Parse).ToList();
					}
				}
				else
				{
					throw new FileNotFoundException(filePath + "Not Found");
				}
			}
			else
			{
				throw new ArgumentNullException("Invalid Initialization of PyramidData");
			}
		}
	}
}
