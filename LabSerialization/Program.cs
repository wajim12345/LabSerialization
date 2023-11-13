using System.Text;
using System.Text.Json;

namespace LabSerialization
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Event calgary = new Event(1, "Calgary");
			string path = "event.json";
			//Serilize
			string encoded = JsonSerializer.Serialize(calgary);
			File.WriteAllText(path, encoded);
			Console.WriteLine("Wrote to JSON file successfilly!");
			//Deserialie
			String contents = File.ReadAllText(path);
			Event decoded = JsonSerializer.Deserialize<Event>(contents);
			Console.WriteLine(decoded.EventNumber);
			Console.WriteLine(decoded.Location);

			ReadFromFile();
		}

		static void ReadFromFile()
		{
			//Create file path
			string filePath = "name.bin";
			//Writing data into file
			using (StreamWriter streamWriter = new StreamWriter(filePath))
			{
				streamWriter.Write("Hackathon");
			}

			//Open and read file
			using (FileStream fileStream = File.OpenRead(filePath))
			{
				//Read the content in file and print it
				byte[] buffer = new byte[fileStream.Length];
				fileStream.Read(buffer, 0, (int) fileStream.Length);
				string content = Encoding.UTF8.GetString(buffer);
				Console.WriteLine($"Tech Competition\nIn Word: {content}");
				//Find First Character
				fileStream.Seek(0, SeekOrigin.Begin);
				char firstChar = (char) fileStream.ReadByte();
				Console.WriteLine($"The First Character is: \"{firstChar}\"");
				//Find Middle Character
				int midCharPos = (int)fileStream.Length / 2;
				fileStream.Seek(midCharPos, SeekOrigin.Begin);
				char midChar = (char) fileStream.ReadByte();
				Console.WriteLine($"The Middle Character is: \"{midChar}\"");
				//Find Last Character
				fileStream.Seek(-1, SeekOrigin.End);
				char lastChar = (char) fileStream.ReadByte();
				Console.WriteLine($"The Last Character is: \"{lastChar}\"");

			}


		}
	}
}