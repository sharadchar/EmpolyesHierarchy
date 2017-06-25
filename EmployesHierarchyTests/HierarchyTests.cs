using Common;
using EmployesData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployesHierarchyTests
{
    [TestClass]
    public class HierarchyTests
    {
        private Employee _objEmp;
        private SetupEmployes _dataObj;
        private Hierarchy _managerHierarchy;

        [TestInitialize]
        public void TestInitialize()
        {
            _objEmp = new Employee();
            _dataObj = new SetupEmployes();

            _managerHierarchy = new Hierarchy(_objEmp, _dataObj);
        }

        [TestMethod]
        public void GetTopManagerHierarchyTestSuccess()
        {
            int managerId = 150;
            Employee obj = _managerHierarchy.GetHierarchy(managerId);

            string recievedHierarchy = SerilizationHelper.SerializeObject(obj);
            
            string expectedHierarchy = EmbededFileHelper.ReadEmbededfile(this.GetType().Assembly, "ExpectedResult.ExpectedSuccessTopManager.txt");
            
            Assert.AreEqual(recievedHierarchy, expectedHierarchy, "Actual : \n" + recievedHierarchy + "\n Expected \n " + expectedHierarchy);            
        }

        [TestMethod]
        public void EmployeeDontExistTest()
        {
            int managerId = 50;
            
            Employee obj = _managerHierarchy.GetHierarchy(managerId);
                        
            Assert.IsNull(obj);
        }

        [TestMethod]
        public void GetSubManagerHierarchyTestSuccess()
        {
            int managerId = 274;
            Employee obj = _managerHierarchy.GetHierarchy(managerId);

            string recievedHierarchy = SerilizationHelper.SerializeObject(obj);

            string expectedHierarchy = EmbededFileHelper.ReadEmbededfile(this.GetType().Assembly, "ExpectedResult.ExpectedSuccessSubManager.txt");

            Assert.AreEqual(recievedHierarchy, expectedHierarchy, "Actual : \n" + recievedHierarchy + "\n Expected \n " + expectedHierarchy);
        }


    }
}
