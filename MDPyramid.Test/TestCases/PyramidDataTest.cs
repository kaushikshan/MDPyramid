using MDPyramid.HelperModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace MDPyramid.Test.TestCases
{
	[TestClass]
	public class PyramidDataTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CheckInitialization()
		{
			PyramidData pyramidData = new PyramidData(null);
			pyramidData.ReadByLines().ToList();
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]
		public void CheckIfFileExists()
		{
			PyramidData pyramidData = new PyramidData();
			pyramidData.ReadByLines().ToList();
		}

		[TestMethod]
		public void CheckIfLinesMatch()
		{
			string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
										ConfigurationManager.AppSettings["relativeFilePath"].ToString() + "TriangleTest.txt"));
			PyramidData pyramidData = new PyramidData(filePath);
			Assert.AreEqual(File.ReadLines(filePath).Count(), pyramidData.ReadByLines().ToList().Count);
		}

		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void CheckInvalidFile()
		{
			string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
										ConfigurationManager.AppSettings["relativeFilePath"].ToString() + "InvalidFileTest.txt"));
			PyramidData pyramidData = new PyramidData(filePath);
			pyramidData.ReadByLines().ToList();
		}

		[TestMethod]
		public void CheckEmptyFile()
		{
			string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
										ConfigurationManager.AppSettings["relativeFilePath"].ToString() + "EmptyFileTest.txt"));
			PyramidData pyramidData = new PyramidData(filePath);
			Assert.AreEqual(0, pyramidData.ReadByLines().ToList().Count);
		}
	}
}
