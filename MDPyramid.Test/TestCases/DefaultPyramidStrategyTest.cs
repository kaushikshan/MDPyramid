using MDPyramid.HelperModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace MDPyramid.Test.TestCases
{
	[TestClass]
	public class DefaultPyramidStrategyTest
	{
		[TestMethod]
		public void CheckInitialization()
		{
			PyramidContext p = new PyramidContext();
			Assert.AreEqual(p.strategy.GetType(), typeof(DefaultPyramidStrategy));
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]
		public void CheckIfFileExists()
		{
			PyramidData pyramidData = new PyramidData();
			pyramidData.ReadByLines().ToList();
		}

		[TestMethod]
		public void CheckInvalidTriangle()
		{
			string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
										ConfigurationManager.AppSettings["relativeFilePath"].ToString() + "InvalidTriangleTest.txt"));

			PyramidContext pyramidContext = new PyramidContext();
			Assert.AreEqual(false, pyramidContext.BuildPyramid(new PyramidData(filePath)));
		}

		[TestMethod]
		public void CheckInvalidPath()
		{
			string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
										ConfigurationManager.AppSettings["relativeFilePath"].ToString() + "InvalidPathTest.txt"));

			PyramidContext pyramidContext = new PyramidContext();
			if (pyramidContext.BuildPyramid(new PyramidData(filePath)))
			{
				ResultModel resultModel = pyramidContext.WalkAndCalculate();

				//Display the Result
				if (null != resultModel)
				{
					Assert.AreEqual(resultModel.path.Count, 0);
				}
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CheckEmptyPyramid()
		{
			DefaultPyramidStrategy defaultPyramidStrategy = new DefaultPyramidStrategy();
			defaultPyramidStrategy.WalkAndCalculate(null);
		}
	}
}
