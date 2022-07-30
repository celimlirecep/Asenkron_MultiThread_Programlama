

using System.Runtime.Serialization;

async Task MyFunc()
{
    Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);
    List<string> myUrlList = new List<string>()
    {
          
        "https://jsonplaceholder.typicode.com/todos/1",
        "https://jsonplaceholder.typicode.com/todos/2",
        "https://jsonplaceholder.typicode.com/todos/3",
        "https://jsonplaceholder.typicode.com/todos/4",
        "https://jsonplaceholder.typicode.com/todos/5"
    };
    var icerik = GetContentAsync(myUrlList.First());
    Console.WriteLine("Myfunc thread: "+Thread.CurrentThread.ManagedThreadId);
   
    List<Task<Content>> taskList = new List<Task<Content>>();
    Content content = await icerik;
    foreach (var url in myUrlList)
    {
        taskList.Add(GetContentAsync(url));
    }
  
    Console.WriteLine(content.DataLength);

    //whenall blocklama yapmaz hepsini bittiğinden emin olmak için kullanılabilir
    //var contents = Task.WhenAll(taskList.ToArray());

    //Console.WriteLine("Content sınıfını içermeyen fonksiyonları buralarda çalıştırabiliriz\n");
    //var data=await contents;
    //foreach (var item in data)
    //{
    //    Console.WriteLine(item.DataLength);
    //}
    //4 urlden ilk önce hangisini çekerse onu yazırıcak
    //var firstData = await Task.WhenAny(taskList);
    //Console.WriteLine("\n"+firstData.Result.DataLength);

    //bütün dataları okur aynı anda ama sistemi tredi bloclar
    Console.WriteLine("\n Waitall dan önce");
    bool Is1000msFinished=Task.WaitAll(taskList.ToArray(),1000);
    Console.WriteLine("waitall dan sonra");
    Console.WriteLine("1 saniyede tamamlandı mı: "+Is1000msFinished);

    //waitany ilk tamamlananın indexini döner(blocklar)

    int index=Task.WaitAny(taskList.ToArray());
    Console.WriteLine(taskList[index].Result.DataLength);

    //delay metodu blocklama yapmaz yapan await

    await Task.Delay(3000);
    Console.WriteLine("3000 saniye bekle");




}
await MyFunc();
static async  Task<Content> GetContentAsync(string url)
{
    Content content = new Content();
    var data = await new HttpClient().GetStringAsync(url);
    //Console.WriteLine(data);
    await Task.Delay(5000);
    Console.WriteLine("\n GetContentAsync thread: "+Thread.CurrentThread.ManagedThreadId);

    content.DataLength = data.Length;
   


    return content;
}
class Content
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; } = string.Empty;
    public int completed { get; set; }
    public int DataLength { get; set; }

}