# Rappels

## Classe

```C#
public class MaClasse
{
    private int unAttribut;

    public string UnePropriete { get;set; }

    public MaClasse()
    {
        // Constructeur pour initialiser une classe
    }

    public void UneMethode(string unParametre)
    {
        Console.WriteLine($"{unParametre} {UnePropriete} {unAttribut}")
    }
}
```

## Héritage

```C#
public abstract class MaClasseDeBase
{
    public void UneMethodeDeBase() { }
    public virtual void UneMethodePouvantEtreSpecialiseeAvecComportementDeBase() { } 
    public abstract void UneMethodePouvantEtreSpecialiseeSansComportementDeBase();
}

public class MaClasseSpecialisee : MaClasseDeBase
{
    public override void UneMethodePouvantEtreSpecialiseeAvecComportementDeBase() { }
    public override void UneMethodePouvantEtreSpecialiseeSansComportementDeBase();
}
```

## Interface

```C#
public interface IUneInterface
{
    void UneMethode(int unParametre);
    void UneAutreMethode();
}

public class MaClasse : IUneInterface
{
    public void UneMethode(int unParametre) { }
    public void UneAutreMethode() { }
}
```

## Polymorphisme

Imaginons le code suivant :

```C#
public abstract class Personnage
{
	public abstract void AttaqueSpeciale();
}

public class Sorcier : Personnage
{
	public void AttaqueSpeciale() 
	{ 
		Console.WriteLine("Boule de feu");
	}
}

public class Guerrier : Personnage
{
	public void AttaqueSpeciale() 
	{ 
		Console.WriteLine("Coup de boule");
	}
}
```

Comme Sorcier et Guerrier sont des personnages il est possible de constituer une équipe composée de personnages qui auront leurs propres spécificités et comportements sans jamais que cela n'apparaisse au niveau de l'équipe.

```C#
public class Equipe
{
	private List<Personnage> personnages;

	public Equipe(List<Personnage> personnages)
	{
		this.personnages = personnages;
	}

	public void AttaqueSpecialeGroupee()
	{
		foreach (var personnage in personnages)
		{
			personnage.AttaqueSpeciale();
		}
	}
}
```

L'interet est de pouvoir manipuler des objets selon leurs formes de base ou leurs de contrats tout en les laissant se comporter de manière spécifique.


