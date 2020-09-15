using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta1.Controllers;
using Pregunta1.Models;

namespace UnitTestPregunta1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            // ARRANGE
            MarinsController controller = new MarinsController();
            // ACT
            var listaPersonas = controller.GetMarins();
            // ASSERT
            Assert.IsNotNull(listaPersonas);
        }
        [TestMethod]
        public void TestPost()
        {
            // ARRANGE
            MarinsController controller = new MarinsController();
            Marin marin = new Marin()
            {
                marinID = 1,
                FriendofMarin = "Alberto Marin",
                place = Places.Porongo,
                Email = "albertomarin2001@outlook.com",
                Birthdate = DateTime.Now
            };
            // ACT
            IHttpActionResult actionResult = controller.PostMarin(marin);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Marin>;
            // ASSERT
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestPut()
        {
            //ARRANGE
            MarinsController controller = new MarinsController();
            Marin marin = new Marin()
            {
                marinID = 2,
                FriendofMarin = "Sebastian Ferrufino",
                place = Places.Montero,
                Email = "sfvm@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT
            IHttpActionResult actionResultPost = controller.PostMarin(marin);
            var result = controller.PutMarin(marin.marinID, marin) as StatusCodeResult;
            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
        [TestMethod]
        public void TestDelete()
        {
            //ARRANGE
            MarinsController controller = new MarinsController();
            Marin marin = new Marin()
            {
                marinID = 3,
                FriendofMarin = "Andre Velasco",
                place = Places.Warnes,
                Email = "andrevelascod@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT
            IHttpActionResult actionResultPost = controller.PostMarin(marin);
            IHttpActionResult actionResultDelete = controller.DeleteMarin(marin.marinID);
            //ASSERT
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Marin>));
        }
    }
}
