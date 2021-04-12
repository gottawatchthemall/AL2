using Xunit;

namespace _01.HelloKebab
{
    abstract class KekabElement
    {
        public abstract bool IsVegetarian();
        public abstract KekabElement RemoveOnion();
        public abstract KekabElement DoubleCheese();
        public abstract string Ingredients();
    }

    class Bread : KekabElement
    {
        public override bool IsVegetarian() => true;
        public override KekabElement RemoveOnion() => this;
        public override KekabElement DoubleCheese() => this;
        public override string Ingredients() => "pain";
    }

    class Tomato : KekabElement
    {
        readonly KekabElement _innerKekabElement;

        public Tomato(KekabElement innerKekabElement)
        {
            _innerKekabElement = innerKekabElement;
        }
        
        public override bool IsVegetarian() => _innerKekabElement.IsVegetarian();
        public override KekabElement RemoveOnion() => new Tomato(_innerKekabElement.RemoveOnion());
        public override KekabElement DoubleCheese() => new Tomato(_innerKekabElement.DoubleCheese());
        public override string Ingredients() => $"tomate - {_innerKekabElement.Ingredients()}";

    }

    class Meat : KekabElement
    {
        readonly KekabElement _innerKekabElement;

        public Meat(KekabElement innerKekabElement)
        {
            _innerKekabElement = innerKekabElement;
        }
        
        public override bool IsVegetarian() => false;
        public override KekabElement RemoveOnion() => new Meat(this._innerKekabElement.RemoveOnion());
        public override KekabElement DoubleCheese() => new Meat(_innerKekabElement.DoubleCheese());
        public override string Ingredients() => $"viande - {_innerKekabElement.Ingredients()}";

    }
    
    class Onion : KekabElement
    {
        readonly KekabElement _innerKekabElement;

        public Onion(KekabElement innerKekabElement)
        {
            _innerKekabElement = innerKekabElement;
        }
        
        public override bool IsVegetarian() => _innerKekabElement.IsVegetarian();
        public override KekabElement RemoveOnion() => _innerKekabElement.RemoveOnion();
        public override KekabElement DoubleCheese() => new Onion(_innerKekabElement.DoubleCheese());
        public override string Ingredients() => $"oignon - {_innerKekabElement.Ingredients()}";
    }
    
    class Cheese : KekabElement
    {
        readonly KekabElement _innerKekabElement;

        public Cheese(KekabElement innerKekabElement)
        {
            _innerKekabElement = innerKekabElement;
        }
        
        public override bool IsVegetarian() => _innerKekabElement.IsVegetarian();
        public override KekabElement RemoveOnion() => _innerKekabElement.RemoveOnion();
        public override KekabElement DoubleCheese() => new Cheese(new Cheese(_innerKekabElement.DoubleCheese()));
        public override string Ingredients() => $"fromage - {_innerKekabElement.Ingredients()}";
    }
    
    public class Playground
    {
        [Fact]
        public void un_kebab_sans_viande_est_vegetarien()
        {
            var kebabPain = new Bread();
            Assert.True(kebabPain.IsVegetarian());

            var kebabTomate = new Tomato(kebabPain);
            Assert.True(kebabTomate.IsVegetarian());
        }
        
        [Fact]
        public void un_kebab_avec_viande_nest_pas_vegetarien()
        {
            var kebabViande = new Tomato(new Meat(new Bread()));

            Assert.False(kebabViande.IsVegetarian());
        }
        
        [Fact]
        public void un_kebab_avec_oignon_na_plus_doignon_apres_RemoveOignon()
        {
            var kebabOignon = new Tomato(new Meat(new Onion(new Bread())));
            Assert.Equal("tomate - viande - oignon - pain", kebabOignon.Ingredients());
            
            var kebab = kebabOignon.RemoveOnion();
            Assert.Equal("tomate - viande - pain", kebab.Ingredients());
        }
        
        [Fact]
        public void un_kebab_avec_fromage_a_le_double_de_formage_apres_DoubleCheese()
        {
            var kebabFromage = new Tomato(new Cheese(new Meat(new Onion(new Bread()))));
            Assert.Equal("tomate - fromage - viande - oignon - pain", kebabFromage.Ingredients());
            
            var kebab = kebabFromage.DoubleCheese();
            Assert.Equal("tomate - fromage - fromage - viande - oignon - pain", kebab.Ingredients());
        }
    }
}