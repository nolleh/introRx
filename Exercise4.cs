using System; 
using System.Reactive.Linq;
using System.Reactive;

namespace Exercise4 {

  public static class Extension2 { 
    public static IObservable<TSource> Where<TSource>(
      this IObservable<TSource> source,
      Func<TSource, bool> predicate) {

      return source.SelectMany(src => {
        if (predicate(src)) return Observable.Return(src);
        else return Observable.Empty<TSource>();
      }); 
    }

    public static IObservable<TResult> Select<TSource, TResult>(
      this IObservable<TSource> source,
      Func<TSource, TResult> selector) {

      return source.SelectMany(src => {
        return Observable.Return(selector(src));
      });
    }
  }

  public class Exercise {
  
    public void start() {
      Console.WriteLine("------- Exercise4 -------");
  	
      Console.WriteLine("--------Where With [1,2,3,4,5,1,2] -------");
      new int[]{1,2,3,4,5,1,2}.ToObservable()
        .Where(x=> x>1).Subscribe(Console.WriteLine);
      // 2,3,4,5,2
      Console.WriteLine("--------Select With [1,2,3,4,5,1,2] -------");
      new int[]{1,2,3,4,5,1,2}.ToObservable()
        .Select(x=> x*2).Subscribe(Console.WriteLine);
      // 2,4,6,8,10,2,4
    }
  }
}