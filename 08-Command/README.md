# Command

```c#
interface IMachineACaffeCommande
{
    void Make(MachineACaffe mac);
}

class FaireCaffe : IMachineACaffeCommande
{
    public void Make(MachineACaffe mac)
    {
        // FAIRE CAFFE
        mac.EnvoyerTouillette();
    }
}


public class FaireSoupeALaTomate() : IMachineACaffeCommande
{
    public void Make(MachineACaffe mac)
    {
        // FAIRE SOUPE
        mac.EnvoyerTouillette();
    }
}

class MachineACaffe 
{
   public void EnvoyerTouillette()
   {
       // Faire descendre la touillette
   }
}

class Clavier
{
    public void DialCode(string code)
    {
        code swich{
            "0000" => new FaireCaffeCommande(caf),
             _ => new FaireSoupeALaTomate(caf)
        }   
    }   
}
```


