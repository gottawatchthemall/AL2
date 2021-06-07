# Decorator

Imaginons le code suivant :

```C#
public class Repository
{
	public string GetData(int id) { return "data"; }
}
```

Nous l'utilisons partout dans le code de la manière suivante :

```C#
var repository = new Repository();
var data = repository.GetData(1);
```

Après quelques temps, on nous demande d'ajouter la possibilité du cache. Nous ajoutons donc le code suivant :

```C#
public class Cache
{
	public string GetData(int id) { // return data ou null }
    public string Set(int id, string data) { // cache data }

}
```

Nous l'utilisons partout dans le code de la manière suivante :

```C#
var repository = new Repository();
var cache = new Cache();

var data = cache.GetData(id)
if(data == null) 
{
    data = repository.GetData(1);
    cache.Set(id, data);
}
```

Après quelques temps, on nous demande d'ajouter le log des appels en bdd. Nous ajoutons donc le code suivant :

```C#
public class Log
{
	public string LogGetData(int id) { // log }

}
```

```C#
var repository = new Repository();
var cache = new Cache();
var logger = new Logger();

var data = cache.GetData(id)
if(data == null) 
{
    logger.LogData(id);
    data = repository.GetData(1);
    cache.Set(id, data);
}
```

Il est facile de constater que plus nous allons ajouter des nouveaux comportement, plus nous allons devoir modifier le code orchestration et le faire grossir. Tentons d'améliorer les choses :

```C#
public interface IGetData 
{
   string GetData(int id); 
}

public class Repository : IGetData
{
	public string GetData(int id) { return "data"; }
}

public class Cache : IGetData
{
    private IGetData getData;

    public Cache(IGetData getData) {  this.getData = getData; }

	public string GetData(int id) 
    { 
        var findInCache = false // Chercher dans le cache

        if (findInCache) return "cachedData";

        var data =  getData(id); 

        Set(id, data);

        return data;
    }
}

public class Log : IGetData
{
    private IGetData getData;

    public Log(IGetData getData) {  this.getData = getData; }

	public string GetData(int id) 
    { 
        // log 
        getData();
    }
}
```

Utilisons le :

```C#
var repositoryWithCacheAndLog = new Cache(new Log(new Repository()));
repositoryWithCacheAndLog.GetData(1);
```

Le design pattern decorator est un design pattern structurel d'ajouter un comportement à un objet sans le modifier.

