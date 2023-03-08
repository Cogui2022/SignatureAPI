using AppSignature.Dominio;
using AppSignature.Infraestructura.API.Controllers;
using System.Net;

namespace AppSignature.Infraestructura.API.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidacioinControllerTest()
        {
            var controller = new ValidacioinController();

            var ContractsList = new List<Contract>
            {
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract1",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "N",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "N",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                },
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract2",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "K",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "N",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                }
            };

            var result = controller.Post(null);
            Assert.IsNotNull(result);
        }


        [Test]
        public void GenerateWinSignatureControllerTest()
        {
            var controller = new GenerateWinSignatureController();

            var ContractsList = new List<Contract>
            {
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract1",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "N",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "#",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                },
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract2",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "N",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                }
            };

            var result = controller.Post(ContractsList);
            Assert.IsNotNull(result);
        }
    }
}