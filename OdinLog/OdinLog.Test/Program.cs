// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using OdinLog;

for (int i = 0; i<20000; i++)
{
    if(i%2==0) OdinLogUtils.Info($"log info:{DateTime.Now.ToString()}");  
    if(i%3==0) OdinLogUtils.Waring($"log info:{DateTime.Now.ToString()}");  
    if(i%5==0) OdinLogUtils.Error(new Exception($"log info:{DateTime.Now.ToString()}"));  
}
Console.WriteLine("over");
