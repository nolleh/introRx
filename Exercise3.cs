using System; 
using System.Reactive.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Collections.Generic;

public static class Extension { 

  public static IObservable<TSource> Where<TSource>(
    this IObservable<TSource> source,
    Func<TSource, bool> predicate) {

    return Observable.Create<TSource>(o => {
      source.Subscribe(item => {
        if (predicate(item)) o.OnNext(item);
      }, 
      item => o.OnCompleted());
      return Disposable.Empty;
    });
  }

  // 최초로 predicate 가 false 가 되기 전까지 skip (true 인 동안 버림)
  public static IObservable<TSource> SkipWhile<TSource>(
    this IObservable<TSource> source,
    Func<TSource, bool> predicate) {
    
    bool flag = false;

    return Observable.Create<TSource>(o => {
      source.Subscribe(item => {
        if (!flag && predicate(item)) ;
        else { 
          o.OnNext(item);
          flag = true;
        }
      },
      item => o.OnCompleted());

      return Disposable.Empty;
    });

  }

  public static IObservable<TSource> Distinct<TSource>(
    this IObservable<TSource> source) {

    List<TSource> list = new List<TSource>(); 
    return Observable.Create<TSource>(o => {
      source.Subscribe(item => {
        if (!list.Contains(item)) {
          o.OnNext(item);
          list.Add(item);
        }
      });

      return Disposable.Empty;
    });
  }
}

public class Exercise3 {

  public void start() {

    Console.WriteLine("start Exercise3");
    Console.WriteLine("--------Where With [1,2,3,4,5,1,2] -------");
    new int[]{1,2,3,4,5,1,2}.ToObservable()
      .Where(x=> x>1).Subscribe(Console.WriteLine);
    // 2 ~ 5, 2
    Console.WriteLine("--------SkipWhile With [1,2,3,4,5,1,2] -------");
    new int []{1,2,3,4,5,1,2}.ToObservable()
      .SkipWhile(x=> x<3).Subscribe(Console.WriteLine);
    // 3,4,5,1,2
    Console.WriteLine("--------Distinct With [1,2,3,4,5,1,2] -------");
    new int []{1,2,3,4,5,1,2}.ToObservable()
      .Distinct().Subscribe(Console.WriteLine);
    // 1,2,3,4,5


  }
}