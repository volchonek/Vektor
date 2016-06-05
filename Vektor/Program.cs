using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektor
{
	class Rainbow : IComparable, IEquatable<Rainbow>
	{
		protected string Name { get; set; }
		protected int Lenght { get; set; }
		public Rainbow() { }
		public Rainbow(string Name, int Lenght)
		{
			this.Name = Name;
			this.Lenght = Lenght;
		}
		public void Draw()
		{
			Console.WriteLine("Цвет - {0}, длинна волны - {1} н.м.", this.Name, this.Lenght);
		}

		public int CompareTo(object obj)
		{
			Rainbow color = (Rainbow)obj;
			if (this.Lenght > color.Lenght) return 1;
			if (this.Lenght < color.Lenght) return -1;
			return 0;
		}

		public bool Equals(Rainbow other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			};
			if (ReferenceEquals(this, other))
			{
				return true;
			};
			return this.Lenght == other.Lenght && int.Equals(this.Lenght, other.Lenght);
		}
	}
	//класс реализующий генератор векторов
	class GeneratorCodeRainbow : IEnumerable<int>
	{
		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 380; i <= 780; i = i + 50)
			{
				yield return i;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var listcolor = new List<Rainbow>();

			listcolor.Add(new Rainbow("Оранжевый", 605));
			listcolor.Add(new Rainbow("Зеленный", 530));
			listcolor.Add(new Rainbow("Голубой", 495));
			listcolor.Add(new Rainbow("Синий", 465));
			listcolor.Add(new Rainbow("Красный", 700));
			listcolor.Add(new Rainbow("Желтый", 580));
			listcolor.Add(new Rainbow("Фиалетовый", 415));
			foreach (var item in listcolor)
			{
				item.Draw();
			}
			//сортировка через IComparable
			listcolor.Sort();
			Console.WriteLine("________________________________________");
			foreach (var item in listcolor)
			{
				item.Draw();
			}
			// сравнение цветов
			Console.WriteLine("________________________________________");
			var red = new Rainbow("Красный", 700);
			var blue = new Rainbow("Синий", 465);

			if (blue.Equals(red))
			{
				Console.WriteLine("Цвета совпадают");
			}
			else
			{
				Console.WriteLine("Цвета не совпадают");
			}
			//повторное сравнение цветов для проверки функции Equals
			Console.WriteLine("________________________________________");
			var red1 = new Rainbow("Красный", 700);
			var red2 = new Rainbow("Красный", 700);

			if (red1.Equals(red2))
			{
				Console.WriteLine("Цвета совпадают");
			}
			else
			{
				Console.WriteLine("Цвета не совпадают");
			}			
			Console.ReadKey();
		}
		public static void Sets<T>(T item)
		{
		}
	}
}
