using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestClass]
    public class ReservationTests
    {
        private Reservation reservation;
        private User user;

        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            //Arrenge 
            reservation = new Reservation();

            //act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelled_WhenUserIsAdmin_ThenReturnFalse()
        {
            reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanBeCancelled_WhenSameUser_ThenReturnTrue()
        {
            user = new User();
            var reservation = new Reservation { MadeBy = user};          

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelled_WhenOtherser_ThenFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            Assert.IsFalse(result);


        }

    }
}
