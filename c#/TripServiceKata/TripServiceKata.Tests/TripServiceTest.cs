using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TripServiceKata.Model;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripServiceTest
    {
        private TripService _service;
        private ITripDAO _mockTripDao;

        private Trip _aTrip = new Trip();

        [SetUp]
        public void Setup()
        {
            _mockTripDao = Substitute.For<ITripDAO>();
            _mockTripDao.FindTripsByUser(Arg.Any<User>())
                .Returns(user => new List<Model.Trip> {_aTrip});

            _service = new TripService(_mockTripDao);
        }

        [Test]
        public void RunsAtAll()
        {
            var loggedUser = new User();
            var targetUser = new User();
            _service.GetTripsByUser(targetUser, loggedUser);
        }
        
        [Test]
        public void ReturnsOneTripOfOneFriend()
        {
            // given
            var loggedUser = new User();
            var targetUser = new User();
            targetUser.AddFriend(loggedUser);
            targetUser.AddTrip(_aTrip);
            
            // when
            var actualTrips = _service.GetTripsByUser(targetUser, loggedUser);
            
            // then
            Assert.That(1 == actualTrips.Count);
            Assert.That(_aTrip, Is.EqualTo(actualTrips[0]));
        }
    }
}
