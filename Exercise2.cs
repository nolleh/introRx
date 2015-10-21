
using System;
using System.Reactive.Linq;
using System.Reactive;

public class Exercise2 {

  private IObservable<int> Range(int start, int count) {
    return Observable.Generate(
      start,
      i => i < start + count,
      i => ++i,
      i => { return i; } );
  }

  private IObservable<int> Fibonacci() {
    // closure ??
    int FibN_1 = 1, FibN_2 = 0;

    return Observable.Generate(
      0,
      i => i < 10,
      i => ++i,
      i => { 
        if (i < 2) return i;
        var now = FibN_1 + FibN_2;
        FibN_2 = FibN_1;
        FibN_1 = now;
        return now; 
      });
  }

  public void start() {
    Console.WriteLine("start Exercise2");
    Range(0,5).Subscribe(Console.WriteLine);
    Console.WriteLine("---------------");
    Fibonacci().Subscribe(Console.WriteLine);
    // start Exercise2
      // 0
      // 1
      // 2
      // 3
      // 4
      // ---------------
      // 0
      // 1
      // 1
      // 2
      // 3
      // 5
      // 8
      // 13
      // 21
      // 34
  }

}