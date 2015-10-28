using System;
using System.Reactive.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;

public class Program
{
  class MyObservable : IObservable<int> {

    public MyObservable(Func<IObserver<int>, IDisposable> f) {
      mySubscribe = f;
    } 

    public IDisposable Subscribe(IObserver<int> observer) {
      return mySubscribe(observer);  
    }

    Func<IObserver<int>, IDisposable> mySubscribe;
  }

  // 1. 전달된 Subscribe 함수를 이용하여 Observable 생성
  public static IObservable<int> Create(Func<IObserver<int>, IDisposable> f)
  {
    // IObservable 은 그저 subscrbe 함수를 보유한 아이.  
    return new MyObservable(f);
  }
   
  // 2. seed 부터 count 개의 정수를 emit하는 Observable 생성
  public static IObservable<int> Range(int seed, int count)
  {
    // observable 의 subscribe 함수는 observer 가 인자! 
    return Create(o => {
      // C# 에서 range 로 list 만들어서 map 하고 싶은데 어떻게 하는지 모르겠으니 그냥 for 문
      for (int i = seed; i < seed+count; ++i) {
        o.OnNext(i);
      }
      return Disposable.Empty;
    });
  }
   
  // 3. ms 밀리초 후에 0을 emit하는 Observable 생성
  public static IObservable<int> Timer(int ms)
  {
    return Create(o => {
      Task.Delay(TimeSpan.FromMilliseconds(ms)).Wait();
      o.OnNext(0);
      return Disposable.Empty; 
    });
  }
   
  // 4. ms 밀리초마다 0부터 시작하는 정수를 emit하는 Observable 생성
  public static IObservable<int> Interval(int ms)
  {
    return Create(o => {
      for (int i = 0; ;++i) {
        o.OnNext(i);
        Task.Delay(TimeSpan.FromMilliseconds(ms)).Wait();
      }
      return Disposable.Empty;
    });
  }
   
  public static void Main (string[] args)
  {
    // var observable1 = Range(0, 5);
    // observable1.Subscribe(Console.WriteLine);
    // // 예상 출력
    // // 0
    // // 1
    // // 2
    // // 3
    // // 4
     
    // var observable2 = Timer(1000);
    // observable2.Subscribe(Console.WriteLine);
    // // 예상 출력 (1000 ms 후..)
    // // 0
     
    // var observable3 = Interval(1000);
    // observable3.Subscribe(Console.WriteLine);
    // 예상 출력 (1000 ms 마다..)
    // 0
    // 1
    // 2
    // …

    // new Exercise2().start();
    new Exercise3().start();
  }
}
