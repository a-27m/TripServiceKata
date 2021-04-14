using System.Collections.Generic;

namespace TripServiceKata.Model
{
    public class User
    {
        private List<Model.Trip> trips = new List<Model.Trip>();
        private List<User> friends = new List<User>();

        public List<User> GetFriends()
        {
            return friends;
        } 

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(Model.Trip trip)
        {
            trips.Add(trip);
        }

        public List<Model.Trip> Trips()
        {
            return trips;
        } 
    }
}
