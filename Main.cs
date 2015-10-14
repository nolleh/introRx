using System;
using System.Reactive.Linq;
using System.Reactive;
using System.Reactive.Disposables;

public class Program
{
  // 1. 전달된 Subscribe 함수를 이용하여 Observable 생성
  public static IObservable<int> Create(Func<IObserver<int>, IDisposable> f)
  {
    // TODO
    return null;
  }
   
  // 2. seed 부터 count 개의 정수를 emit하는 Observable 생성
  public static IObservable<int> Range(int seed, int count)
  {
    // TODO
    return null;
  }
   
  // 3. ms 밀리초 후에 0을 emit하는 Observable 생성
  public static IObservable<int> Timer(int ms)
  {
    // TODO
    return null;
  }
   
  // 4. ms 밀리초마다 0부터 시작하는 정수를 emit하는 Observable 생성
  public static IObservable<int> Interval(int ms)
  {
    // TODO
    return null;
  }
   
  public static void Main (string[] args)
  {

    Console.WriteLine("hihihihiih");
    var observable1 = Range(0, 5);
    observable1.Subscribe(Console.WriteLine);
    // 예상 출력
    // 0
    // 1
    // 2
    // 3
    // 4
     
    var observable2 = Timer(1000);
    observable2.Subscribe(Console.WriteLine);
    // 예상 출력 (1000 ms 후..)
    // 0
     
    var observable3 = Interval(1000);
    observable3.Subscribe(Console.WriteLine);
    // 예상 출력 (1000 ms 마다..)
    // 0
    // 1
    // 2
    // …
  }
}
