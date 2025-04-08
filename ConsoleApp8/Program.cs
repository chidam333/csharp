class Program
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public interface IRepository<T> where T : IEntity
    {
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class InMemoryRepository<T> : IRepository<T> where T : IEntity, new()
    {
        private readonly List<T> _entities = new List<T>();
        private int nextId = 1; 
        public T? GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }
        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.Id = nextId++;
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existing = _entities.FirstOrDefault(e => e.Id == entity.Id);
            if (existing != null)
            {
                var index = _entities.IndexOf(existing);
                _entities[index] = entity;
            }
            else
            {
                Console.WriteLine("Entity not found.");
            }
        }

        public void Delete(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
            else
            {
                Console.WriteLine("Entity not found.");
            }
        }
    }

    static void Main(string[] args)
    {
        IRepository<Product> repository = new InMemoryRepository<Product>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Product\n2. Get Product\n3. Update Product\n4. Delete Product\n5. Exit");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine()!;
                    Console.Write("Enter Product Price: ");
                    int price = int.Parse(Console.ReadLine()!);
                    var product = new Product { Name = name, Price = price };
                    repository.Add(product);
                    Console.WriteLine($"Added Product with Id: {product.Id}");
                    break;
                case "2":
                    Console.Write("Enter Product Id: ");
                    int idToGet = int.Parse(Console.ReadLine()!);
                    var retrievedProduct = repository.GetById(idToGet);
                    if (retrievedProduct != null)
                        Console.WriteLine($"Product Found: {retrievedProduct.Name}, Price: {retrievedProduct.Price}");
                    else
                        Console.WriteLine("Product not found.");
                    break;
                case "3":
                    Console.Write("Enter Product Id to update: ");
                    int idToUpdate = int.Parse(Console.ReadLine()!);
                    var productToUpdate = repository.GetById(idToUpdate);
                    if (productToUpdate != null)
                    {
                        Console.Write("Enter new Product Name: ");
                        productToUpdate.Name = Console.ReadLine()!;
                        Console.Write("Enter new Product Price: ");
                        productToUpdate.Price = int.Parse(Console.ReadLine()!);
                        repository.Update(productToUpdate);
                        Console.WriteLine("Product updated.");
                    }
                    else
                        Console.WriteLine("Product not found.");
                    break;
                case "4":
                    Console.Write("Enter Product Id to delete: ");
                    int idToDelete = int.Parse(Console.ReadLine()!);
                    repository.Delete(idToDelete);
                    Console.WriteLine("Product deleted.");
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}