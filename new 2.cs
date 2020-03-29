using System;  
using System.Collections;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
  
namespace StringAnalysis 
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
		
			string text;
			Console.Write("Enter the text: ");
			text = Console.ReadLine();
			Console.WriteLine(text);
			string subtext;
			Console.Write("Enter the substring: ");
			subtext = Console.ReadLine();
			Console.WriteLine("subtext = "+ subtext);
            //string str = "This,is,C#,Corner,Website";  
            ArrayList arrayList = new ArrayList();  
			ArrayList indices = new ArrayList();
            string Temp = "";  
            for (int i = 0; i < text.Length; i++)  
            {  
  
                if (text[i] != subtext[i])  
                {  
                    Temp = Temp + text[i];  
                    continue;  
                }  
  
  
                arrayList.Add(Temp);  
				indices.Add(i);
                Temp = "";  
            }  
            //Console.WriteLine("Enter the no 1 to " + arrayList.Count);  
            //int option =Convert.ToInt32(Console.ReadLine());  
				

            //if (option <= arrayList.Count && option > 0)  
            //{  
            //    Console.WriteLine(option+ " position is  = " +arrayList[option - 1]);  
            //}  
            //else  
            //{  
            //   Console.WriteLine("Enter only 1 to " + arrayList.Count+1);  
            //}  
            Console.ReadLine();  
        }  
    }  
}