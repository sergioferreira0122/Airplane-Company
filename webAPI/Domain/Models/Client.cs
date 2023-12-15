using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Domain.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<Travel>? Travels { get; set; } = new List<Travel>();

        public void AddTravel(Travel travel)
        {
            Travels?.Add(travel);
            travel.Clients?.Add(this);
        }

        public void RemoveTravel(Travel travel)
        {
            Travels?.RemoveAll(travels => travels.Id == travel.Id);
            travel.Clients?.RemoveAll(clients => clients.Id == this.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   Id == client.Id &&
                   Name == client.Name &&
                   EqualityComparer<List<Travel>?>.Default.Equals(Travels, client.Travels);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Travels);
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Travels)}={Travels}}}";
        }
    }
}