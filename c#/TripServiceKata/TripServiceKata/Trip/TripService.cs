using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.Model;

namespace TripServiceKata.Model
{
    public class TripService
    {
        private readonly ITripDAO _tripDao;
        public TripService(ITripDAO tripDao)
        {
            _tripDao = tripDao;
        }
        public List<Trip> GetTripsByUser(User user, User loggedUser)
        {
            List<Trip> tripList = new List<Trip>();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach(User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    tripList = _tripDao.FindTripsByUser(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
