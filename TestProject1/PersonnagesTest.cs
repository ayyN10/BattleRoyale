using Microsoft.VisualStudio.TestTools.UnitTesting;
using battlePerso.Classes.Personnages;

namespace BattlePersoTest
{
    [TestClass]
    public class PersonnagesTest
    {
        [TestMethod]
        public void TestCoup1()
        {
            Dieux Odin = new Dieux(100, 50, "Odin", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", 3, 50, 50);
            Odin.Coup(Zeus);
            float TestResult = Zeus.PointDeVie;
            Assert.AreEqual(199, TestResult);
        }
        [TestMethod]
        public void TestCoup2()
        {
            Dieux Odin = new Dieux(100, 50, "Odin", 1, 50, 50);
            Demon Hades = new Demon(150, 10, "Hades", 1, 50, 50);
            Odin.Coup(Hades);
            float TestResult = Hades.PointDeVie;
            Assert.AreEqual(49, TestResult);
        }
        [TestMethod]
        public void TestCoup3()
        {
            Dieux Odin = new Dieux(150, 50, "Odin", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", 3, 50, 50);
            Zeus.Coup(Odin);
            float TestResult = Odin.PointDeVie;
            Assert.AreEqual(45, TestResult);
        }
        [TestMethod]
        public void TestCoup4()
        {
            Demon Hades = new Demon(150, 10, "Hades", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", 3, 50, 50);
            Zeus.Coup(Hades);
            float TestResult = Hades.PointDeVie;
            Assert.AreEqual(145, TestResult);
        }
        [TestMethod]
        public void TestCoup5()
        {
            Demon Hades = new Demon(150, 10, "Hades", 1, 50, 50);
            Tueur_Dieux Zeus = new Tueur_Dieux(200, 52, "Zeus", 3, 50, 50);
            Hades.Coup(Zeus);
            float TestResult = Zeus.PointDeVie;
            Assert.AreEqual(139, TestResult);
        }
        [TestMethod]
        public void TestCoup6()
        {
            Dieux Odin = new Dieux(100, 50, "Odin", 1, 50, 50);
            Demon Hades = new Demon(150, 10, "Hades", 1, 50, 50);
            Hades.Coup(Odin);
            float TestResult = Odin.PointDeVie;
            Assert.AreEqual(100, TestResult);
        }
    }
}
