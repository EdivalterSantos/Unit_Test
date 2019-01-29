using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestClass]
    public class ReservationTest
    {
        Reservation reservation;

        [TestMethod]
        public void CanBeCanceldBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            reservation = new Reservation();
            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            //Assert

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelldBy_MadeBySameUser_ReturnsTrue()
        {
            //Arrange
            var user = new User();
            reservation = new Reservation { MadeBy = user};

            // Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void CanBeCancelled_OtherUser_ReturnFalse()
        {
            reservation = new Reservation { MadeBy = new User()};

            var result = reservation.CanBeCancelledBy( new User());

            Assert.IsFalse(result);
        }

    }
}
