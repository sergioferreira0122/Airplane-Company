using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Domain.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }

        public Destination? Destination { get; set; }

        public List<Client>? Clients { get; set; } = new List<Client>();

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public void AddClient(Client client)
        {
            Clients?.Add(client);
            client.Travels?.Add(this);
        }

        public void RemoveClient(Client client)
        {
            Clients?.RemoveAll(clients => clients.Id == client.Id);
            client.Travels?.RemoveAll(travel => travel.Id == this.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Travel travel &&
                   Id == travel.Id &&
                   EqualityComparer<Destination?>.Default.Equals(Destination, travel.Destination) &&
                   EqualityComparer<List<Client>?>.Default.Equals(Clients, travel.Clients) &&
                   StartDate == travel.StartDate &&
                   EndDate == travel.EndDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Destination, Clients, StartDate, EndDate);
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Destination)}={Destination}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(EndDate)}={EndDate.ToString()}}}";
        }


    }
}