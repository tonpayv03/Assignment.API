using System.Security.AccessControl;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Pyramid(9);
			//WithdrawAps();
			//CheckParentheses("{()}");
			//CheckParentheses("{[]}");
			//CheckParentheses("[]()");
			//CheckParentheses("[{{{}}}]");
			//CheckNumberContinuous(new int[] { 9, 8, 7, 6, 5, 4, 3 });
			//CheckNumberContinuous(new int[] { 9, 8, 6, 5, 4, 3 });
			//CheckNumberContinuous(new int[] { 1, 2, 3, 4, 5, 6, 7 });
			//CheckNumberContinuous(new int[] { 1, 2, 3, 4, 5, 6 });
			//CheckNumberContinuous(new int[] { 1, 2, 3, 5, 6, 7 });
		}

		#region PTT
		public static void Pyramid(int layer)
		{
			for (int i = 1; i <= layer; i++)
			{
				// print space
				for (int j = i; j < layer; j++)
				{
					Console.Write(" ");
				}

				// print number
				for (int k = 0; k < i; k++)
				{
					Console.Write($"{i} ");
				}
				Console.WriteLine();

			}
		}
		#endregion

		#region TCR
		public static void SumOfPositiveBigIntegerNumbers()
		{
			Console.Write("Input A: ");
			var inputA = Console.ReadLine();

			Console.Write("Input B: ");
			var inputB = Console.ReadLine();

			inputA = inputA.PadLeft(inputB.Length, '0');
			inputB = inputB.PadLeft(inputA.Length, '0');

			var carry = 0;
			var result = "";

			for (int i = inputA.Length - 1; i >= 0; i--)
			{
				var elementA = inputA[i].ToString();
				var elementB = inputB[i].ToString();

				var sum = (int.Parse(elementA) + int.Parse(elementB)) + carry;

				// sum หาร 10 = ได้เลขทด --> 16 หาร 10 = 1.6 type int ปัดเศษเหลือ 1
				carry = sum / 10;
				// mod เอาเศษด้านหลัง --> 17%10 = 7
				var remain = sum % 10;

				result = $"{remain}{result}";

				if (i == 0 && carry != 0)
				{
					result = $"{carry}{result}";
				}

			}

			Console.WriteLine(result);
		}
		#endregion

		#region ZealTech
		public static void Withdraw()
		{
			/* จงเขียน code ฟังก์ชั่นถอนเงินจากตู้ ATM โดยตู้จะจ่ายธนบัตร 1000/500/100 บาท 
			* เรียงลำดับการจ่ายจากธนบัตรมูลค่ามากไปยังมูลค่าน้อยตามลำดับ 
			* กำหนดให้ฟังก์ชั่นรับตัวแปรเป็นจำนวนเงินที่ต้องการถอน 
			* และผลลัพธ์ของฟังก์ชั่นเป็นข้อความสรุปจำนวนธนบัตรแต่ละชนิดที่จ่าย */

			var input = Console.ReadLine();
			if (!int.TryParse(input, out int amount))
				return;

			var banks = new List<int> { 1000, 500, 100 };
			var bankCount = new Dictionary<int, int>();

			for (int i = 0; i < banks.Count; i++)
			{
				if (amount >= banks[i])
				{
					int count = amount / banks[i];
					amount %= banks[i];
					bankCount.Add(banks[i], count);
				}
			}

			foreach (var item in bankCount)
			{
				Console.WriteLine($"{item.Value} bank of {item.Key}");
			}
		}
		#endregion

		#region The Ampersand
		public static void WithdrawAps()
		{
			// 2. เขียน code โปรแกรม คำนวนแยกธนาบัตรและเหรียญ โดยมีเหรียญ 1, 2, 5, 10 ธนบัตร 20, 50, 100, 500 และ 1000
			// input 5432
			// output ธนบัตร 1000 จำนวน 5 ใบ, ธนบัตร 100 จำนวน 4 ใบ, เหรียญ 10 จำนวน 3, เหรียญ 2 จำนวน 1
			Console.Write("Input Amount: ");
			var input = Console.ReadLine();
			if (!int.TryParse(input, out int amount))
				return;

			var banks = new List<int> { 1000, 500, 100, 50, 20, 10, 5, 2, 1 };
			var bankCount = new Dictionary<int, int>();

			for (int i = 0; i < banks.Count; i++)
			{
				if (amount >= banks[i])
				{
					int number = amount / banks[i];
					amount %= banks[i];
					bankCount.Add(banks[i], number);
				}
			}

			foreach (var item in bankCount)
			{
				Console.WriteLine($"{item.Key} x {item.Value}");
			}
		}

		public static void CheckParentheses(string input)
		{
			// 3. เขียน code โปรแกรม ตรวจสอบเครื่องหมาย (){}[] ว่ามีการใช้ถูกหรือไม่
			// input {}()      => output true
			// input {()}      => output true
			// input {(})       => output false
			// input {}(        => output false

			if (input.Length == 1)
			{
				Console.WriteLine(false);
				return;
			}
			var brackets = new List<string>() { "(", "{", "[" };
			var openBrackets = new List<string>();

			for (int i = 0; i < input.Length; i++)
			{
				var parenthese = input[i].ToString();
				if (brackets.Contains(parenthese))
				{
					openBrackets.Add(parenthese);
				}
				else
				{
					var openBracket = openBrackets.LastOrDefault();
					var fullParenthese = openBracket + parenthese;
					if (fullParenthese == "()" || fullParenthese == "{}" || fullParenthese == "[]")
					{
						openBrackets.RemoveAt(openBrackets.LastIndexOf(openBracket));
					}
					else
					{
						Console.WriteLine(false);
						return;
					}
				}
			}

			Console.WriteLine(openBrackets.Count == 0);
		}

		public static void CheckNumberContinuous(int[] numbers)
		{
			// 4. เขียน code โปรแกรม ตรวจสอบ ชุดเลขที่ได้รับเข้ามาว่า ต่อเนื่องกันหรือไม่
			// input 1 2 3 4 5      => output true
			// input 7 6 5 4 3      => output true
			// input 1 3 4 5 6      => output false

			var firstNum = numbers[0];
			bool isContinuous = true;
			for (int i = 0; i < numbers.Length; i++)
			{
				var currentNumber = numbers[i];
				var isValidFromAsc = (currentNumber - i) == firstNum;
				var isValidFromDesc = (currentNumber + i) == firstNum;

				var convertBool = !(isValidFromAsc || isValidFromDesc);
				if (convertBool == true)
				{
					isContinuous = false;
					break;
				}
			}

			Console.WriteLine(isContinuous);
		}
		#endregion
	}
}