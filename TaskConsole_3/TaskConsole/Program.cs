

//iki farklı yazım türü getstringasyn biri bittikten sonra diğerini başlatıyo ama bu daha makul
  async Task Myfunction()
{
    Console.WriteLine("Hello, World!");

    //var myTask = new HttpClient().GetStringAsync("https://jsonplaceholder.typicode.com/todos/1").ContinueWith((data) =>
    //{

    //    Console.WriteLine("Data: " + data.Result);


    //});
    var myTask = new HttpClient().GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");

    Console.WriteLine("ARADA YAPILCAK İŞLER");
    var data =await myTask;
    Console.WriteLine("data:"+data+"\n");
    calis(data);
}

 void calis(string data)
{
    Console.WriteLine("İkinci kez data:"+data);
}
await Myfunction();


