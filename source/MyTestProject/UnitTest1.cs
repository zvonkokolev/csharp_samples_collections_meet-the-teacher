using MeetTheTeacher.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace MyTestProject
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void D01_DictionaryOfTeachersWithDetails()
		{
			// Arrange
			string[] teachersText =
			{
				"Billinger Franz; 2219",
				"Brenn Rosemarie; 2361",
				"Bucek Michael; 2224",
				"Bugner Sorin; 2225"
			};
			Controller controller = new Controller();
			// Act
			controller.InitDetails(teachersText);
			string[] detailsText =
			{
				"Billinger Franz",
				"Brenn Rosemarie",
				"Bucek Michael",
				"Bugner Sorin"
			};
			// Assert
			CollectionAssert.AreEqual(controller.Details.Keys, detailsText);
		}
		[TestMethod]
		public void D01_DictionaryOfTeachersWithDetailsValuesTest()
		{
			// Arrange
			string[] teachersText =
			{
				"Billinger Franz; 2219",
				"Brenn Rosemarie; 2361",
				"Bucek Michael; 2224",
				"Bugner Sorin; 2225"
			};
			Controller controller = new Controller();
			// Act
			controller.InitDetails(teachersText);
			int[] detailsText =
			{
				2219,
				2361,
				2224,
				2225
			};
			// Assert
			CollectionAssert.AreEqual(controller.Details.Values, detailsText);
		}
		[TestMethod()]
		public void C01_Search_ShouldReturnIndexOfTeachers()
		{
			// Arrange
			string[] teachersText =
			{
				"BILLINGER Franz; Montag; 4.EH; 10:55 - 11:45 h; 142; ; Dipl.Päd.Dipl.- HTL - Ing.; FOL",
				"BODENSTORFER Bernhard; Freitag; 4.EH; 10:55 - 11:45 h; 254; ; DI Mag. Dr.; Vl.",
				"BRENN Rosemarie; Freitag; 2.EH; 08:55 - 09:45 h; E05; ; Mag.; Vl.",
				"BUCEK Michael; Donnerstag; 9.EH; 15:30 - 16:20 h; 103; ; DI; Prof.",
				"BUGNER Sorin; Stammschule; ; ; ; ; Dr. ; Prof.",
				"DENKMAIR Rainer; Mittwoch; 3.EH; 10:00 - 10:50 h; 131; ; DI; Prof.",
				"DRAXLBAUER Josef; Montag; 5.EH; 11:50 - 12:40 h; 237; ; Mag.; Prof."
				};
			string[] detailsText =
			{
				"Billinger Franz; 2219",
				"Brenn Rosemarie; 2361",
				"Bucek Michael; 2224",
				"Bugner Sorin; 2225"
			};
			Controller controller = new Controller(teachersText, detailsText);
			// Act
			int count = controller.FindIndexForTeacher("bucek michael"); ;
			// Assert
			Assert.AreEqual(3, count);
		}
	}
}
