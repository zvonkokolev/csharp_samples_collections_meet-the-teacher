using MeetTheTeacher.Logic;
using System;
using System.IO;
using System.Text;
using Utils;

namespace MeetTheTeacher.UI
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string pathToInputFiles = MyFile.GetFullFolderNameInApplicationTree("Input");
			string pathToOutputFiles = MyFile.GetFullFolderNameInApplicationTree("Output");

			const string teachersFileName = "Teachers.csv";
			const string detailsFileName = "Details.csv";
			const string ignoredTeachersFileName = "IgnoredTeachers.csv";

			const string resultFileName = "Sprechstunden.html";

			Console.WriteLine("Meet the teacher");
			Console.WriteLine("================");
			string inputFileName = Path.Combine(pathToInputFiles, teachersFileName);
			string[] teacherLines = File.ReadAllLines(inputFileName, Encoding.UTF8);
			string[] detailLines = File.ReadAllLines(Path.Combine(pathToInputFiles, detailsFileName), Encoding.UTF8);
			string[] ignoredNames = File.ReadAllLines(Path.Combine(pathToInputFiles, ignoredTeachersFileName), Encoding.UTF8);

			////Umwandeln in GROSSBUCHSTABEN
			//string[] kapitalLetter = new string[detailLines.Length];
			//int index = 0;
			//foreach (var item in detailLines)
			//{
			//	string[] newDetailLines = new string[2];
			//	newDetailLines = item.Split(';');
			//	kapitalLetter.SetValue(newDetailLines[0].ToUpper() + ';' + newDetailLines[1], index++);
			//}//Warum funktioniert nicht???

			Controller ctrl = new Controller(teacherLines, detailLines);

			string html = ctrl.GetHtmlTable();
			File.WriteAllText(Path.Combine(pathToOutputFiles, resultFileName), html, Encoding.Default);
		}
	}
}
